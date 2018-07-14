using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pinball
{
    class Dan2
    {
        public Rectangle[] danRec2;
        private SolidBrush brushdan2;
        private int x, y, width, height;
        //khoi tao dan
        public Dan2()
        {
            danRec2 = new Rectangle[1];
            brushdan2 = new SolidBrush(Color.Black);
            x = -30; y = -30; width = 4; height =4;
            for (int i = 0; i < danRec2.Length; i++)
            {
                danRec2[i] = new Rectangle(x, y, width, height);
            }
        }
        public void drawdan2(Graphics paper)
        {
            foreach (Rectangle rec in danRec2)
            {
                paper.FillRectangle(brushdan2, rec);
            }
        }
        //dan bay
        public void drawdanRun2() { danRec2[0].Y -= 3; }
    }
}
