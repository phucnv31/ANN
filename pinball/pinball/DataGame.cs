using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pinball
{
    public class DataGame
    {
        public int Score { set; get; }
        public int GameTime { set; get; }
        public int VanPositionX { set; get; }
        public Point BongPosition { set; get; }
        public static List<bool> GameState=new List<bool>();
        public DataGame()
        {
            Score = 0;
            GameTime = 1;
            VanPositionX = 0;
            BongPosition = new Point();
        }
        public DataGame(int score,int gameTime,int vanPositionX, Point bongPosition)
        {
            this.Score = score;
            this.GameTime = gameTime;
            this.VanPositionX = vanPositionX;
            this.BongPosition = bongPosition;
        }
        public static void InnitGameState(int populationSize)
        {
            GameState.Clear();
            for (int i = 0; i < populationSize; i++)
            {
                GameState.Add(true);
            }
        }
        public static bool IsAllGameFailed()
        {
            try
            {
                return GameState.All(x => x == false);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void ResetGameState()
        {
            for (int i = 0; i < GameState.Count; i++)
            {
                GameState[i] = true;
            }
        }
    }
}
