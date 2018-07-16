using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pinball
{
    public class ANN
    {
        [Serializable]
        public class WeightsInfo
        {
            // hidden layer weights
            public double[,] weights1;

            // output layer weights
            public double[,] weights2;

            // score
            public float fitness;

            public WeightsInfo(double[,] weights1, double[,] weights2, float fitness)
            {
                this.weights1 = weights1;
                this.weights2 = weights2;
                this.fitness = fitness;
            }

            public WeightsInfo()
            {
                this.fitness = 0;
                this.weights1 = new double[inputSize, hiddenSize];
                this.weights2 = new double[hiddenSize, outputSize];
            }
        }

        public DataGame[] lstgame { set; get; }
        Random r = new Random();

        static int inputSize, hiddenSize, outputSize;
        double[,] input, output;

        List<WeightsInfo> weightsList = new List<WeightsInfo>();
        List<WeightsInfo> nextWeightsList = new List<WeightsInfo>();

        //int crtIndex = 0;

        //// this is for sharing data between processes
        DataSharer dataSharer = new DataSharer();
        Mutex mmfMutex = null;


        public ANN(ref DataGame[] lstgame)
        {
            this.lstgame = lstgame;
        }

        // spawns the first generation of birds (w/ random weights)
        public void createFirstGeneration()
        {
            inputSize = 3;
            hiddenSize = 2;
            outputSize = 1;


            for (int k = 0; k < POPULATION_SIZE; k++)
            {
                double[,] _weights1 = new double[inputSize, hiddenSize];

                for (int i = 0; i < _weights1.GetLength(0); i++)
                    for (int j = 0; j < _weights1.GetLength(1); j++)
                        _weights1[i, j] = r.NextDouble() * 2 - 1;


                double[,] _weights2 = new double[hiddenSize, outputSize];

                for (int i = 0; i < _weights2.GetLength(0); i++)
                    for (int j = 0; j < _weights2.GetLength(1); j++)
                        _weights2[i, j] = r.NextDouble() * 2 - 1;

                weightsList.Add(new WeightsInfo(_weights1, _weights2, 0));
            }

        }

        float min = float.MaxValue;
        //float minTowerY = 1, maxTowerY = 1;
        //float distanceToTower = 0;
        //float minDistanceToTower = 0;

        //float centerPos = 0;

        // called by the game's update() method
        // returns: true if the bird should jump, false otherwise
        public bool runForward(int gameIndex)
        {
            min = float.MaxValue;

            // indentifies the closest tower
            //for (int i = 0; i < game.tower1.Count; i++)
            //{
            //    distanceToTower = Math.Abs(game.tower1[i].towerPosition.X - game.floppy_bird.birdPosition.X - game.floppy_bird.birdRectangle.Width);

            //    if (distanceToTower < min)
            //    {
            //        min = distanceToTower;
            //        minDistanceToTower = distanceToTower;
            //        maxTowerY = game.tower2[i].towerPosition.Y;
            //        minTowerY = maxTowerY - game.difference;

            //        centerPos = (maxTowerY + minTowerY) / 2;
            //    }
            //}

            // the inputs for the neural network
            input = new double[1, inputSize];

            input[0, 0] = lstgame[gameIndex].VanPositionX;
            input[0, 1] = lstgame[gameIndex].BongPosition.X;
            input[0, 2] = lstgame[gameIndex].BongPosition.Y;

            // computing the inputs & outputs for the hidden layer
            double[,] hiddenInputs = multiplyArrays(input, weightsList[gameIndex].weights1);
            double[,] hiddenOutputs = applySigmoid(hiddenInputs);

            // then the final output
            output = applySigmoid(multiplyArrays(hiddenOutputs, weightsList[gameIndex].weights2));




            return output[0, 0] > 0.5;


        }


        // the whole encode / decode process (just for learning purposes)
        void encode(WeightsInfo weightsInfo, List<double> gene)
        {
            for (int i = 0; i < weightsInfo.weights1.GetLength(0); i++)
                for (int j = 0; j < weightsInfo.weights1.GetLength(1); j++)
                {
                    gene.Add(weightsInfo.weights1[i, j]);
                }

            for (int i = 0; i < weightsInfo.weights2.GetLength(0); i++)
                for (int j = 0; j < weightsInfo.weights2.GetLength(1); j++)
                {
                    gene.Add(weightsInfo.weights2[i, j]);
                }
        }

        void decode(WeightsInfo weightsInfo, List<double> gene)
        {
            for (int i = 0; i < weightsInfo.weights1.GetLength(0); i++)
                for (int j = 0; j < weightsInfo.weights1.GetLength(1); j++)
                {
                    weightsInfo.weights1[i, j] = gene[0];
                    gene.RemoveAt(0);
                }

            for (int i = 0; i < weightsInfo.weights2.GetLength(0); i++)
                for (int j = 0; j < weightsInfo.weights2.GetLength(1); j++)
                {
                    weightsInfo.weights2[i, j] = gene[0];
                    gene.RemoveAt(0);
                }
        }

        // creates a new candidate solution using crossover
        void crossover(List<double> gene1, List<double> gene2)
        {
            if (r.NextDouble() > CROSSOVER_RATE)
                return;


            List<double> descendant1 = new List<double>();
            List<double> descendant2 = new List<double>();

            // mixing the genes using the arithmetic mean
            for (int i = 0; i < gene1.Count; i++)
            {
                descendant1.Add((gene1[i] + gene2[i]) / 2.0);
                descendant2.Add((gene1[i] + gene2[i]) / 2.0);
            }


            // decoding the result back to the "weights-format"
            WeightsInfo weightsInfo1 = new WeightsInfo();
            decode(weightsInfo1, descendant1);
            nextWeightsList.Add(weightsInfo1);


            WeightsInfo weightsInfo2 = new WeightsInfo();
            decode(weightsInfo2, descendant2);
            nextWeightsList.Add(weightsInfo2);

        }

        // randomly adjusts a weight in order to improve it
        bool mutate(List<double> gene)
        {
            bool mutated = false;

            for (int i = 0; i < gene.Count; i++)
            {
                if (r.NextDouble() < MUTATION_RATE)
                {
                    gene[i] += (r.NextDouble() * 2 - 1);
                    mutated = true;
                }
            }

            return mutated;
        }

        // selection function for crossover (picks the better one from 2 random candidates)
        WeightsInfo select()
        {
            int i1 = 0;
            int i2 = 0;

            while (i1 == i2)
            {
                i1 = r.Next(0, weightsList.Count -1);
                i2 = r.Next(0, weightsList.Count -1);
            }
            try
            {
                if (weightsList[i1].fitness > weightsList[i2].fitness)
                    return weightsList[i1];
                else
                    return weightsList[i2];
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
                throw;
            }
        }


        double CROSSOVER_RATE = 0.8;
        double MUTATION_RATE = 0.05;
        int POPULATION_SIZE = 5;

        float averageFitness = 0;
        float maxFitness = 0;
        int generation = 0;

        public void breedNetworks(int gameIndex)
        {

            // updates the score
            weightsList[gameIndex].fitness = lstgame[gameIndex].GameTime + lstgame[gameIndex].Score*2;

            averageFitness += weightsList[gameIndex].fitness;
            maxFitness = maxFitness > weightsList[gameIndex].fitness ? maxFitness : weightsList[gameIndex].fitness;


            if(FileIO.IsAllGameFailed())
            {
                generation++;

                Debug.WriteLine("GEN: " + generation + " | AVG: " + averageFitness / (float)POPULATION_SIZE + " | MAX: " + maxFitness);
                averageFitness = 0;
                maxFitness = 0;


                weightsList = weightsList.OrderByDescending(wi => wi.fitness).ToList();

                // starting with a large mutation rate so there's will be more solutions to choose from
                if (weightsList[0].fitness < 10000)
                    MUTATION_RATE = 0.9;
                else
                    MUTATION_RATE = 0.05;

                // adding better solutions from the other instances (if any)
                if (nextWeightsList.Count + 3 <= POPULATION_SIZE)
                {
                    // the whole synchronization thingy
                    try
                    {
                        if (mmfMutex == null)
                            mmfMutex = Mutex.OpenExisting("mmfMutex");

                        if (mmfMutex.WaitOne())
                        {

                            WeightsInfo wi = new WeightsInfo();
                            wi = dataSharer.getFromMemoryMap();

                            if (wi == null || wi.fitness < weightsList[0].fitness)
                            {
                                if (wi == null)
                                    Debug.WriteLine("Updated - NULL -> " + weightsList[0].fitness);

                                if (wi != null)
                                    Debug.WriteLine("Updated - " + wi.fitness + " -> " + weightsList[0].fitness);

                                dataSharer.writeToMemoryMap(weightsList[0]);
                            }

                            if (wi != null && wi.fitness > weightsList[0].fitness)
                            {
                                nextWeightsList.Add(wi);
                            }

                            mmfMutex.ReleaseMutex();
                        }
                    }
                    catch (WaitHandleCannotBeOpenedException ex)
                    {
                        mmfMutex = new Mutex(true, "mmfMutex");
                        nextWeightsList.AddRange(weightsList.Take(3));
                        mmfMutex.ReleaseMutex();
                    }

                    // adding elites to the next generation
                    nextWeightsList.AddRange(weightsList.Take(2));
                }

                // creating a new generation 
                while (nextWeightsList.Count < POPULATION_SIZE)
                {
                    WeightsInfo w1 = select();
                    WeightsInfo w2 = select();


                    while (w1 == w2)
                    {
                        w1 = select();
                        w2 = select();
                    }

                    List<double> gene1 = new List<double>();
                    List<double> gene2 = new List<double>();

                    encode(w1, gene1);
                    encode(w2, gene2);


                    crossover(gene1, gene2);

                    if (mutate(gene1))
                        w1 = new WeightsInfo();

                    if (mutate(gene2))
                        w2 = new WeightsInfo();

                    decode(w1, gene1);
                    decode(w2, gene2);

                    if (!nextWeightsList.Contains(w1))
                        nextWeightsList.Add(w1);

                    if (!nextWeightsList.Contains(w2))
                        nextWeightsList.Add(w2);
                }

                weightsList.Clear();
                nextWeightsList = nextWeightsList.OrderByDescending(wi => wi.fitness).ToList();


                weightsList.AddRange(nextWeightsList);

                nextWeightsList.Clear();
            }
        }

        // -- below are some methods used to compute the outputs of the neural networks

        #region MathHelpers

        double[,] applySigmoid(double[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = sigmoid(array[i, j]);

            return array;
        }

        double sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        double[,] multiplyArrays(double[,] a1, double[,] a2)
        {
            double[,] a3 = new double[a1.GetLength(0), a2.GetLength(1)];

            for (int i = 0; i < a3.GetLength(0); i++)
                for (int j = 0; j < a3.GetLength(1); j++)
                {
                    a3[i, j] = 0;
                    for (int k = 0; k < a1.GetLength(1); k++)
                        a3[i, j] = a3[i, j] + a1[i, k] * a2[k, j];
                }
            return a3;
        }
        #endregion MathHelpers
    }
}
