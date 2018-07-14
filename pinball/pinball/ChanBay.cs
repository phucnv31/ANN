using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pinball
{
    class ChanBay
    {
        public Rectangle[] chanbayRec;
        private SolidBrush brushchan;
        private int x, y, width, height;
        public ChanBay()
        { 
            chanbayRec = new Rectangle[1];
            brushchan = new SolidBrush(Color.Black);
            x = -10; y = 100; width = 10; height = 30;   
            for (int i= 0;i<chanbayRec.Length; i++)
            {
                chanbayRec[i] = new Rectangle(x, y, width, height);
                    x -= 10;
            }    
    }
        public void drawchanbay(Graphics paper)
        {foreach (Rectangle rec in chanbayRec)
            {
                paper.FillRectangle(brushchan,rec);
            }
        }
        //chanbay di chuyen
        public void drawchanbayRun()
        {
            chanbayRec[0].X += 1;
        }
    
    }
}
