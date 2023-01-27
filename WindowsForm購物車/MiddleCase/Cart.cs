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
    public partial class Cart : Form
    {
        public Cart()
        {
            InitializeComponent();
        }
        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        string strDBconnectionString = "";
        int NowChoosing =0;
        private void Cart_Load(object sender, EventArgs e)
        {
            Variable.TempCartThing.Clear();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            strDBconnectionString = scsb.ToString();
            foreach (List<int> LL in Variable.CartThing)
            {
                string pName = "";
                SqlConnection con = new SqlConnection(strDBconnectionString);
                con.Open();
                string strCommand = @"select * from ProductInfo where ProductID=@ProductID";
                SqlCommand cmd = new SqlCommand(strCommand, con);
                cmd.Parameters.AddWithValue("@ProductID", LL[0]);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) { pName = reader.GetString(4); }


                Panel p = new Panel();
                p.Size = new Size(panelCart.Width, panelHigh);
                p.Click += panel_choosed;
                panelCart.Controls.Add(p);
                p.Location = new Point(0, x);
                p.BackColor = Color.FromArgb(135,100,230);
                p.Tag = NowChoosing;
                NowChoosing += 1;


                PictureBox pb = new PictureBox();
                p.Controls.Add(pb);
                pb.Click += picBox_choosed;
                pb.Location = new Point(10, 10);
                pb.Size = new Size(100, 100);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = Image.FromFile(@"D:\user\Myself\MiddleCase\MiddleCase\Resources\" + pName+".png");


                Label lb =new Label();
                p.Controls.Add(lb);
                string WineName=reader.GetString(1)+reader.GetString(2)+" " + LL[1]+"瓶";
                lb.Text=WineName;
                lb.Click += label_choosed;
                lb.Location = new Point(140, 10);
                lb.AutoSize = true;
                lb.Font = new Font("新細明體",24);

                Label lb2 = new Label();
                p.Controls.Add(lb2);
                lb2.Click += label_choosed;
                string Howmuch = "共" + reader.GetInt32(3) * LL[1] + "元";
                lb2.Text = Howmuch;
                lb2.Location = new Point(140,70);
                lb2.AutoSize = true;
                lb2.Font= new Font("新細明體", 24);

                /*
                Button b1 = new Button();
                p.Controls.Add(b1);
                b1.Click += btnAdd;
                */


                x += panelHigh;
                reader.Close();
                con.Close();
            }
            CountPrice();
        }

        int panelHigh = 120;   //塞進主panel的panel的高度
        int x=0 ;
        int y = -1;                                       //辨認是否有點選過子panel
        void panel_choosed(object sender, EventArgs e)    //點選子panel時
        {
            Panel p=(Panel)sender;                        //宣告sender是Panel且設為變數p
            if (y == -1) { p.BackColor = Color.Blue; }    //如果未點選過子panel，選擇並反白
            else 
            {
                int a = 0;                                
                foreach(Panel pan in panelCart.Controls.OfType<Panel>())  //檢查每個子panel
                {
                    if(pan.BackColor == Color.Blue)       //如果其中有選擇過的(背景為藍色)
                    {
                        pan.BackColor = Color.FromArgb(135, 100, 230); 
                        p.BackColor = Color.Blue;
                        a += 1;
                    }              
                }
                if(a == 0) { p.BackColor = Color.Blue; }  //其中沒有被選過的，將其選擇
            }
            y = Convert.ToInt32(p.Tag);
        }

        void picBox_choosed(object sender, EventArgs e)    //點選子panel時
        {
            PictureBox p = (PictureBox)sender;                        //宣告sender是Panel且設為變數p
            if (y == -1) { p.Parent.BackColor = Color.Blue; }    //如果未點選過子panel，選擇並反白
            else
            {
                int a = 0;
                foreach (Panel pan in panelCart.Controls.OfType<Panel>())  //檢查每個子panel
                {
                    if (pan.BackColor == Color.Blue)       //如果其中有選擇過的(背景為藍色)
                    {
                        pan.BackColor = Color.FromArgb(135, 100, 230);
                        p.Parent.BackColor = Color.Blue;
                        a += 1;
                    }
                }
                if (a == 0) { p.Parent.BackColor = Color.Blue; }  //其中沒有被選過的，將其選擇
            }
            y = Convert.ToInt32(p.Parent.Tag);
        }


        void label_choosed(object sender, EventArgs e)    //點選子panel時
        {
            Label p = (Label)sender;                        //宣告sender是Panel且設為變數p
            if (y == -1) { p.Parent.BackColor = Color.Blue; }    //如果未點選過子panel，選擇並反白
            else
            {
                int a = 0;
                foreach (Panel pan in panelCart.Controls.OfType<Panel>())  //檢查每個子panel
                {
                    if (pan.BackColor == Color.Blue)       //如果其中有選擇過的(背景為藍色)
                    {
                        pan.BackColor = Color.FromArgb(135, 100, 230);
                        p.Parent.BackColor = Color.Blue;
                        a += 1;
                    }
                }
                if (a == 0) { p.Parent.BackColor = Color.Blue; }  //其中沒有被選過的，將其選擇
            }
            y = Convert.ToInt32(p.Parent.Tag);
        }


        //測試中的按鈕
        void btnAdd(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Variable.CartThing[Convert.ToInt32(this.Parent.Tag)][1] += 1;
            
        }




        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Panel p in panelCart.Controls)
            {
                if (p.BackColor == Color.Blue) 
                {   
                    int a = Convert.ToInt32(p.Tag);
                    Variable.CartThing.RemoveAt(a);
                    panelCart.Controls.Remove(p);
                    foreach (Panel pp in panelCart.Controls)
                    {
                        if (Convert.ToInt32(pp.Tag) > a)
                        {
                            pp.Tag = Convert.ToInt32(pp.Tag) - 1;
                        }
                    }
                }
            }
            string testindex = "";
            foreach(Panel pan in panelCart.Controls)
            {
                testindex+=pan.Tag+",";
            }
            Console.WriteLine(testindex);
            CountPrice();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelCart.Controls.Clear();
            Variable.CartThing.RemoveRange(0,Variable.CartThing.Count);
            CountPrice();
        }

        //計算總價
        void CountPrice()
        {
            double TotalP = 0;
            SqlConnection con = new SqlConnection(strDBconnectionString);
            con.Open();
            foreach (List<int> li in Variable.CartThing)
            {
                string SearchPri = @"select Prime from ProductInfo where ProductID=@PID";
                SqlCommand Pricomm = new SqlCommand(SearchPri, con);
                Pricomm.Parameters.AddWithValue("@PID", li[0]);
                SqlDataReader PriReader = Pricomm.ExecuteReader();
                if (PriReader.Read()) { TotalP += PriReader.GetInt32(0) * li[1]; }
                PriReader.Close();
            }
            con.Close();
            lblTruePrice.Text =TotalP.ToString();
            if (Variable.isMember && Variable.isNewMember==false) 
            { 
                TotalP *= 0.9;
                LBLisMem.Text = "(會員九折)";
            }
            else if (Variable.isNewMember) 
            { 
                TotalP *= 0.8;
                LBLisMem.Text = "(新會員8折)";
            }
            else { lblPrice.Text = ""; }
            lblPrice.Text = TotalP.ToString();
        }



        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strDBconnectionString);
            con.Open();
            foreach (List<int> LInt in Variable.CartThing)  //將每個購物車List的東西輸入進Order表
            {
                if (Variable.isMember == false) { Variable.Member_ID =11020; }
                string strCommand = @"insert into OrderInfo values "+
                                    "(@ID,@ProID,@ProAmount,@Time)";
                SqlCommand cmd = new SqlCommand(strCommand, con);
                cmd.Parameters.AddWithValue("@ID",Variable.Member_ID);
                cmd.Parameters.AddWithValue("@ProID", LInt[0]);
                cmd.Parameters.AddWithValue("@ProAmount", LInt[1]);
                cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();               
            }

            if (Variable.isMember)
            {
                //找出此顧客在Order表中最常買的商品
                string strMostBuy = @"select top 1 ProductID from OrderInfo " +
                                     "where CustomerID=@IID order by Amount desc, OrderTime desc";
                SqlCommand cmdMostBuy = new SqlCommand(strMostBuy, con);
                cmdMostBuy.Parameters.AddWithValue("@IID", Variable.Member_ID);
                int MostBuyPro = 0;
                SqlDataReader reader = cmdMostBuy.ExecuteReader();
                if (reader.Read()) { MostBuyPro = reader.GetInt32(0); }
                reader.Close();


                //找出此顧客的點數
                string strHowPoint = @"select LotteryPoint from CustoMoreInfo " +
                                      "where CustomerID=@ID1";
                SqlCommand cmdPo = new SqlCommand(strHowPoint, con);
                cmdPo.Parameters.AddWithValue("@ID1", Variable.Member_ID);
                int HowPointPro = 0;
                SqlDataReader dr = cmdPo.ExecuteReader();
                if (dr.Read()) { HowPointPro = dr.GetInt32(0); }
                dr.Close();
                HowPointPro += Convert.ToInt32(lblTruePrice.Text) / 500;


                //更新此商品及結束這筆買賣後的點數進顧客詳細資訊表單
                string updateMostBuy = @"update CustoMoreInfo " +
                    "set MostBuyPro=@MostB,LotteryPoint=@P " +
                    " where CustomerID=@IIID";
                SqlCommand updateComm = new SqlCommand(updateMostBuy, con);
                updateComm.Parameters.AddWithValue("@MostB", MostBuyPro);
                updateComm.Parameters.AddWithValue("@IIID", Variable.Member_ID);
                updateComm.Parameters.AddWithValue("@P", HowPointPro);
                updateComm.ExecuteNonQuery();

                con.Close();
            }
            MessageBox.Show("訂單購買完成");
            panelCart.Controls.Clear();
            Variable.CartThing.RemoveRange(0, Variable.CartThing.Count);
            CountPrice();
        }
    }
}