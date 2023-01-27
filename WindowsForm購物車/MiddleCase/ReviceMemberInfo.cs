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

namespace MiddleCase
{
    public partial class ReviceMemberInfo : Form
    {
        public ReviceMemberInfo()
        {
            InitializeComponent();
        }

        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        string strDBconnectionString = "";


        private void ReviceMemberInfo_Load(object sender, EventArgs e)
        {
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            strDBconnectionString = scsb.ToString();

            SqlConnection con = new SqlConnection(strDBconnectionString);
            con.Open();
            string strCommand = @"select C.姓名,C.性別,M.LotteryPoint,C.電子郵件,C.電話 " +
                                 "from CustomerBasic as C join CustoMoreInfo as M " +
                                 "on C.CustomerID=M.CustomerID where C.CustomerID=@ID";
            SqlCommand cmd = new SqlCommand(strCommand, con);
            cmd.Parameters.AddWithValue("@ID", Variable.Member_ID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtName.Text = reader.GetString(0);
                if (reader.GetInt32(1) == 0) { rbtnMs.Checked = true; }
                else if (reader.GetInt32(1) == 1) { rbtnMr.Checked = true; }
                else { rbtnOthers.Checked = true; }
                lblPoint.Text = (reader.GetInt32(2)).ToString();
                txtEmail.Text = reader.GetString(3);
                string Ph= reader.GetString(4);
                txtPhone1.Text= Ph.Substring(2, 3);
                txtPhone2.Text = Ph.Substring(5, 7);
                txtPhone3.Text = Ph.Substring(9);
            }
            reader.Close();
            con.Close();












            txtName.Focus();
            lblPass.Visible = false;
            txtPassW.Visible = false;
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
            if (e.KeyChar == 8)
            {
                if (txtPhone2.Text == "") { txtPhone1.Focus(); }
                e.Handled = false;
            }
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
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar >= '0' && e.KeyChar <= '9')
                { e.Handled = false; }
                else { e.Handled = true; }
            }

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

        private void btnConfirm_Click(object sender, EventArgs e)
        {

        }

        private void btnChangePassW_Click(object sender, EventArgs e)
        {

        }
    }
}
