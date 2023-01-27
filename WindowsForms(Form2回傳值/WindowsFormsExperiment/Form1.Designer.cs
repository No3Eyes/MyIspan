namespace WindowsFormsExperiment
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_in_Form1 = new System.Windows.Forms.TextBox();
            this.btn_in_Form1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(257, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(475, 60);
            this.label1.TabIndex = 2;
            this.label1.Text = "Form2傳回來的值";
            // 
            // txt_in_Form1
            // 
            this.txt_in_Form1.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txt_in_Form1.Location = new System.Drawing.Point(267, 351);
            this.txt_in_Form1.Name = "txt_in_Form1";
            this.txt_in_Form1.Size = new System.Drawing.Size(453, 55);
            this.txt_in_Form1.TabIndex = 3;
            // 
            // btn_in_Form1
            // 
            this.btn_in_Form1.Font = new System.Drawing.Font("新細明體", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_in_Form1.Location = new System.Drawing.Point(12, 12);
            this.btn_in_Form1.Name = "btn_in_Form1";
            this.btn_in_Form1.Size = new System.Drawing.Size(469, 125);
            this.btn_in_Form1.TabIndex = 4;
            this.btn_in_Form1.Text = "生成Form2";
            this.btn_in_Form1.UseVisualStyleBackColor = true;
            this.btn_in_Form1.Click += new System.EventHandler(this.btn_in_Form1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(777, 431);
            this.Controls.Add(this.btn_in_Form1);
            this.Controls.Add(this.txt_in_Form1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_in_Form1;
        private System.Windows.Forms.Button btn_in_Form1;
    }
}

