using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pinball
{
    class BongBay
    {
        public Rectangle[] bongbayRec;
        private SolidBrush brushbongbay;
        private int x, y, width, height;


        public BongBay()
        {
            bongbayRec = new Rectangle[1];
            brushbongbay = new SolidBrush(Color.Red);
            x =-30; y = 110; width = 10;height = 10;
            for(int i=0; i< bongbayRec.Length; i++)
            {
                bongbayRec[i] = new Rectangle(x, y, width, height);
                x -= 10;
            }
        }
        public void drawbongbay(Graphics paper)
        {
            foreach (Rectangle rec in bongbayRec)
            {
                paper.FillEllipse(brushbongbay, rec);
            }
        }
        //bongbay di chuyen
        public void drawbongbayRun()
        {
            bongbayRec[0].X += 1;
        }
    }
}
