using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pinball
{
    class Dan1
    {
        public Rectangle[] danRec1;
        private SolidBrush brushdan1;
        private int x, y, width, height;
        //khoi tao dan
        public Dan1()
        {
            danRec1 = new Rectangle[1];
            brushdan1 = new SolidBrush(Color.Black);
            x = -30;y = -30;width = 4;height = 4;
            for(int i = 0; i < danRec1.Length; i++)
            {
                danRec1[i] = new Rectangle(x, y, width, height);
            }
        }
        public void drawdan1(Graphics paper)
        {
            foreach(Rectangle rec in danRec1)
            {
                paper.FillRectangle(brushdan1, rec);
            }
        }
        //dan bay
        public void drawdanRun1() { danRec1[0].X -= 3; }
    }
}
