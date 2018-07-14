using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pinball
{
    class Bad_Item
    {
        private int x, y, width, height;
        private SolidBrush brushbaditem;
        public Rectangle baditemRec;
        public Bad_Item(Random randBaditem)
        {
            x = randBaditem.Next(0, 23) * 10;
            y = randBaditem.Next(3, 25) * 10;
            brushbaditem = new SolidBrush(Color.Chocolate);
            width = 10; height = 10;
            baditemRec = new Rectangle(x, y, width, height);
        }
        public void baditemLocation(Random randBaditem)
        {
            x = randBaditem.Next(0, 29) * 10;
            y = randBaditem.Next(3, 27) * 10;
        }
        public void drawBaditem(Graphics paper)
        {
            baditemRec.X = x;
            baditemRec.Y = y;
            paper.FillEllipse(brushbaditem, baditemRec);

        }
    }
}
