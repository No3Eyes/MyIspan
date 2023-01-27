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
    public partial class MemberInfo : Form
    {
        public MemberInfo()
        {
            InitializeComponent();
        }

        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        string strDBconnectionString = "";


        public delegate void LRevice();
        public event LRevice loadingR;

        private void MemberInfo_Load(object sender, EventArgs e)
        {
            Variable.TempCartThing.Clear();
            ReLoad();
        }


        void ReLoad()
        {
            if (Variable.isMember == false)
            {
                foreach (Label b in this.Controls.OfType<Label>())
                {
                    if (b != lblLogginFirst) { b.Visible = false; }
                }
                //btnConfirm.Visible = false;
            }
            else
            {
                lblLogginFirst.Visible = false;
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
                    lblName.Text = reader.GetString(0);
                    if (reader.GetInt32(1) == 0) { lblSex.Text = "小姐"; }
                    else if (reader.GetInt32(1) == 1) { lblPoint.Text = "先生"; }
                    else { lblEmail.Text = ""; }
                    lblPoint.Text = (reader.GetInt32(2)).ToString();
                    lblEmail.Text = reader.GetString(3);
                    lblPhone.Text = reader.GetString(4);
                }
                reader.Close();
                con.Close();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            /*
            if (loadingR != null) { loadingR(); Console.WriteLine("s2"); }
            else { Console.WriteLine("null"); }*/
            Form rmi = new ReviceMemberInfo();
            rmi.ShowDialog();
        }
    }
}
