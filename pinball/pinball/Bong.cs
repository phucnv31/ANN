using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pinball
{
    class Bong
    {
        public Rectangle[] bongRec;
        private SolidBrush brushbong;
        private int x, y, width, height;
        //ham khoi tao
        public Bong()
        {
            bongRec = new Rectangle[1];
            brushbong = new SolidBrush(Color.Red);
            x = 140; y = 282; width = 10; height = 10;
            for (int i = 0; i < bongRec.Length; i++)
            {
                bongRec[i] = new Rectangle(x, y, width, height);
                
            }
        }
        public void drawbong(Graphics paper)
        {
            foreach (Rectangle rec in bongRec)
            {
                paper.FillEllipse(brushbong, rec);
            }
        }
        //bong di chuyen

        public void drawbongRun1()
        {
            for (int i = bongRec.Length - 1; i > 0; i--)
            {
                bongRec[i] = bongRec[i - 1];
                
            }
            bongRec[0].X -= 1;
            bongRec[0].Y -= 1;
        }
        public void drawbongRun2()
        {
            for (int i = bongRec.Length - 1; i > 0; i--)
            {
                bongRec[i] = bongRec[i - 1];
                
            }
                bongRec[0].X += 1;
                bongRec[0].Y -= 1;
        }
        public void drawbongRun3()
        {
            for (int i = bongRec.Length - 1; i > 0; i--)
            {
                bongRec[i] = bongRec[i - 1];
                
            }
            bongRec[0].X += 1;
            bongRec[0].Y += 1;
        }
        public void drawbongRun4()
        {
            for (int i = bongRec.Length - 1; i > 0; i--)
            {
                bongRec[i] = bongRec[i - 1];
                
            }
            bongRec[0].X -= 1;
            bongRec[0].Y += 1;
        }
        

    }
}
