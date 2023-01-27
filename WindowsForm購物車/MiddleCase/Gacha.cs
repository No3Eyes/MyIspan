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
    public partial class Gacha : Form
    {
        public Gacha()
        {
            InitializeComponent();
        }
        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        string strDBconnectionString = "";



        int GachaPoint = 0;

        private void Gacha_Load(object sender, EventArgs e)
        {
            btnStop.Visible = false;
            lblSaleTimes.Text = "0";
            Variable.TempCartThing.Clear();


            if (Variable.isMember)
            {
                lblLogginFirst.Visible = false;

                scsb.DataSource = @".";
                scsb.InitialCatalog = "mydb";
                scsb.IntegratedSecurity = true;
                strDBconnectionString = scsb.ToString();
                SqlConnection con = new SqlConnection(strDBconnectionString);
                con.Open();
                string strCommand = @"select M.LotteryPoint " +
                                    @"from CustomerBasic as C join CustoMoreInfo as M " +
                                    @"on C.CustomerID=M.CustomerID " +
                                    @"where C.CustomerID=@ID";
                SqlCommand cmd = new SqlCommand(strCommand, con);
                cmd.Parameters.AddWithValue("@ID", Variable.Member_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    GachaPoint = reader.GetInt32(0);
                    lblPoint.Text = Convert.ToString(reader.GetInt32(0));
                }
                reader.Close();
                con.Close();
            }
            else
            {
                foreach(Label lab in this.Controls.OfType<Label>())
                {
                    if (lab != lblLogginFirst) { lab.Visible = false; }
                }
                foreach(Button b in this.Controls.OfType<Button>()) 
                { b.Visible = false; }
                pictureBox1.Visible = false;
                panelResult.Visible = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (GachaPoint > 0)
            {
                GachaPoint -= 1;
                btnStop.Visible = true;
                lblPoint.Text = GachaPoint.ToString();

                scsb.DataSource = @".";
                scsb.InitialCatalog = "mydb";
                scsb.IntegratedSecurity = true;
                strDBconnectionString = scsb.ToString();
                SqlConnection con = new SqlConnection(strDBconnectionString);
                con.Open();
                string strCommand = @"update CustoMoreInfo set LotteryPoint=@Point where CustomerID=@ID";
                SqlCommand cmd = new SqlCommand(strCommand, con);
                cmd.Parameters.AddWithValue("@ID", Variable.Member_ID);
                cmd.Parameters.AddWithValue("@Point",GachaPoint);
                cmd.ExecuteNonQuery();
                con.Close();

                timer1.Start();
            }
            else { MessageBox.Show("點數不足"); }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (panelResult.BackColor == Color.Red) 
            {
                Variable.SalesTimes += 1;
                Form congratu = new Congratulations();
                congratu.ShowDialog();
            }
            lblSaleTimes.Text = Variable.SalesTimes.ToString();
            btnStop.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                Random rnd = new Random();
                if (rnd.Next() % 2 == 0) { 
                    panelResult.BackColor = Color.Red;
                    lblPrize.BackColor = Color.Red;
                    lblPrize.Text = "恭喜中獎";
                }
                else { panelResult.BackColor = Color.FromArgb(255, 128, 128);
                lblPrize.BackColor = Color.FromArgb(255, 128, 128);
                lblPrize.Text = Convert.ToString(rnd.Next() % 20);
                }
        }
    }
}
