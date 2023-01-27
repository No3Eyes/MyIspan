using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_Super_Lotto
{
    public partial class Form1 : Form
    {
        int[] Cho = new int[6];           //勾選號碼的存放地(確定六碼)
        int ss ;                          //勾選的特別號存放地(確定一碼)
        int[] Num_Answer = new int[6];    //一般號獎號存放地
        int Num_Sep_Answer;               //特別號獎號存放地


        int[] Num_Choose = new int[38];   
        //勾選的一般號暫存地
        int[] Num_Sep_Choose = new int[8];
        //勾選的特別號暫存地
        int num_Choose_Count = 0;         
        //勾選一般號計數器
        int num_Sep_Choose_Count = 0;     
        //勾選特別號計數器

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e) //按下按鈕
        {
            if (num_Choose_Count == 6 && num_Sep_Choose_Count == 1)
            {
                UrCho();
                Draw_Priz();
                if (Compar() == "銘謝惠顧\t\n歡迎再光臨")
                {
                    Form2 form2 = new Form2(Compar(), Prab()); //按下按鈕呼叫Form2視窗
                                                               //呼叫一個新的Form2視窗後將Form1的值作為參數放入Form2(此時是將Form2當作函數/method使用
                                                               //使得Form2可以讀取Form1產生的值(傳值)
                    form2.ShowDialog();                        //對第二個視窗操作/關閉後才能操作Form1
                }
                else { Form3 form3 = new Form3(Compar(), Prab());form3.ShowDialog(); }
            }
            else { MessageBox.Show("請勾選滿六個一般號碼與一個特別號碼"); }
        }


        private void btn1_Click(object sender, EventArgs e)  //電腦選號按鈕
        {
            Compu();
            
            Draw_Priz();
            if (Compar() == "銘謝惠顧\t\n歡迎再光臨")
            {
                Form2 form2 = new Form2(Compar(), Prab());
                form2.ShowDialog();
            }
            else { Form3 form3 = new Form3(Compar(), Prab()); form3.ShowDialog(); }
        }



        private void UrCho()  //輸出自己選的號碼到txt2，同時將Cho(勾選號存放地)、ss(特別號存放地)賦值
        {
            
            int x = 0;      //填入已選號碼暫存地的計數器 
            for (int i = 0; i < Num_Choose.Length; i++) { if (Num_Choose[i] != 0) {
                    Cho[x] = Num_Choose[i];x += 1; } }
            //把勾選的一般號暫存地(不為零的值；也就是被勾選的數)的東西拉出來
            for(int i=0; i<Num_Sep_Choose.Length; i++) { if (Num_Sep_Choose[i]!=0) {
                    ss = Num_Sep_Choose[i]; } }
            //把勾選的特別號暫存地的東西拉出來
            string y = "勾選號碼為：";
            string z = "特別號碼為：" + Convert.ToString(ss);
            foreach(int i in Cho) { y += i+"  "; }
            //foreach會跑過裡頭每一個元素
            //foreach(<變數> in <Array>){<程式碼>}
            txt2.Text = y+"\t\n"+z;
        }


        //輸出電腦選號碼(包括特別號)到txt2，同時將Cho(勾選號存放地)、ss(特別號存放地)賦值
        private void Compu()  
        {
            Random ran = new Random(Guid.NewGuid().GetHashCode());
            //官網：在大多數 Windows 系統上，在 15 毫秒內創建的隨機對象可能具有相同的種子值。
            //因此儘管在不同的method上的new Random函數，由於運算時間沒有超過15毫秒，所以後面引用的
            //種子碼是相同的，也就導致兩個method輸出同一組隨機數

            //Guid為全域唯一識別碼，由於一般來說不會有相等的Guid，因此可以用來判斷兩物件是否相等
            //通常為128位長，16進制(ex.09a55934- 6d6f- 4ef0- b4bb - e8b8d428a1e8)
            //Guid.NewGuid()  用來產生一組新的Guid

            //猜測：而Random(<其中放的值>)應該是給予Random產生亂數使用的種子碼

            //猜測：GetHahCode是用來將Guid.NewGuid()產生的16進制種子碼轉換成數字以供Random()使用

            for (int i = 0; i < Cho.Length; i++)
            {
                Cho[i] = ran.Next(1, 39);
                //輸出第 i+1 個的隨機數存到Cho中
                for (int j = 0; j < i; j++)
                {
                    if (Cho[i] == Cho[j])
                    {
                        j = 0; Cho[i] = ran.Next(1, 39);
                    }
                }
            }
            //檢查第 i+1 個隨機數有沒有和前面1~i個重複，如果有，把第 i+1 個重新生成，再檢查一遍
            Array.Sort(Cho);
            string Ans = "電腦選號為：";
            string Sep_Ans = "特別號碼為：";
            ss = ran.Next(1, 9); //輸出特別號的隨機數，存到Num_Sep_Answer中
            foreach (int i in Cho) { Ans += i + "  "; }
            Sep_Ans += ss;
            txt2.Text = Ans + " \t\n " + Sep_Ans;
        }

        private void Draw_Priz()  //輸出中獎號碼(包括特別號)到txt3，同時將Num_Answer、Num_Sep_Answer賦值
        {
            Random random = new Random();  
            for(int i=0;i< Num_Answer.Length; i++) {
                Num_Answer[i] = random.Next(1, 39);
            //輸出第 i+1 個的隨機數存到Num_Answer中
            for(int j = 0; j < i; j++) { if (Num_Answer[i] == Num_Answer[j]) {
                        j = 0; Num_Answer[i] = random.Next(1, 39);
                    }}}
            //檢查第 i+1 個隨機數有沒有和前面1~i個重複，如果有，把第 i+1 個重新生成，再檢查一遍
            Array.Sort(Num_Answer);
            string Ans = "中獎號碼為：";
            string Sep_Ans = "特別號碼為：";
            Num_Sep_Answer=random.Next(1,9); //輸出特別號的隨機數，存到Num_Sep_Answer中
            foreach (int i in Num_Answer) { Ans += i + "  "; }
            Sep_Ans += Num_Sep_Answer;
            txt3.Text=Ans+" \t\n "+Sep_Ans;
        }

        

        private string Compar() {  //比較中多大獎項，後面會做為參數放入   form2(<Compar>,<Prab>)
            int count = 0;   //一般號中獎結果計數器
            int sep_count=0; //特別號中獎結果計數器
            for(int i = 0; i < Cho.Length; i++) //因為勾選號與獎號都已確定不重複，因此可以直接兩個for比較
            {
                for(int j=0;j<Cho.Length; j++)
                {
                    if(Cho[i] == Num_Answer[j]) { count++; }
                }
            }
            if (ss == Num_Sep_Answer) { sep_count += 1; }
            if (count == 6 && sep_count == 1) { return "恭喜您中了頭獎"; }
            else if (count == 6 && sep_count == 0) { return "恭喜您\t\n中了貳獎"; }
            else if (count == 5 && sep_count == 1) { return "恭喜您\t\n中了參獎"; }
            else if (count == 5 && sep_count == 0) { return "恭喜您\t\n中了肆獎"; }
            else if (count == 4 && sep_count == 1) { return "恭喜您\t\n中了伍獎"; }
            else if (count == 4 && sep_count == 0) { return "恭喜您\t\n中了陸獎"; }
            else if (count == 3 && sep_count == 1) { return "恭喜您\t\n中了柒獎"; }
            else if (count == 2 && sep_count == 1) { return "恭喜您\t\n中了捌獎"; }
            else if (count == 3 && sep_count == 0) { return "恭喜您\t\n中了玖獎"; }
            else if (count == 1 && sep_count == 1) { return "恭喜您\t\n中了普獎"; }
            else { return "銘謝惠顧\t\n歡迎再光臨"; }
        }


        
        private string Prab()  //輸出中獎概率，後面作為參數放入   form2(<Compar>,<Prab>)
        {
            int count = 0;
            int sep_count = 0;
            for (int i = 0; i < Cho.Length; i++)
            {
                for (int j = 0; j < Cho.Length; j++)
                {
                    if (Cho[i] == Num_Answer[j]) { count++; }
                }
            }
            if (ss == Num_Sep_Answer) { sep_count += 1; }
            if (count == 6 && sep_count == 1) { return "頭獎機率約為 4.5 x 10^(-6)%"; }
            else if (count == 6 && sep_count == 0) { return "貳獎機率約為 3.2 x 10^(-5)%"; }
            else if (count == 5 && sep_count == 1) { return "參獎機率約為 8.7 x 10^(-4)%"; }
            else if (count == 5 && sep_count == 0) { return "肆獎機率約為 6 x 10^(-3)%"; }
            else if (count == 4 && sep_count == 1) { return "伍獎機率約為 0.0337%"; }
            else if (count == 4 && sep_count == 0) { return "陸獎機率約為 0.2359%"; }
            else if (count == 3 && sep_count == 1) { return "柒獎機率約為 0.4491%"; }
            else if (count == 2 && sep_count == 1) { return "捌獎機率約為 2.4423%"; }
            else if (count == 3 && sep_count == 0) { return "玖獎機率約為 3.1442%"; }
            else if (count == 1 && sep_count == 1) { return "普獎機率約為 5.4708%"; }
            else { return "槓龜機率約為 88.217%"; }
        }




        //特別號的勾選狀況
        private void SepCbx1_CheckedChanged(object sender, EventArgs e)
        {                              //若被選取，計數器+1，將第一碼輸出成1
            if (SepCbx1.Checked) { num_Sep_Choose_Count += 1; Num_Sep_Choose[0] = 1; }
            else { num_Sep_Choose_Count -= 1; Num_Sep_Choose[0] = 0; }
                             //否則，計數器-1，將第一碼回復成0
            if (num_Sep_Choose_Count > 1) { MessageBox.Show("特別號請勿勾選超過一個數字");
                SepCbx1.Checked = false;
            }
        }

        private void SepCbx2_CheckedChanged(object sender, EventArgs e)
        {
            if (SepCbx2.Checked) { num_Sep_Choose_Count += 1; Num_Sep_Choose[1] = 2; }
            else { num_Sep_Choose_Count -= 1; Num_Sep_Choose[1] = 0; }
            if (num_Sep_Choose_Count > 1)
            {
                MessageBox.Show("特別號請勿勾選超過一個數字");
                SepCbx2.Checked = false;
            }
        }

        private void SepCbx3_CheckedChanged(object sender, EventArgs e)
        {
            if (SepCbx3.Checked) { num_Sep_Choose_Count += 1; Num_Sep_Choose[2] = 3; }
            else { num_Sep_Choose_Count -= 1; Num_Sep_Choose[2] = 0; }
            if (num_Sep_Choose_Count > 1)
            {
                MessageBox.Show("特別號請勿勾選超過一個數字");
                SepCbx3.Checked = false;
            }
        }

        private void SepCbx4_CheckedChanged(object sender, EventArgs e)
        {
            if (SepCbx4.Checked) { num_Sep_Choose_Count += 1; Num_Sep_Choose[3] = 4; }
            else { num_Sep_Choose_Count -= 1; Num_Sep_Choose[3] = 0; }
            if (num_Sep_Choose_Count > 1)
            {
                MessageBox.Show("特別號請勿勾選超過一個數字");
                SepCbx4.Checked = false;
            }
        }

        private void SepCbx5_CheckedChanged(object sender, EventArgs e)
        {
            if (SepCbx5.Checked) { num_Sep_Choose_Count += 1; Num_Sep_Choose[4] = 5; }
            else { num_Sep_Choose_Count -= 1; Num_Sep_Choose[4] = 0; }
            if (num_Sep_Choose_Count > 1)
            {
                MessageBox.Show("特別號請勿勾選超過一個數字");
                SepCbx5.Checked = false;
            }
        }

        private void SepCbx6_CheckedChanged(object sender, EventArgs e)
        {
            if (SepCbx6.Checked) { num_Sep_Choose_Count += 1; Num_Sep_Choose[5] = 6; }
            else { num_Sep_Choose_Count -= 1; Num_Sep_Choose[5] = 0; }
            if (num_Sep_Choose_Count > 1)
            {
                MessageBox.Show("特別號請勿勾選超過一個數字");
                SepCbx6.Checked = false;
            }
        }

        private void SepCbx7_CheckedChanged(object sender, EventArgs e)
        {
            if (SepCbx7.Checked) { num_Sep_Choose_Count += 1; Num_Sep_Choose[6] = 7; }
            else { num_Sep_Choose_Count -= 1; Num_Sep_Choose[6] = 0; }
            if (num_Sep_Choose_Count > 1)
            {
                MessageBox.Show("特別號請勿勾選超過一個數字");
                SepCbx7.Checked = false;
            }
        }

        private void SepCbx8_CheckedChanged(object sender, EventArgs e)
        {
            if (SepCbx8.Checked) { num_Sep_Choose_Count += 1; Num_Sep_Choose[7] = 8; }
            else { num_Sep_Choose_Count -= 1; Num_Sep_Choose[7] = 0; }
            if (num_Sep_Choose_Count > 1)
            {
                MessageBox.Show("特別號請勿勾選超過一個數字");
                SepCbx8.Checked = false;
            }
        }







        //一般號碼的勾選狀況
        private void cbx1_CheckedChanged(object sender, EventArgs e)
        {                      //若被選取，計數器+1，將第一碼輸出成1
            if (cbx1.Checked) { num_Choose_Count += 1; Num_Choose[0] = 1;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }                  //否則，計數器-1，將第一碼回復成0
            else { num_Choose_Count -= 1; Num_Choose[0] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if(num_Choose_Count > 6) { MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx1.Checked = false;
            }
        }
        private void cbx2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx2.Checked) { num_Choose_Count += 1; Num_Choose[1] = 2;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[1] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx2.Checked = false;
            }
        }

        private void cbx3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx3.Checked) { num_Choose_Count += 1; Num_Choose[2] = 3;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[2] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx3.Checked = false;
            }
        }

        private void cbx4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx4.Checked) { num_Choose_Count += 1; Num_Choose[3] = 4;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[3] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx4.Checked = false;
            }
        }

        private void cbx5_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx5.Checked) { num_Choose_Count += 1; Num_Choose[4] = 5;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[4] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx5.Checked = false;
            }
        }

        private void cbx6_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx6.Checked) { num_Choose_Count += 1; Num_Choose[5] = 6;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[5] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx6.Checked = false;
            }
        }

        private void cbx7_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx7.Checked) { num_Choose_Count += 1; Num_Choose[6] = 7;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[6] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx7.Checked = false;
            }
        }

        private void cbx8_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx8.Checked) { num_Choose_Count += 1; Num_Choose[7] = 8;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[7] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx8.Checked = false;
            }
        }

        private void cbx9_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx9.Checked) { num_Choose_Count += 1; Num_Choose[8] = 9;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[8] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx9.Checked = false;
            }
        }

        private void cbx10_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx10.Checked) { num_Choose_Count += 1; Num_Choose[9] = 10;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[9] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx10.Checked = false;
            }
        }

        private void cbx11_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx11.Checked) { num_Choose_Count += 1; Num_Choose[10] = 11;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[10] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx11.Checked = false;
            }
        }

        private void cbx12_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx12.Checked) { num_Choose_Count += 1; Num_Choose[11] = 12;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[11] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx12.Checked = false;
            }
        }

        private void cbx13_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx13.Checked) { num_Choose_Count += 1; Num_Choose[12] = 13;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[12] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx13.Checked = false;
            }
        }

        private void cbx14_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx14.Checked) { num_Choose_Count += 1; Num_Choose[13] = 14;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[13] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx14.Checked = false;
            }
        }

        private void cbx15_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx15.Checked) { num_Choose_Count += 1; Num_Choose[14] = 15;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[14] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx15.Checked = false;
            }
        }

        private void cbx16_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx16.Checked) { num_Choose_Count += 1; Num_Choose[15] = 16;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[15] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx16.Checked = false;
            }
        }

        private void cbx17_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx17.Checked) { num_Choose_Count += 1; Num_Choose[16] = 17; 
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼"; }
            else { num_Choose_Count -= 1; Num_Choose[16] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx17.Checked = false;
            }
        }

        private void cbx18_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx18.Checked) { num_Choose_Count += 1; Num_Choose[17] = 18;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[17] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx18.Checked = false;
            }
        }

        private void cbx19_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx19.Checked) { num_Choose_Count += 1; Num_Choose[18] = 19;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[18] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx19.Checked = false;
            }
        }

        private void cbx20_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx20.Checked) { num_Choose_Count += 1; Num_Choose[19] = 20;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[19] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx20.Checked = false;
            }
        }

        private void cbx21_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx21.Checked) { num_Choose_Count += 1; Num_Choose[20] = 21;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[20] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx21.Checked = false;
            }
        }

        private void cbx22_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx22.Checked) { num_Choose_Count += 1; Num_Choose[21] = 22;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[21] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx22.Checked = false;
            }
        }

        private void cbx23_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx23.Checked) { num_Choose_Count += 1; Num_Choose[22] = 23;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[22] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx23.Checked = false;
            }
        }

        private void cbx24_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx24.Checked) { num_Choose_Count += 1; Num_Choose[23] = 24;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[23] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx24.Checked = false;
            }
        }

        private void cbx25_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx25.Checked) { num_Choose_Count += 1; Num_Choose[24] = 25;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[24] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx25.Checked = false;
            }
        }

        private void cbx26_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx26.Checked) { num_Choose_Count += 1; Num_Choose[25] = 26;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[25] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx26.Checked = false;
            }
        }

        private void cbx27_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx27.Checked) { num_Choose_Count += 1; Num_Choose[26] = 27;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[26] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx27.Checked = false;
            }
        }

        private void cbx28_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx28.Checked) { num_Choose_Count += 1; Num_Choose[27] = 28;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[27] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx28.Checked = false;
            }
        }

        private void cbx29_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx29.Checked) { num_Choose_Count += 1; Num_Choose[28] = 29;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[28] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx29.Checked = false;
            }
        }

        private void cbx30_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx30.Checked) { num_Choose_Count += 1; Num_Choose[29] = 30;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[29] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx30.Checked = false;
            }
        }

        private void cbx31_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx31.Checked) { num_Choose_Count += 1; Num_Choose[30] = 31;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[30] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx31.Checked = false;
            }
        }

        private void cbx32_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx32.Checked) { num_Choose_Count += 1; Num_Choose[31] = 32;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[31] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx32.Checked = false;
            }
        }

        private void cbx33_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx33.Checked) { num_Choose_Count += 1; Num_Choose[32] = 33;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[32] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx33.Checked = false;
            }
        }

        private void cbx34_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx34.Checked) { num_Choose_Count += 1; Num_Choose[33] = 34;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[33] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx34.Checked = false;
            }
        }

        private void cbx35_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx35.Checked) { num_Choose_Count += 1; Num_Choose[34] = 35;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[34] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx35.Checked = false;
            }
        }

        private void cbx36_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx36.Checked) { num_Choose_Count += 1; Num_Choose[35] = 36;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[35] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx36.Checked = false;
            }
        }

        private void cbx37_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx37.Checked) { num_Choose_Count += 1; Num_Choose[36] = 37;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[36] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx37.Checked = false;
            }
        }

        private void cbx38_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx38.Checked) { num_Choose_Count += 1; Num_Choose[37] = 38;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            else { num_Choose_Count -= 1; Num_Choose[37] = 0;
                txt1.Text = "已選取 " + Convert.ToString(num_Choose_Count) + " 個一般號碼";
            }
            if (num_Choose_Count > 6)
            {
                MessageBox.Show("一般號碼請勿勾選超過六個數字");
                cbx38.Checked = false;
            }
        }

        

        private void lbl2_Click(object sender, EventArgs e)
        {

        }
    }
}
