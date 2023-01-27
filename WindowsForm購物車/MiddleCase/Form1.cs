using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiddleCase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        string strDBconnectionString = "";



        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        //開闔式panel
        bool expand=true;
        bool product_expand;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            panel_Pro_Type.Height = panel_Pro_Type.MinimumSize.Height;
            btnAddCart.Visible = false;
            btnLogout.Visible = false;

            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            strDBconnectionString = scsb.ToString();

        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            if (expand)
            {                
                sidePanel.Width -= 10;                
                if (sidePanel.Width==sidePanel.MinimumSize.Width) 
                {
                    expand = false;
                    timer1.Stop();
                    btnAddCart.Text = "     加入\n   購物車";
                    btnAddCart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    panelAddCart.Width = sidePanel.MinimumSize.Width-5;
                }
            }
            else
            {
                sidePanel.Width += 10;               
                if (sidePanel.Width==sidePanel.MaximumSize.Width) 
                {
                    expand = true;
                    timer1.Stop();
                    btnAddCart.Text = "加入購物車";
                    btnAddCart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    panelAddCart.Width=sidePanel.MaximumSize.Width-7;
                }
            }
        }
        private void pbox_menu_Click(object sender, EventArgs e)
        {
            if (product_expand) { panel_Pro_Type.Height = panel_Pro_Type.MinimumSize.Height; 
                product_expand = false; 
                timer1.Start();
            }
            else { timer1.Start();}
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (expand)
            {
                if (product_expand)
                {
                    panel_Pro_Type.Height -= 10;
                    if (panel_Pro_Type.Height == panel_Pro_Type.MinimumSize.Height)
                    { product_expand = false; timer2.Stop(); }                   
                }
                else
                {
                    panel_Pro_Type.Height += 10;
                    if (panel_Pro_Type.Height == panel_Pro_Type.MaximumSize.Height)
                    { product_expand = true; timer2.Stop(); }
                }
            }
        }
        private void btn_ProType_Click(object sender, EventArgs e)
        {
            if (expand)
            {
                timer2.Start();
            }
            else { timer1.Start(); timer2.Start(); }
        }



        //移動視窗
        private Point mPoint;
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mPoint = new Point(e.X, e.Y);
            }
        }
        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mPoint = new Point(e.X, e.Y);
            }
        }
        private void panelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
        private void lbltitle_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mPoint = new Point(e.X, e.Y);
            }
        }
        private void lbltitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }



        //最小化視窗
        private void button11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        
        //把from讀入MainPanel裡面
        public void loadingForm(Form f)
        {
            if (this.Mainpanel.Controls.Count > 0)
            {
                this.Mainpanel.Controls.Clear();
            }
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.Mainpanel.Controls.Add(f);
            f.Show();
        }
        private void btnCart_Click(object sender, EventArgs e)
        {
            loadingForm(new Cart()); lbltitle.Text = "購物車";
            btnAddCart.Visible = false;

            SqlConnection con = new SqlConnection(strDBconnectionString);
            con.Open();
            string strCommand = "select MostBuyPro from CustoMoreInfo where CustomerID=@ID";
            SqlCommand cmd = new SqlCommand(strCommand, con);
            cmd.Parameters.AddWithValue("@ID", Variable.Member_ID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Random rand = new Random();
                if (rand.Next(0, 4) == 0 && Variable.isMember)
                {
                    Form ad = new Advertise();
                    ad.FormClosed += new FormClosedEventHandler(LoadingC);
                    ad.ShowDialog();                    
                }
            }
            reader.Close();
            con.Close();
        }


        void LoadingC(object sender, FormClosedEventArgs e) 
        {
            loadingForm(new Cart()); 
            lbltitle.Text = "購物車";
            btnAddCart.Visible = false;
        }


        private void btn_member_Click(object sender, EventArgs e)
        {
            MemberInfo member = new MemberInfo();
            //member.btnConfirm.Click += new EventHandler(LoadReviceMem);
            loadingForm(member);
            lbltitle.Text = "會員資訊";
            btnAddCart.Visible = false;
        }

        void LoadReviceMem(object sender, EventArgs e)
        {
            Form Rmem = new ReviceMemberInfo();
            loadingForm(Rmem);
            lbltitle.Text = "修改會員資料";
            btnAddCart.Visible = false;
        }


        private void btn_gacha_Click(object sender, EventArgs e)
        {
            loadingForm(new Gacha()); lbltitle.Text = "抽獎系統";
            btnAddCart.Visible = false;
        }

        private void btn_whisky_Click(object sender, EventArgs e)
        {
            lbltitle.Text = "威士忌";
            Whisky whis = new Whisky();
            PictureBox p = new PictureBox();
            whis.Controls.Add(p);
            p.Location = new Point(300, 40);
            
            loadingForm(whis);
            btnAddCart.Visible = true;
        }

        private void btn_vodka_Click_1(object sender, EventArgs e)
        {
            lbltitle.Text = "伏特加";
            loadingForm(new Vodka());
            btnAddCart.Visible = true;
        }

        private void btn_others_Click(object sender, EventArgs e)
        {
            lbltitle.Text = "其他類酒";
            loadingForm(new OtherProd());
            btnAddCart.Visible = true;
        }


        Loggin lo = new Loggin();
        private void btnLog_Click(object sender, EventArgs e)
        {
            lbltitle.Text = "WindowsForm酒窖";
            if (Mainpanel.Controls.Contains(lo) == false) 
            {
                lo.txtPhone1.Clear(); lo.txtPhone2.Clear(); lo.txtPhone3.Clear();
                lo.txtEmail.Clear();lo.txtPassw.Clear();
                loadingForm(lo);
                lo.TeleToForm1 += new Loggin.CloseRegister(AddTeleForm1);
            }
            btnAddCart.Visible = false;
        }
        void AddTeleForm1()
        {   
            loadingForm(new MemberInfo()); lbltitle.Text = "會員資訊";
            btnAddCart.Visible = false;
            btnLogout.Visible = true;
            panelRegister.Width = 0;
            panelLoggin.Width = 0;
        }



        Register r = new Register();
        private void btnSign_Click(object sender, EventArgs e)
        {
            lbltitle.Text = "WindowsForm酒窖";
            if (Mainpanel.Controls.Contains(r) == false)
            {
                r.txtName.Clear();r.txtPhone1.Clear();r.txtPhone2.Clear();r.txtPhone3.Clear();
                r.rbtnMr.Checked = false; r.rbtnMs.Checked = false; r.rbtnOthers.Checked = false;
                r.txtEmail.Clear();r.txtPassw.Clear();r.txtPasswCheck.Clear();
                loadingForm(r);
                r.TeleToForm1+=new Register.CloseRegister(AddTeleForm1);
            }
            btnAddCart.Visible = false;
        }


        private void btnAddCart_Click(object sender, EventArgs e)
        {
            foreach(List<int> LL in Variable.TempCartThing)
            {
                Variable.CartThing.Add(LL);
            }
            for(int i = 0; i < Variable.CartThing.Count; i++)
            {
                for(int j = 0; j < Variable.CartThing[i].Count; j++)
                {
                    Console.WriteLine(
                        "Variable.CarThing的第"+Convert.ToString(i)+"項有："
                        +Convert.ToString(Variable.CartThing[i][j]));
                }
            }
            Console.WriteLine();
            MessageBox.Show("訂單加入成功");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("您確定要登出嗎?", "登出確認", MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                Variable.isMember = false;
                Variable.Member_ID = 0;
                btnLogout.Visible = false;
                panelLoggin.Width = 65;
                panelRegister.Width = 65;
                loadingForm(new MemberInfo());
            }
        }
    }
}