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
    }
}
