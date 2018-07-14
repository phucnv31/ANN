using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pinball
{
    class Dan3
    {
        public Rectangle[] danRec3;
        private SolidBrush brushdan3;
        private int x, y, width, height;
        //khoi tao dan
        public Dan3()
        {
            danRec3 = new Rectangle[1];
            brushdan3 = new SolidBrush(Color.Black);
            x = -30; y = -30; width = 4; height = 4;
            for (int i = 0; i < danRec3.Length; i++)
            {
                danRec3[i] = new Rectangle(x, y, width, height);
            }
        }
        public void drawdan3(Graphics paper)
        {
            foreach (Rectangle rec in danRec3)
            {
                paper.FillRectangle(brushdan3, rec);
            }
        }
        //dan bay
        public void drawdanRun3() { danRec3[0].X += 3; }
    }
}
