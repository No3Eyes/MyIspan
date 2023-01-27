using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupperLotto_2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> Number = new List<int>(); //所選號碼
        int sep=0;                          //所選特別號
        int[] Prize = new int[6];           //一般獎號
        int sepP;                           //特別獎號
        int cCount = 0;//計算勾選數量是否超過上限的計數器
        int sCount = 0;
        string Draw = "您勾選的號碼為:";
        int SeePrize = 0;
        int[] Anwser = new int[2];
        List<int> CompuList = new List<int>();





        private void Form1_Load(object sender, EventArgs e)
        {
            MakePrize();
            foreach (Control c in groupBox1.Controls)
            {
                ((CheckBox)c).CheckedChanged += new EventHandler(checkbox_check_changed);
                ((CheckBox)c).Cursor = Cursors.Hand;
                ((CheckBox)c).ForeColor = System.Drawing.Color.FromArgb(30, 60, 255);
            }
            foreach (Control c in groupBox2.Controls)
            {
                ((CheckBox)c).CheckedChanged += new EventHandler(checkbox_check_changed2);
                ((CheckBox)c).Cursor = Cursors.Hand;
                ((CheckBox)c).ForeColor = System.Drawing.Color.FromArgb(30, 60, 255);
            }
        }


        //先定義一個方法將CheckBox的上限限制住且輸出值到list(我第一版威力彩寫在每個CheckBox的內容)
        private void checkbox_check_changed(object sender, EventArgs e)
        {
            //物件參數,  用於紀錄物件傳遞訊息的參數(在此就是勾選與否)
            CheckBox c = sender as CheckBox;   //將參數c先宣告為CheckBox，因method只定義參數為object

            //檢查計數器的值，超過指定上限跳出 MessageBox提醒並取消勾選
            if (c.Checked)
            {
                cCount++;
                if (cCount > 6)
                {
                    MessageBox.Show("勾選數量請在六以下");
                    c.Checked = false;
                    return;
                }
                Number.Add(Convert.ToInt32(c.Text));
                Number.Sort();
                string TempString = "";
                for (int i = 0; i < Number.Count; i++)
                {
                    if (i != Number.Count - 1)
                    {
                        TempString += Convert.ToString(Number[i]) + "、";
                    }
                    else { TempString += Convert.ToString(Number[i]); }
                }
                lblNor.Text = TempString;
            }
            //勾選後計數器+1，反之-1
            else
            {
                cCount--;
                Number.Remove(Convert.ToInt32(c.Text));
                Number.Sort();
                string TempString = "";
                for (int i = 0; i < Number.Count; i++)
                {
                    if (i != Number.Count - 1)
                    {
                        TempString += Convert.ToString(Number[i]) + "、";
                    }
                    else { TempString += Convert.ToString(Number[i]); }
                }
                lblNor.Text = TempString;
            }
        }
        private void checkbox_check_changed2(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            if (c.Checked)
            {
                sCount++;
                if (sCount > 1)
                {
                    MessageBox.Show("特別號勾選數量請在一以下");
                    c.Checked = false;
                    return;
                }
                sep = Convert.ToInt32(c.Text);
                lblSep.Text = Convert.ToString(sep);
            }
            //勾選後計數器+1，反之-1
            else
            {
                sCount--;
                lblSep.Text = Convert.ToString(sep);
            }
            //if (c.Checked && sCount > 1) { MessageBox.Show("特別號勾選數量請在一以下"); c.Checked = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Priz = 0;
            bool Sep;
            if(Number.Count==6 && sep != 0)
            {
                for(int i = 0; i < 6; i++)
                {
                    for(int j = 0; j < 6; j++)
                    {
                        if (Number[i] == Prize[j]) { Priz++; }
                    }
                }
                if (sep == sepP) { Sep= true; }
                else { Sep = false; }
                Form2 form2 = new Form2(Priz,Sep);
                form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("請選滿一般號六個與特別號一個");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] TempRan = Compu();
            cleanCheckboxes();
            foreach (Control c in groupBox1.Controls)
            {
                if (Array.IndexOf(TempRan, Convert.ToInt32(((CheckBox)c).Text)) != -1)
                {
                    ((CheckBox)c).Checked= true;
                }
            }
            foreach (Control c in groupBox2.Controls)
            {
                Random ran = new Random(Guid.NewGuid().GetHashCode());
                int TempS = ran.Next(1,9);
                if (Convert.ToInt32(((CheckBox)c).Text) == TempS)
                {
                    ((CheckBox)c).Checked = true;
                }
                lblSep.Text = Convert.ToString(TempS);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }


        //產生獎號放在 Prize[]和 sepP 中
        private void MakePrize()
        {
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                Prize[i] = rnd.Next(1, 39);
                for (int j = 0; j < i; j++)
                {
                    if (Prize[i] == Prize[j]) { Prize[i] = rnd.Next(1, 39); j = 0; }
                }
            }
            Array.Sort(Prize);
            sepP = rnd.Next(1, 9);
        }


        //比較有沒有中獎，將結果輸出到Anwser
        private void Compare()
        {
            var a = Number.ToArray().Intersect(Prize);
            int x = 0;
            foreach (int i in a) { x++; }  //普通獎中幾個
            int b;
            if (sepP == sep) { b = 1; } else { b = 0; }
            Anwser[0] = x;
            Anwser[1] = b;
        }


        private int[] Compu()
        {
            Random ran = new Random(Guid.NewGuid().GetHashCode());
            int[] x = new int[6];
            for (int i = 0; i < 6; i++)
            {
                x[i] = ran.Next(1, 39); for (int j = 0; j < i; j++)
                {
                    if (x[i] == x[j]) { x[i] = ran.Next(1, 39); j = 0; }
                }
            }
            return x;
        }

        private void lbl_prize_Click(object sender, EventArgs e)
        {
            string TempP = "";
            for (int i = 0; i < Prize.Length; i++)
            {
                if (i != Prize.Length - 1) { TempP += Prize[i].ToString() + "、"; }
                else { TempP += Prize[i].ToString(); }
            }
            if (SeePrize % 2 == 0)
            {
                timer1.Start();
                lbl_prize.Text = "一般號：\n"+TempP+"\n特別號："+sepP;
            }
            else
            {
                timer1.Stop();
                lbl_prize.Text = "點我偷看獎號";
                lbl_prize.BackColor = Color.FromArgb(50, 255, 255);
            }
            SeePrize++;
        }

        int[] TempColor = new int[3];
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            TempColor[0] = rnd.Next(0, 255);
            TempColor[1] = rnd.Next(0, 255);
            TempColor[2] = rnd.Next(0, 255);
            lbl_prize.BackColor = Color.FromArgb(TempColor[0], TempColor[1], TempColor[2]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cleanCheckboxes();
        }
        public void cleanCheckboxes()
        {
            foreach (Control c in groupBox1.Controls)
            {
                ((CheckBox)c).Checked = false;
            }
            foreach (Control c in groupBox2.Controls)
            {
                ((CheckBox)c).Checked = false;
            }
            lblNor.Text = "選取的一般號碼";
            lblSep.Text = "特別號";
        }
    }
}
