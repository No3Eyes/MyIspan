using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MiddleCase
{
    public partial class Loggin : Form
    {
        SqlConnectionStringBuilder scsb=new SqlConnectionStringBuilder();
        string strDBconnectionString = "";

        public delegate void CloseRegister();
        public event CloseRegister TeleToForm1;
        public Loggin()
        {
            InitializeComponent();
        }

        void HideStar(Label l, bool b) { if (b) { l.Text = ""; } else { l.Text = "*"; } }

        private void Loggin_Load(object sender, EventArgs e)
        {
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            strDBconnectionString = scsb.ToString();

            txtPhone1.Clear();txtPhone2.Clear();txtPhone3.Clear();
            txtPassw.Clear();HideStar(lblStarEmail, true);
            HideStar(lblStarPassw, true);HideStar(lblStarPhone, true);

            txtPhone1.Focus();
            Variable.TempCartThing.Clear();
        }


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



        private void pboxEye_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                txtPassw.PasswordChar = '\0';
                pboxEye.Image = Image.FromFile("D:\\user\\Myself\\MiddleCase\\MiddleCase\\Resources\\view30.png");
            }
        }
        private void pboxEye_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassw.PasswordChar = '*';
            pboxEye.Image = Image.FromFile("D:\\user\\Myself\\MiddleCase\\MiddleCase\\Resources\\hidden30.png");
        }



        private void txtPhone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) { e.Handled = false; }
            else
            {
                if (e.KeyChar >= '0' && e.KeyChar <= '9')
                { e.Handled = false; }
                else { e.Handled = true; }
            }
        }
        private void txtPhone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) {
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
            if (e.KeyChar == 8) {
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
            else if (e.KeyChar == 13) { Lo(); }
            else
            {
                if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z'))
                { e.Handled = false; }
                else { e.Handled = true; }
            }
        }


        
        bool CheckEmail()
        {
            int indexE = txtEmail.Text.IndexOf("@"); 
            int indexCom = txtEmail.Text.IndexOf(".com");
            if (indexE != -1 && indexCom != -1)
            {
                if (txtEmail.Text[indexE + 1] != txtEmail.Text[indexCom])
                { return true; }
                else { return false; }
            }
            else { return false; }
        }
        public bool CheckPhone()
        {
            if (txtPhone1.TextLength < txtPhone1.MaxLength || txtPhone2.TextLength < txtPhone2.MaxLength || txtPhone3.TextLength < txtPhone3.MaxLength)
            {
                return false;
            }
            else { return true; }
        }



        private void btnConfirm_Click(object sender, EventArgs e)
        { Lo(); }

        void Lo()
        {
            string Alarm = "";
            if (CheckPhone() == false || txtPassw.Text == "")
            {
                if (CheckPhone() == false) { Alarm += "電話欄不能留空\n"; HideStar(lblStarPhone, false); }
                else { HideStar(lblStarPhone, true); }
                if (CheckEmail() == false) { Alarm += "Email格式錯誤\n"; HideStar(lblStarEmail, false); }
                else { HideStar(lblStarEmail, true); }
                if (txtPassw.Text == "") { Alarm += "密碼欄不能為空\n"; HideStar(lblStarPassw, false); }
                else { HideStar(lblStarPassw, true); }
                MessageBox.Show(Alarm);
            }
            else
            {
                string tempPsword = txtPassw.Text;
                string tempEmail = txtEmail.Text;
                string tempPhone = "09" + txtPhone1.Text + "-" + txtPhone2.Text + "-" + txtPhone3.Text;
                int Permissions = 0;

                SqlConnection con = new SqlConnection(strDBconnectionString);
                con.Open();
                string strCommand = @"select M.Password,C.CustomerID,M.LogginTimes,M.Permission from CustomerBasic as C" +
                                " join CustoMoreInfo as M on C.CustomerID=M.CustomerID " +
                                "where C.電話=@Phone and C.電子郵件=@Email";
                SqlCommand cmd = new SqlCommand(strCommand, con);
                cmd.Parameters.AddWithValue("@Phone", tempPhone);
                cmd.Parameters.AddWithValue("@Email", tempEmail);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == false)
                {
                    MessageBox.Show("此帳號不存在\n請注意是否輸入錯誤");
                    txtPassw.Clear();
                    reader.Close();
                }
                else
                {
                    if (reader.GetString(0) != tempPsword)
                    {
                        MessageBox.Show("密碼錯誤");
                        txtPassw.Clear();
                    }
                    else
                    {
                        MessageBox.Show("登入成功");
                        Variable.isMember = true;
                        Variable.Member_ID = reader.GetInt32(1);
                        Permissions = reader.GetInt32(3);
                        int T = reader.GetInt32(2) + 1;
                        if (TeleToForm1 != null) { TeleToForm1(); }

                        string commandUse = @"update CustoMoreInfo set LogginTimes=@T where CustomerID=@ID";
                        SqlCommand command = new SqlCommand(commandUse, con);
                        command.Parameters.AddWithValue("@T", T);
                        command.Parameters.AddWithValue("@ID", Variable.Member_ID);                      
                        reader.Close();
                        command.ExecuteNonQuery();

                        if(Permissions > 0) 
                        { 
                            Form Mana = new Manager();
                            Mana.ShowDialog();
                        }
                    }
                }
                con.Close();
            }
        }
    }
}
