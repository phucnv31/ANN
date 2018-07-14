namespace pinball
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.diem = new System.Windows.Forms.ToolStripStatusLabel();
            this.sodiem = new System.Windows.Forms.ToolStripStatusLabel();
            this.maker = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.start = new System.Windows.Forms.Label();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.highscore = new System.Windows.Forms.ToolStripStatusLabel();
            this.sodiemcao = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelpro = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelsodan = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip4 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelcooldown = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hướngDẫnCáchChơiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnCáchChơiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chưaNghĩRavToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerdanbay = new System.Windows.Forms.Timer(this.components);
            this.timerbongbay = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.statusStrip3.SuspendLayout();
            this.statusStrip4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.DimGray;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diem,
            this.sodiem,
            this.maker,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 361);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(289, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // diem
            // 
            this.diem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.diem.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.diem.Name = "diem";
            this.diem.Size = new System.Drawing.Size(42, 17);
            this.diem.Text = "Điểm:";
            // 
            // sodiem
            // 
            this.sodiem.BackColor = System.Drawing.Color.White;
            this.sodiem.Name = "sodiem";
            this.sodiem.Size = new System.Drawing.Size(13, 17);
            this.sodiem.Text = "0";
            // 
            // maker
            // 
            this.maker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.maker.Name = "maker";
            this.maker.Size = new System.Drawing.Size(209, 17);
            this.maker.Text = "--  Đọc kĩ hướng dẫn trc khi sử dụng :)";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 15);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // start
            // 
            this.start.AutoSize = true;
            this.start.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.start.Location = new System.Drawing.Point(12, 87);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(272, 18);
            this.start.TabIndex = 1;
            this.start.Text = "Bấm phím cách để bắt đầu trò chơi";
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.DimGray;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highscore,
            this.sodiemcao,
            this.toolStripStatusLabelpro});
            this.statusStrip2.Location = new System.Drawing.Point(0, 339);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(289, 22);
            this.statusStrip2.TabIndex = 2;
            this.statusStrip2.Text = "Điểm Cao:";
            // 
            // highscore
            // 
            this.highscore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.highscore.Name = "highscore";
            this.highscore.Size = new System.Drawing.Size(62, 17);
            this.highscore.Text = "Điểm Cao:";
            // 
            // sodiemcao
            // 
            this.sodiemcao.BackColor = System.Drawing.Color.White;
            this.sodiemcao.Name = "sodiemcao";
            this.sodiemcao.Size = new System.Drawing.Size(13, 17);
            this.sodiemcao.Text = "0";
            // 
            // toolStripStatusLabelpro
            // 
            this.toolStripStatusLabelpro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.toolStripStatusLabelpro.Name = "toolStripStatusLabelpro";
            this.toolStripStatusLabelpro.Size = new System.Drawing.Size(94, 17);
            this.toolStripStatusLabelpro.Text = "Chưa có cao thủ";
            // 
            // statusStrip3
            // 
            this.statusStrip3.BackColor = System.Drawing.Color.DimGray;
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelsodan});
            this.statusStrip3.Location = new System.Drawing.Point(0, 317);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(289, 22);
            this.statusStrip3.TabIndex = 3;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(90, 17);
            this.toolStripStatusLabel2.Text = "Số Đạn Còn Lại:";
            // 
            // toolStripStatusLabelsodan
            // 
            this.toolStripStatusLabelsodan.BackColor = System.Drawing.Color.White;
            this.toolStripStatusLabelsodan.Name = "toolStripStatusLabelsodan";
            this.toolStripStatusLabelsodan.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabelsodan.Text = "2";
            // 
            // statusStrip4
            // 
            this.statusStrip4.BackColor = System.Drawing.Color.DimGray;
            this.statusStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel4,
            this.toolStripStatusLabelcooldown});
            this.statusStrip4.Location = new System.Drawing.Point(0, 295);
            this.statusStrip4.Name = "statusStrip4";
            this.statusStrip4.Size = new System.Drawing.Size(289, 22);
            this.statusStrip4.TabIndex = 4;
            this.statusStrip4.Text = "statusStrip4";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel4.Text = "Cooldown:";
            // 
            // toolStripStatusLabelcooldown
            // 
            this.toolStripStatusLabelcooldown.BackColor = System.Drawing.Color.White;
            this.toolStripStatusLabelcooldown.Name = "toolStripStatusLabelcooldown";
            this.toolStripStatusLabelcooldown.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabelcooldown.Text = "Xong";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DimGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hướngDẫnCáchChơiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(289, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hướngDẫnCáchChơiToolStripMenuItem
            // 
            this.hướngDẫnCáchChơiToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.hướngDẫnCáchChơiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hướngDẫnCáchChơiToolStripMenuItem1,
            this.thoátGameToolStripMenuItem,
            this.chưaNghĩRavToolStripMenuItem});
            this.hướngDẫnCáchChơiToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.hướngDẫnCáchChơiToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hướngDẫnCáchChơiToolStripMenuItem.Name = "hướngDẫnCáchChơiToolStripMenuItem";
            this.hướngDẫnCáchChơiToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.hướngDẫnCáchChơiToolStripMenuItem.Text = "Menu";
            // 
            // hướngDẫnCáchChơiToolStripMenuItem1
            // 
            this.hướngDẫnCáchChơiToolStripMenuItem1.Name = "hướngDẫnCáchChơiToolStripMenuItem1";
            this.hướngDẫnCáchChơiToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.hướngDẫnCáchChơiToolStripMenuItem1.Size = new System.Drawing.Size(249, 22);
            this.hướngDẫnCáchChơiToolStripMenuItem1.Text = "Hướng dẫn cách chơi";
            this.hướngDẫnCáchChơiToolStripMenuItem1.Click += new System.EventHandler(this.hướngDẫnCáchChơiToolStripMenuItem1_Click);
            // 
            // thoátGameToolStripMenuItem
            // 
            this.thoátGameToolStripMenuItem.Name = "thoátGameToolStripMenuItem";
            this.thoátGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.thoátGameToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.thoátGameToolStripMenuItem.Text = "Thoát game";
            this.thoátGameToolStripMenuItem.Click += new System.EventHandler(this.thoátGameToolStripMenuItem_Click);
            // 
            // chưaNghĩRavToolStripMenuItem
            // 
            this.chưaNghĩRavToolStripMenuItem.Name = "chưaNghĩRavToolStripMenuItem";
            this.chưaNghĩRavToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.chưaNghĩRavToolStripMenuItem.Text = "chưa nghĩ ra :v";
            // 
            // timerdanbay
            // 
            this.timerdanbay.Interval = 1;
            // 
            // timerbongbay
            // 
            this.timerbongbay.Interval = 50;
            this.timerbongbay.Tick += new System.EventHandler(this.timerbongbay_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 383);
            this.Controls.Add(this.statusStrip4);
            this.Controls.Add(this.statusStrip3);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.start);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "game";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            this.statusStrip4.ResumeLayout(false);
            this.statusStrip4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel diem;
        private System.Windows.Forms.ToolStripStatusLabel sodiem;
        private System.Windows.Forms.Label start;
        private System.Windows.Forms.ToolStripStatusLabel maker;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel highscore;
        private System.Windows.Forms.ToolStripStatusLabel sodiemcao;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelsodan;
        private System.Windows.Forms.StatusStrip statusStrip4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelcooldown;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hướngDẫnCáchChơiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hướngDẫnCáchChơiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thoátGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chưaNghĩRavToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelpro;
        private System.Windows.Forms.Timer timerdanbay;
        private System.Windows.Forms.Timer timerbongbay;
    }
}

