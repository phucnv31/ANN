using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pinball
{
    class ChanBay2
    {
        public Rectangle[] chanbay2Rec;
        private SolidBrush brushchanbay2;
        private int x, y, width, height;
        public ChanBay2()
        {
            chanbay2Rec = new Rectangle[1];
            brushchanbay2 = new SolidBrush(Color.Black);
            x = -50; y = 100;width = 10;height = 30;
            for(int i=0; i < chanbay2Rec.Length; i++)
            {
                chanbay2Rec[i] = new Rectangle(x, y, width, height);
                x -= 10;
            }
        }
        public void drawchanbay2(Graphics paper)
        {
            foreach(Rectangle rec in chanbay2Rec)
            {
                paper.FillRectangle(brushchanbay2, rec);
            }
        }
        //ve chan bay 2 di chuyen
        public void drawchanbay2Run()
        {
            chanbay2Rec[0].X += 1;
        }
    }
}
