namespace MiddleCase
{
    partial class Gacha
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPoint = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.panelResult = new System.Windows.Forms.Panel();
            this.lblPrize = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblLogginFirst = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSaleTimes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::MiddleCase.Properties.Resources.coin;
            this.pictureBox1.Location = new System.Drawing.Point(594, 98);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(584, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 60);
            this.label1.TabIndex = 2;
            this.label1.Text = "抽獎點數";
            // 
            // lblPoint
            // 
            this.lblPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPoint.AutoSize = true;
            this.lblPoint.Font = new System.Drawing.Font("新細明體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPoint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(30)))), ((int)(((byte)(200)))));
            this.lblPoint.Location = new System.Drawing.Point(720, 127);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(107, 60);
            this.lblPoint.TabIndex = 3;
            this.lblPoint.Text = "XX";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("新細明體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStart.Location = new System.Drawing.Point(139, 447);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(315, 110);
            this.btnStart.TabIndex = 15;
            this.btnStart.Text = "開始遊戲";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panelResult
            // 
            this.panelResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panelResult.Controls.Add(this.lblPrize);
            this.panelResult.Location = new System.Drawing.Point(108, 98);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(443, 301);
            this.panelResult.TabIndex = 36;
            this.panelResult.Tag = "";
            // 
            // lblPrize
            // 
            this.lblPrize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrize.Font = new System.Drawing.Font("新細明體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPrize.ForeColor = System.Drawing.Color.Gold;
            this.lblPrize.Location = new System.Drawing.Point(38, 118);
            this.lblPrize.Name = "lblPrize";
            this.lblPrize.Size = new System.Drawing.Size(388, 144);
            this.lblPrize.TabIndex = 40;
            this.lblPrize.Text = "請開始遊戲";
            this.lblPrize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("新細明體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStop.Location = new System.Drawing.Point(490, 447);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(182, 110);
            this.btnStop.TabIndex = 15;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(720, 517);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 78);
            this.label6.TabIndex = 37;
            this.label6.Text = "規則說明:\r\n按下開始遊戲後消耗一點抽獎點數\r\n若在中央螢幕顯示紅色時按下即為中獎\r\n中獎後當次消費打九折\r\n此打折次數於同一筆消費中可以疊加\r\n註:中獎概率約為" +
    " 1/20";
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblLogginFirst
            // 
            this.lblLogginFirst.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLogginFirst.AutoSize = true;
            this.lblLogginFirst.Font = new System.Drawing.Font("新細明體", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblLogginFirst.Location = new System.Drawing.Point(220, 240);
            this.lblLogginFirst.Name = "lblLogginFirst";
            this.lblLogginFirst.Size = new System.Drawing.Size(530, 120);
            this.lblLogginFirst.TabIndex = 40;
            this.lblLogginFirst.Text = "請先登入";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(566, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 60);
            this.label2.TabIndex = 38;
            this.label2.Text = "中獎次數";
            // 
            // lblSaleTimes
            // 
            this.lblSaleTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaleTimes.AutoSize = true;
            this.lblSaleTimes.Font = new System.Drawing.Font("新細明體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSaleTimes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(30)))), ((int)(((byte)(200)))));
            this.lblSaleTimes.Location = new System.Drawing.Point(720, 349);
            this.lblSaleTimes.Name = "lblSaleTimes";
            this.lblSaleTimes.Size = new System.Drawing.Size(107, 60);
            this.lblSaleTimes.TabIndex = 39;
            this.lblSaleTimes.Text = "XX";
            // 
            // Gacha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(970, 600);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblLogginFirst);
            this.Controls.Add(this.lblSaleTimes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.panelResult);
            this.Controls.Add(this.lblPoint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Gacha";
            this.Text = "Gacha";
            this.Load += new System.EventHandler(this.Gacha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelResult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblPrize;
        private System.Windows.Forms.Label lblLogginFirst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSaleTimes;
    }
}