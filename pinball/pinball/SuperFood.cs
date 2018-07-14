using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pinball
{
    class SuperFood
    {
        private int x, y, width, height;
        private SolidBrush brushsuperfood;
        public Rectangle superfoodRec;
        public SuperFood()
        {
            brushsuperfood = new SolidBrush(Color.DarkRed);
            width = 30;height = 30;x = 350;y = 350;
            superfoodRec = new Rectangle(x, y, width, height);
        }
        public void superfoodLocation(Random randSuperFood)
        {
            x = randSuperFood.Next(0, 29) * 10;  
            y = randSuperFood.Next(3, 27) * 10;
        }
        public void drawSuperFood(Graphics paper)
        {
            superfoodRec.X = x;
            superfoodRec.Y = y;
            paper.FillEllipse(brushsuperfood, superfoodRec);
        }
    }
}
