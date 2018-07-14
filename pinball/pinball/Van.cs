using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pinball
{
    class Van
    {
        public Rectangle[] vanRec;
        private SolidBrush brushvan;
        private int x, y, width, height;
        ///
        ///ham khoi tao van
        ///
        public Van()
        {
            vanRec = new Rectangle[1];
            brushvan = new SolidBrush(Color.Blue);
            x = 130; y = 292; width = 30; height = 5 ;
            for(int i=0;i< vanRec.Length; i++)
            {
                vanRec[i] = new Rectangle(x, y, width, height);
              
            }
        }
        public void drawvan(Graphics paper)
        {
            foreach(Rectangle rec in vanRec)
            {
                paper.FillRectangle(brushvan, rec);
            }
        }
   
        //van di chuyen
        public void drawvanRun()
        {
            for(int i= vanRec.Length - 1; i > 0; i--)
            {
                vanRec[i] = vanRec[i-1];
            }
        }
        public void moveRightvan()
        {
            while (vanRec[0].X < 260)
            {
                
                vanRec[0].X += 10;
                break;
            }
        }
        public void moveLeftvan()
        {
            while (vanRec[0].X > 0)
            {
                
                vanRec[0].X -= 10;
                break;
            }
        }
    }
}
