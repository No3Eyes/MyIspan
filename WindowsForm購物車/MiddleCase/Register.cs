using MiddleCase.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace MiddleCase
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        string strDBconnectionString = "";

        public delegate void CloseRegister();
        public event CloseRegister TeleToForm1;


        void HideStar(Label l,bool b) { if (b) { l.Text = ""; } else { l.Text = "*"; } }  //星號隱藏void
        private void Register_Load(object sender, EventArgs e)
        {
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            strDBconnectionString = scsb.ToString();

            Variable.TempCartThing.Clear();

            txtPhone1.Clear();txtPhone2.Clear();txtPhone3.Clear();
            txtPassw.Clear();txtPasswCheck.Clear();txtEmail.Clear();
            HideStar(lblStarEmail, true); HideStar(lblStarPassw, true);
            HideStar(lblStarPasswCh, true); HideStar(lblStarPhone, true);
            HideStar(lblName, true);
            txtName.Focus();
        }


        //輸入焦點自動換textbox
        private void txtPhone1_TextChanged(object sender, EventArgs e)
        {
            if (txtPhone1.TextLength == txtPhone1.MaxLength) { txtPhone2.Focus(); }
        }

        private void txtPhone2_TextChanged(object sender, EventArgs e)
        {
            if (txtPhone2.TextLength == txtPhone2.MaxLength) { txtPhone3.Focus(); }
        }

        private void txtPhone3_TextChanged(object sender, EventArgs e)
        {
            if (txtPhone3.TextLength == txtPhone3.MaxLength) { txtEmail.Focus(); }
        }


        //按眼睛icon觀看密碼
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            { txtPassw.PasswordChar = '\0';
              pictureBox2.Image = Image.FromFile("D:\\user\\Myself\\MiddleCase\\MiddleCase\\Resources\\view30.png"); }
        }
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassw.PasswordChar = '*';
            pictureBox2.Image = Image.FromFile("D:\\user\\Myself\\MiddleCase\\MiddleCase\\Resources\\hidden30.png");
        }


        //限定電話格只能輸入數字、密碼格只能輸入英數、Email只能輸
        private void txtPhone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) { e.Handled = false; }
            else { 
                if(e.KeyChar >= '0' && e.KeyChar <= '9')
                { e.Handled = false; }
                else { e.Handled = true; }
            }
        }
        private void txtPhone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) 
            {
                if (txtPhone2.Text == "") { txtPhone1.Focus(); } 
                e.Handled = false; }
            else
            {
                if (e.KeyChar >= '0' && e.KeyChar <= '9')
                { e.Handled = false; }
                else { e.Handled = true; }
            }
        }
        private void txtPhone3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) 
            {
                if (txtPhone3.Text == "") { txtPhone2.Focus(); }
                e.Handled = false; }
            else
            {
                if (e.KeyChar >= '0' && e.KeyChar <= '9')
                { e.Handled = false; }
                else { e.Handled = true; }
            }
        }
        private void txtPassw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) { e.Handled = false; }
            else
            {
                if ((e.KeyChar >= '0' && e.KeyChar <= '9')||(e.KeyChar>='A'&&e.KeyChar<='Z')||(e.KeyChar>='a'&&e.KeyChar<='z'))
                { e.Handled = false; }
                else { e.Handled = true; }
            }
        }
        private void txtPasswCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) { e.Handled = false; }
            else if (e.KeyChar == 13) { Lo(); }
            else
            {
                if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z'))
                { e.Handled = false; }
                else { e.Handled = true; }
            }
        }



        public bool CheckEmail(string A)
        {
            int indexE = A.IndexOf("@"); int indexCom = A.IndexOf(".com");
            if (indexE != -1 && indexCom != -1)
            {
                if (A[indexE + 1] != A[indexCom])
                { return true; }
                else { return false; }
            }
            else { return false; }
        }
        public bool CheckPhone() 
        {
            if(txtPhone1.TextLength<txtPhone1.MaxLength|| txtPhone2.TextLength < txtPhone2.MaxLength|| txtPhone3.TextLength < txtPhone3.MaxLength)
            {
                return false;
            }else { return true; }
        }
        public bool CheckPasswch()
        {
            if (txtPasswCheck.Text == txtPassw.Text) { return true; }
            else { return false; }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        { Lo(); }

        void Lo() 
        { 
            string Alarm = "";
            if (CheckPhone()==false||CheckEmail(txtEmail.Text)==false||CheckPasswch()==false||txtPassw.Text==""||(rbtnMr.Checked==false&&rbtnMs.Checked==false&&rbtnOthers.Checked==false)) 
            {
              if (txtName.Text == "") { Alarm += "姓名欄不能為空\n";HideStar(lblName,false); }
                else { HideStar(lblName,true); }
              if(rbtnMr.Checked == false && rbtnMs.Checked == false && rbtnOthers.Checked == false)
                { Alarm += "請選擇您的性別"; }
              if (CheckPhone()==false){Alarm+="電話欄不能留空\n"; HideStar(lblStarPhone,false); }
                else { HideStar(lblStarPhone, true); }
              if (CheckEmail(txtEmail.Text) == false) { Alarm += "Email格式錯誤\n";HideStar(lblStarEmail,false); }
                else { HideStar(lblStarEmail, true); }
              if (txtPassw.Text == "") { Alarm += "密碼欄不能為空\n";HideStar(lblStarPassw,false); }
                else { HideStar(lblStarPassw, true); }
              if (CheckPasswch() == false) { Alarm += "確認密碼輸入錯誤\n";HideStar(lblStarPasswCh, false); } 
                else { HideStar(lblStarPasswCh, true); }
              MessageBox.Show(Alarm);
            }
            else 
            {
                string TempName = txtName.Text;
                int TempSexual = -1;
                if (rbtnMr.Checked) { TempSexual = 1; }
                else if (rbtnMs.Checked) { TempSexual = 0; }
                else { TempSexual = 2; }
                string TempPhone = "09" + txtPhone1.Text + "-" + txtPhone2.Text +
                                "-" + txtPhone3.Text;
                string TempEmail=txtEmail.Text;
                string TempPassW = txtPassw.Text;


                SqlConnection con = new SqlConnection(strDBconnectionString);
                con.Open();
                string strCommand = "select * from CustomerBasic "+
                                    "where 電話=@Phone "+
                                    "and 電子郵件=@Email";
                SqlCommand cmd = new SqlCommand(strCommand, con);
                cmd.Parameters.AddWithValue("@Phone",TempPhone);
                cmd.Parameters.AddWithValue("@Email",TempEmail);
                SqlDataReader reader=cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("電話或電子郵件已重複");
                    txtPhone1.Clear();txtPhone2.Clear();
                    txtPhone3.Clear();txtPassw.Clear();txtPasswCheck.Clear();
                    reader.Close();
                }
                else
                {
                    string NewCommand = "insert into CustomerBasic values " +
                                    "(@Name,@Sexual,@Phone,@Email)";
                    SqlCommand command=new SqlCommand(NewCommand, con);
                    command.Parameters.AddWithValue("@Name",TempName);
                    command.Parameters.AddWithValue("@Sexual",TempSexual);
                    command.Parameters.AddWithValue("@Phone",TempPhone);
                    command.Parameters.AddWithValue("@Email",TempEmail);                   

                    reader.Close();
                    command.ExecuteNonQuery();


                    string SearchID = "select CustomerID from CustomerBasic " +
                                     "where 電話=@Ph";                   
                    int TempID = 0;
                    SqlCommand InsertCommand1 = new SqlCommand(SearchID, con);
                    InsertCommand1.Parameters.AddWithValue("@Ph",TempPhone);
                    SqlDataReader RR = InsertCommand1.ExecuteReader();
                    if (RR.Read()) { TempID = RR.GetInt32(0); }
                    RR.Close();


                    string KeyInCommand = "insert into CustoMoreInfo values " +
                                          "(@ID,NULL,@Time,1,10,@PassW,0)";
                    SqlCommand InsertCommand2=new SqlCommand(KeyInCommand, con);
                    InsertCommand2.Parameters.AddWithValue("@ID",TempID);
                    InsertCommand2.Parameters.AddWithValue("@Time", DateTime.Now.ToString("yyyy-MM-dd"));
                    InsertCommand2.Parameters.AddWithValue("@PassW",TempPassW);
                    InsertCommand2.ExecuteNonQuery();

                    Console.WriteLine($"({0},Null,{1},1,10,{2},0)",
                        TempID, DateTime.Now.ToString("yyyy-MM-dd"),TempPassW);

                    Variable.isMember = true;
                    Variable.Member_ID = TempID;
                    MessageBox.Show("成功註冊");
                    if (TeleToForm1 != null) { TeleToForm1(); }

                }
                con.Close();
            }
        }
    }
}
