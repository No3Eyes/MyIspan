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
    public partial class Advertise : Form
    {
        public Advertise()
        {
            InitializeComponent();
        }

        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        string strDBconnection = "";
        public delegate void LoadingCart();
        public event LoadingCart OnLoadingCart;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }


        int tempProID = 0;
        private void Advertise_Load(object sender, EventArgs e)
        {
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            strDBconnection=scsb.ToString();


                SqlConnection con = new SqlConnection(strDBconnection);
            con.Open();
                string strCommand = "select b.姓名,b.性別,m.MostBuyPro,p.ProductName,p.ImageName "+
                                    "from  CustoMoreInfo as m "+
                                    "join CustomerBasic as b "+
                                    "on b.CustomerID=m.CustomerID "+
                                    "join ProductInfo as p "+
                                    "on m.MostBuyPro=p.ProductID "+
                                    "where m.CustomerID=@ID";
                SqlCommand cmd = new SqlCommand(strCommand, con);
                cmd.Parameters.AddWithValue("@ID", Variable.Member_ID);
                SqlDataReader read = cmd.ExecuteReader();
            string tempName = ""; int tempsexual = 0; 
            string tempProName = ""; string tempProImName = "";
            if (read.Read())
            {
                tempName=read.GetString(0);
                tempsexual = read.GetInt32(1);
                tempProID=read.GetInt32(2);
                tempProName=read.GetString(3);
                tempProImName = read.GetString(4);
            }
            pictureBox2.Image = Image.FromFile(@"D:\user\Myself\MiddleCase\MiddleCase\Resources\"+tempProImName+".png");
            pictureBox2.SizeMode=PictureBoxSizeMode.Zoom;
            Console.WriteLine(@"D:\user\Myself\MiddleCase\MiddleCase\Resources\"+tempProImName+".png");
            string lbl = "親愛的";
            lbl += tempName;
            if (tempsexual == 0) { lbl += "小姐您好\n我們注意到您最常購買的商品為\n"; }
            else if (tempsexual == 1) { lbl += "先生您好\n我們注意到您最常購買的商品為\n"; }
            else { lbl += "您好\n我們注意到您最常購買的商品為\n"; }
            lbl+= tempProName + "，如果希望再次購買\n請按下立即加購";
            label1.Text = lbl;
            read.Close();
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> s = new List<int> {tempProID,1};
            Variable.CartThing.Add(s);
            MessageBox.Show("加購完成");
            if (OnLoadingCart != null) { OnLoadingCart(); }
            Close();
        }
    }
}
