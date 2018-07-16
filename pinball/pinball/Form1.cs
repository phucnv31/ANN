using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuronDotNet.Core;
using NeuronDotNet.Core.Backpropagation;
using System.Diagnostics;
using System.Threading;

namespace pinball
{
    public partial class Form1 : Form
    {
        int gameIndex;
        int diemcao = 0;
        int diemn;
        int s = 2;
        bool napdan = true;
        bool keyb = false;
        bool tatspace = true;
        bool stopdraw = false;
        bool isRestart = false;
        int sodan = 2;
        int score = 0;
        int dem = 0;
        int gameTime = 0;
        public static string caothu;
        Dan2 dan2 = new Dan2();
        Dan1 dan1 = new Dan1();
        Dan3 dan3 = new Dan3();
        Random randSuperFood = new Random();
        Random randFood = new Random();
        Random randBaditem = new Random();
        Bad_Item baditem;
        Food food;
        SuperFood superfood;
        Graphics paper;
        ChanBay2 chanbay2 = new ChanBay2();
        BongBay bongbay = new BongBay();
        ChanBay chanbay = new ChanBay();
        Van van = new Van();
        Bong bong = new Bong();
        Boolean right = false, left = false;
        ANN network;
        FileIO fileIO;
        Stopwatch watch;
        public Form1(ref ANN network, FileIO fileIO, int gameIndex)
        {
            InitializeComponent();
            food = new Food(randFood);
            superfood = new SuperFood();
            baditem = new Bad_Item(randBaditem);
            this.network = network;
            this.fileIO = fileIO;
            this.gameIndex = gameIndex;
            watch = Stopwatch.StartNew();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            van.drawvan(paper);
            bong.drawbong(paper);
            food.drawFood(paper);
            baditem.drawBaditem(paper);
            dan1.drawdan1(paper);
            dan2.drawdan2(paper);
            dan3.drawdan3(paper);
            superfood.drawSuperFood(paper);
            bongbay.drawbongbay(paper);
            chanbay.drawchanbay(paper);
            chanbay2.drawchanbay2(paper);
            //double[] output = network.Run(new double[2] { bong.bongRec[0].X, bong.bongRec[0].Y });
            //if (output[0] > 0.5)
            //{
            //    van.moveLeftvan();
            //}
            //else
            //{
            //    van.moveRightvan();
            //}
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            isRestart = false;
            if (food.foodRec.IntersectsWith(baditem.baditemRec)) { baditem.baditemLocation(randBaditem); }
            if (superfood.superfoodRec.IntersectsWith(baditem.baditemRec)) { baditem.baditemLocation(randBaditem); }
            // nếu bóng_bay chạy hết form thì thua
            if (bongbay.bongbayRec[0].X >= 280) { Restart(); fileIO.WriteGameState(gameIndex, true); }
            //nếu 100<=điểm<200 timerbongbay=true
            if (score >= 100 && score < 200 && stopdraw == false) { timerbongbay.Enabled = true; }
            //neu 200<=diem<400 cho stopdraw=false
            if (score >= 200 && score < 400) { stopdraw = false; }
            //neu 200<=diem<400 timerbongbay=true
            if (score >= 200 && score < 400 && stopdraw == false) { timerbongbay.Enabled = true; }

            if (napdan == true) { toolStripStatusLabelcooldown.Text = "Xong"; }
            else { toolStripStatusLabelcooldown.Text = "Đang cooldown"; }
            toolStripStatusLabelsodan.Text = sodan.ToString();
            start.Text = "";
            sodiemcao.Text = diemcao.ToString();
            sodiem.Text = score.ToString();
            //nếu bóng hoặc đạn va vào bóng_bay thì dừng vẽ chắn_bay và bóng_bay đồng thời tạo mới vị trí của bóng_bay và chắn_bay
            if (bongbay.bongbayRec[0].IntersectsWith(bong.bongRec[0]) || bongbay.bongbayRec[0].IntersectsWith(dan1.danRec1[0]) || bongbay.bongbayRec[0].IntersectsWith(dan2.danRec2[0]) || bongbay.bongbayRec[0].IntersectsWith(dan3.danRec3[0]))
            {
                stopdraw = true;
                timerbongbay.Enabled = false;
                bongbay = new BongBay(); chanbay = new ChanBay(); chanbay2 = new ChanBay2();
            }
            //khi 1 trong 3 viên đạn va vào chắn bay thì tạo mới vị trí cho viên đạn đó
            if (dan1.danRec1[0].IntersectsWith(chanbay.chanbayRec[0])) { dan1 = new Dan1(); }
            if (dan2.danRec2[0].IntersectsWith(chanbay.chanbayRec[0])) { dan2 = new Dan2(); }
            if (dan3.danRec3[0].IntersectsWith(chanbay.chanbayRec[0])) { dan3 = new Dan3(); }
            if (dan1.danRec1[0].IntersectsWith(chanbay2.chanbay2Rec[0])) { dan1 = new Dan1(); }
            if (dan2.danRec2[0].IntersectsWith(chanbay2.chanbay2Rec[0])) { dan2 = new Dan2(); }
            if (dan3.danRec3[0].IntersectsWith(chanbay2.chanbay2Rec[0])) { dan3 = new Dan3(); }
            //khi vị trí của food trùng với vị trí super food thì gọi vị trí mới cho food
            if (food.foodRec.IntersectsWith(superfood.superfoodRec)) { food.foodLocation(randFood); }
            //va cham Bad item
            if (bong.bongRec[0].IntersectsWith(baditem.baditemRec)) { baditem.baditemLocation(randBaditem); if (score >= 10) { score -= 10; } }
            if (dan1.danRec1[0].IntersectsWith(baditem.baditemRec)) { baditem.baditemLocation(randBaditem); if (score >= 10) { score -= 10; } }
            if (dan2.danRec2[0].IntersectsWith(baditem.baditemRec)) { baditem.baditemLocation(randBaditem); if (score >= 10) { score -= 10; } }
            if (dan3.danRec3[0].IntersectsWith(baditem.baditemRec)) { baditem.baditemLocation(randBaditem); if (score >= 10) { score -= 10; } }
            //các va chạm tăng điểm,đạn,số đếm
            if (dan1.danRec1[0].IntersectsWith(food.foodRec)) { score += 10; food.foodLocation(randFood); sodan += 1; dem += 1; }
            if (dan2.danRec2[0].IntersectsWith(food.foodRec)) { score += 10; food.foodLocation(randFood); sodan += 1; dem += 1; }
            if (dan3.danRec3[0].IntersectsWith(food.foodRec)) { score += 10; food.foodLocation(randFood); sodan += 1; dem += 1; }
            if (dan1.danRec1[0].IntersectsWith(superfood.superfoodRec)) { score += 30; superfood = new SuperFood(); sodan += 3; }
            if (dan2.danRec2[0].IntersectsWith(superfood.superfoodRec)) { score += 30; superfood = new SuperFood(); sodan += 3; }
            if (dan3.danRec3[0].IntersectsWith(superfood.superfoodRec)) { score += 30; superfood = new SuperFood(); sodan += 3; }
            if (bong.bongRec[0].IntersectsWith(superfood.superfoodRec))
            {
                superfood = new SuperFood();
                score += 30; sodan += 2;
            }
            if (bong.bongRec[0].IntersectsWith(food.foodRec))
            {
                dem += 1;
                sodan += 1;
                score += 10;
                food.foodLocation(randFood);
            }
            if (van.vanRec[0].IntersectsWith(bong.bongRec[0]))
            {

                if (s == 3) { s = 2; }
                else if (s == 4) { s = 1; }
            }

            //dem den 5 thi goi superfood và cho dem=0 để đếm lại từ đầu
            while (dem == 5) { superfood.superfoodLocation(randSuperFood); dem = 0; }
            //bóng nẩy
            if (timer1.Enabled == true)
            {
                if (s == 2 && bong.bongRec[0].Y >= 23 && bong.bongRec[0].X <= 276) { bong.drawbongRun2(); }
                else if (bong.bongRec[0].Y - 1 < 23 && s == 2) { s = 3; } else if (bong.bongRec[0].X + 1 > 276 && s == 2) { s = 1; }
                if (s == 3 && bong.bongRec[0].X <= 280 && bong.bongRec[0].Y <= 302) { bong.drawbongRun3(); }
                else if (bong.bongRec[0].X + 1 > 276 && s == 3) { s = 4; } else if (bong.bongRec[0].Y + 1 > 303 && s == 3) { Restart(); fileIO.WriteGameState(gameIndex, true); }
                if (s == 1 && bong.bongRec[0].Y >= 23 && bong.bongRec[0].X >= 1) { bong.drawbongRun1(); }
                else if (bong.bongRec[0].Y - 1 < 23 && s == 1) { s = 4; } else if (bong.bongRec[0].X - 1 < 1 && s == 1) { s = 2; }
                if (s == 4 && bong.bongRec[0].Y <= 303 && bong.bongRec[0].X >= 1) { bong.drawbongRun4(); }
                else if (bong.bongRec[0].Y + 1 > 303 && s == 4) { Restart(); fileIO.WriteGameState(gameIndex, true); } else if (bong.bongRec[0].X - 1 < 1 && s == 4) { s = 3; }
            }
            //va chạm bên trái chan bay
            if (bong.bongRec[0].Right.Equals(chanbay.chanbayRec[0].Left + 1) && bong.bongRec[0].IntersectsWith(chanbay.chanbayRec[0]) && s == 2) { s = 1; }
            if (bong.bongRec[0].Right.Equals(chanbay.chanbayRec[0].Left + 1) && bong.bongRec[0].IntersectsWith(chanbay.chanbayRec[0]) && s == 3) { s = 4; }
            //va cham ben phai chan bay
            if (bong.bongRec[0].Left.Equals(chanbay.chanbayRec[0].Right - 1) && bong.bongRec[0].IntersectsWith(chanbay.chanbayRec[0]) && s == 1) { s = 2; }
            if (bong.bongRec[0].Left.Equals(chanbay.chanbayRec[0].Right - 1) && bong.bongRec[0].IntersectsWith(chanbay.chanbayRec[0]) && s == 4) { s = 3; }
            //va cham ben tren chan bay 
            if (bong.bongRec[0].Bottom.Equals(chanbay.chanbayRec[0].Top + 1) && bong.bongRec[0].IntersectsWith(chanbay.chanbayRec[0]) && s == 3) { s = 2; }
            if (bong.bongRec[0].Bottom.Equals(chanbay.chanbayRec[0].Top + 1) && bong.bongRec[0].IntersectsWith(chanbay.chanbayRec[0]) && s == 4) { s = 1; }
            //va cham ben duoi chan bay 
            if (bong.bongRec[0].Top.Equals(chanbay.chanbayRec[0].Bottom - 1) && bong.bongRec[0].IntersectsWith(chanbay.chanbayRec[0]) && s == 2) { s = 3; }
            if (bong.bongRec[0].Top.Equals(chanbay.chanbayRec[0].Bottom - 1) && bong.bongRec[0].IntersectsWith(chanbay.chanbayRec[0]) && s == 1) { s = 4; }
            //va chạm bên trái chan bay 2
            if (bong.bongRec[0].Right.Equals(chanbay2.chanbay2Rec[0].Left + 1) && bong.bongRec[0].IntersectsWith(chanbay2.chanbay2Rec[0]) && s == 2) { s = 1; }
            if (bong.bongRec[0].Right.Equals(chanbay2.chanbay2Rec[0].Left + 1) && bong.bongRec[0].IntersectsWith(chanbay2.chanbay2Rec[0]) && s == 3) { s = 4; }
            //va cham ben phai chan bay 2
            if (bong.bongRec[0].Left.Equals(chanbay2.chanbay2Rec[0].Right - 1) && bong.bongRec[0].IntersectsWith(chanbay2.chanbay2Rec[0]) && s == 1) { s = 2; }
            if (bong.bongRec[0].Left.Equals(chanbay2.chanbay2Rec[0].Right - 1) && bong.bongRec[0].IntersectsWith(chanbay2.chanbay2Rec[0]) && s == 4) { s = 3; }
            //va cham ben tren chan bay2
            if (bong.bongRec[0].Bottom.Equals(chanbay2.chanbay2Rec[0].Top + 1) && bong.bongRec[0].IntersectsWith(chanbay2.chanbay2Rec[0]) && s == 3) { s = 2; }
            if (bong.bongRec[0].Bottom.Equals(chanbay2.chanbay2Rec[0].Top + 1) && bong.bongRec[0].IntersectsWith(chanbay2.chanbay2Rec[0]) && s == 4) { s = 1; }
            //va cham ben duoi chan bay 2
            if (bong.bongRec[0].Top.Equals(chanbay2.chanbay2Rec[0].Bottom - 1) && bong.bongRec[0].IntersectsWith(chanbay2.chanbay2Rec[0]) && s == 2) { s = 3; }
            if (bong.bongRec[0].Top.Equals(chanbay2.chanbay2Rec[0].Bottom - 1) && bong.bongRec[0].IntersectsWith(chanbay2.chanbay2Rec[0]) && s == 1) { s = 4; }
            //bong nay 2 de tang toc do bong
            if (timer1.Enabled == true)
            {
                if (s == 2 && bong.bongRec[0].Y >= 23 && bong.bongRec[0].X <= 276) { bong.drawbongRun2(); }
                else if (bong.bongRec[0].Y - 1 < 23 && s == 2) { s = 3; } else if (bong.bongRec[0].X + 1 > 276 && s == 2) { s = 1; }
                if (s == 3 && bong.bongRec[0].X <= 280 && bong.bongRec[0].Y <= 302) { bong.drawbongRun3(); }
                else if (bong.bongRec[0].X + 1 > 276 && s == 3) { s = 4; } else if (bong.bongRec[0].Y + 1 > 303 && s == 3) { Restart(); fileIO.WriteGameState(gameIndex, true); }
                if (s == 1 && bong.bongRec[0].Y >= 23 && bong.bongRec[0].X >= 1) { bong.drawbongRun1(); }
                else if (bong.bongRec[0].Y - 1 < 23 && s == 1) { s = 4; } else if (bong.bongRec[0].X - 1 < 1 && s == 1) { s = 2; }
                if (s == 4 && bong.bongRec[0].Y <= 303 && bong.bongRec[0].X >= 1) { bong.drawbongRun4(); }
                else if (bong.bongRec[0].Y + 1 > 303 && s == 4) { Restart(); fileIO.WriteGameState(gameIndex, true); } else if (bong.bongRec[0].X - 1 < 1 && s == 4) { s = 3; }
            }//xet va cham lan 2 cho chan bay
            if (bong.bongRec[0].Right.Equals(chanbay.chanbayRec[0].Left + 1) && bong.bongRec[0].IntersectsWith(chanbay.chanbayRec[0]) && s == 2) { s = 1; }
            if (bong.bongRec[0].Right.Equals(chanbay.chanbayRec[0].Left + 1) && bong.bongRec[0].IntersectsWith(chanbay.chanbayRec[0]) && s == 3) { s = 4; }
            if (bong.bongRec[0].Left.Equals(chanbay.chanbayRec[0].Right - 1) && bong.bongRec[0].IntersectsWith(chanbay.chanbayRec[0]) && s == 1) { s = 2; }
            if (bong.bongRec[0].Left.Equals(chanbay.chanbayRec[0].Right - 1) && bong.bongRec[0].IntersectsWith(chanbay.chanbayRec[0]) && s == 4) { s = 3; }
            if (bong.bongRec[0].Bottom.Equals(chanbay.chanbayRec[0].Top + 1) && bong.bongRec[0].IntersectsWith(chanbay.chanbayRec[0]) && s == 3) { s = 2; }
            if (bong.bongRec[0].Bottom.Equals(chanbay.chanbayRec[0].Top + 1) && bong.bongRec[0].IntersectsWith(chanbay.chanbayRec[0]) && s == 4) { s = 1; }
            if (bong.bongRec[0].Top.Equals(chanbay.chanbayRec[0].Bottom - 1) && bong.bongRec[0].IntersectsWith(chanbay.chanbayRec[0]) && s == 2) { s = 3; }
            if (bong.bongRec[0].Top.Equals(chanbay.chanbayRec[0].Bottom - 1) && bong.bongRec[0].IntersectsWith(chanbay.chanbayRec[0]) && s == 1) { s = 4; }
            //xet va cham lan 2 cho chan bay 2
            if (bong.bongRec[0].Right.Equals(chanbay2.chanbay2Rec[0].Left + 1) && bong.bongRec[0].IntersectsWith(chanbay2.chanbay2Rec[0]) && s == 2) { s = 1; }
            if (bong.bongRec[0].Right.Equals(chanbay2.chanbay2Rec[0].Left + 1) && bong.bongRec[0].IntersectsWith(chanbay2.chanbay2Rec[0]) && s == 3) { s = 4; }
            if (bong.bongRec[0].Left.Equals(chanbay2.chanbay2Rec[0].Right - 1) && bong.bongRec[0].IntersectsWith(chanbay2.chanbay2Rec[0]) && s == 1) { s = 2; }
            if (bong.bongRec[0].Left.Equals(chanbay2.chanbay2Rec[0].Right - 1) && bong.bongRec[0].IntersectsWith(chanbay2.chanbay2Rec[0]) && s == 4) { s = 3; }
            if (bong.bongRec[0].Bottom.Equals(chanbay2.chanbay2Rec[0].Top + 1) && bong.bongRec[0].IntersectsWith(chanbay2.chanbay2Rec[0]) && s == 3) { s = 2; }
            if (bong.bongRec[0].Bottom.Equals(chanbay2.chanbay2Rec[0].Top + 1) && bong.bongRec[0].IntersectsWith(chanbay2.chanbay2Rec[0]) && s == 4) { s = 1; }
            if (bong.bongRec[0].Top.Equals(chanbay2.chanbay2Rec[0].Bottom - 1) && bong.bongRec[0].IntersectsWith(chanbay2.chanbay2Rec[0]) && s == 2) { s = 3; }
            if (bong.bongRec[0].Top.Equals(chanbay2.chanbay2Rec[0].Bottom - 1) && bong.bongRec[0].IntersectsWith(chanbay2.chanbay2Rec[0]) && s == 1) { s = 4; }
            //nếu bấm B thì cho timerbanbay =true
            if (keyb == true) { timerdanbay.Enabled = true; }
            //nếu timerbanbay=true thì vẽ đạn bay
            if (timerdanbay.Enabled == true)
            {
                dan1.drawdanRun1(); dan2.drawdanRun2(); dan3.drawdanRun3();
                // nếu đạn bay hết màn hình cho nạp đạn(cooldown), dừng vẽ đạn, tạo mới đạn
                if (dan1.danRec1[0].X <= 0 && dan2.danRec2[0].Y <= 22 && dan3.danRec3[0].X >= 280)
                {
                    napdan = true;
                    timerdanbay.Enabled = false;
                    dan1 = new Dan1();
                    dan2 = new Dan2();
                    dan3 = new Dan3();
                }
            }
            gameTime = (int)watch.ElapsedMilliseconds;
            network.lstgame[gameIndex] = new DataGame(score, gameTime, van.vanRec[0].X, new Point(bong.bongRec[0].X, bong.bongRec[0].Y));
            if (network.runForward(gameIndex))
                van.moveLeftvan();
            else
                van.moveRightvan();
            this.Invalidate();
        }
        //tin hieu ban phim
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //khi bấm B(trong lúc chương trình còn đang chạy,có đạn,đạn đã cooldown) cho vị trí 3 viên đạn = vị trí bóng đồng thời giảm đạn và buộc cooldown đạn
            if (e.KeyData == Keys.B && timer1.Enabled == true && sodan >= 1 && napdan == true)
            {
                dan1.danRec1[0].Y = bong.bongRec[0].Y;
                dan2.danRec2[0].Y = bong.bongRec[0].Y;
                dan3.danRec3[0].Y = bong.bongRec[0].Y;
                dan1.danRec1[0].X = bong.bongRec[0].X;
                dan2.danRec2[0].X = bong.bongRec[0].X;
                dan3.danRec3[0].X = bong.bongRec[0].X;
                keyb = true; sodan -= 1; napdan = false;
            }
            if (e.KeyData == Keys.S) { timer1.Enabled = false; MessageBox.Show("Bạn đã tạm dừng game, bấm phím R để tiếp tục"); }
            if (e.KeyData == Keys.R) { timer1.Enabled = true; }
            if (e.KeyData == Keys.Space && tatspace == true)
            {
                timer1.Enabled = true;
                left = false; right = false;
                start.Text = "";
                tatspace = false;
            }
            if (e.KeyData == Keys.Right && left == false && timer1.Enabled == true)
            {
                right = true; left = false;
                van.moveRightvan();

            }
            if (e.KeyData == Keys.Left && right == false && timer1.Enabled == true)
            {
                left = true; right = false;
                van.moveLeftvan();
            }
            left = false;
            right = false;
            this.Invalidate();

        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            maker.Text = "--  Đọc kĩ hướng dẫn trc khi sd";
            diem.Text = "Điểm:";
        }

        private void hướngDẫnCáchChơiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hướng_dẫn_sử_dụng hdsd = new Hướng_dẫn_sử_dụng();
            hdsd.Show();
        }

        private void thoátGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Bạn có muốn thoát game không", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongbao == DialogResult.Yes) { Application.Exit(); }
        }

        private void timerdanbay_Tick(object sender, EventArgs e)
        {
        }

        private void timerbongbay_Tick(object sender, EventArgs e)
        {
            chanbay.drawchanbayRun(); bongbay.drawbongbayRun(); if (score >= 200 && score <= 500 && stopdraw == false) { chanbay2.drawchanbay2Run(); }
            this.Invalidate();
        }

        void Restart()
        {
            watch.Reset();
            isRestart = true;
            timer1.Enabled = false;
            timerdanbay.Enabled = false;
            timerbongbay.Enabled = false;
            superfood = new SuperFood();
            s = 2;
            tatspace = true;
            dan1 = new Dan1();
            dan2 = new Dan2();
            dan3 = new Dan3();
            sodan = 2; dem = 0;
            diemn = score; //if (diemcao < diemn) { diemcao = diemn;CustomMsgBox.Show("Có muốn lưu danh sử sách hay không? :)))","Bạn Đạt Điểm Cao", "Ok", "Để lần sau"); toolStripStatusLabelpro.Text = caothu; }
            //MessageBox.Show("Thua rồi :)) choi lai de");
            start.Text = "Bấm phím cách để bắt đầu trò chơi";
            score = 0;
            chanbay = new ChanBay();
            bongbay = new BongBay();
            bong = new Bong();
            van = new Van();
            diem.Text = "Điểm:";
            network.breedNetworks(gameIndex);
            //while (true)
            //{
            //    if (fileIO.IsAllGameFailed())
            //    {
            //        Thread.Sleep(1000);
            //        timer1.Enabled = true;
            //        left = false; right = false;
            //        start.Text = "";
            //        tatspace = false;
                    
            //        fileIO.InitState();
            //        break;
            //    }
            //}
            
        }
    }
}
