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
    }
}
