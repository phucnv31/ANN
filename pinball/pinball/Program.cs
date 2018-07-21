using NeuronDotNet.Core.Backpropagation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pinball
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            int populationSize = 10;
            DataGame.InnitGameState(populationSize);
            DataGame[] lstDataGame = new DataGame[populationSize];
            ANN NeuralNetwork = new ANN(ref lstDataGame,populationSize);
            NeuralNetwork.createFirstGeneration();
            for (int i = 0; i < lstDataGame.Length-1; i++)
            {
                Task.Run(() =>
                {
                    App(ref NeuralNetwork,i);
                });
                Thread.Sleep(1000);
            }
            Application.Run(new Form1(ref NeuralNetwork,lstDataGame.Length-1));
        }
        static void App(ref ANN network,int gameIndex)
        {
            Application.Run(new Form1(ref network,gameIndex));
        }
    }
}
