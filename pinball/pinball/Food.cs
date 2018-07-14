using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pinball
{
    class Food
    {
        private int x, y, width, height;
        private SolidBrush brushfood;
        public Rectangle foodRec;
        public Food(Random randFood)
        {
            x = randFood.Next(0, 23)*10;
            y = randFood.Next(3, 25) * 10;
            brushfood = new SolidBrush(Color.Green);
            width = 10;height = 10;
            foodRec = new Rectangle(x, y, width, height);

        }
        public void foodLocation(Random randFood)
        {
            x = randFood.Next(0, 29) * 10;
            y = randFood.Next(3, 27) * 10;
        }
        public void drawFood(Graphics paper)
        {
            foodRec.X = x;
            foodRec.Y = y;
            paper.FillEllipse(brushfood, foodRec);
        }
    }
}
