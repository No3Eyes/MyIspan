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
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        string strDBconnectionString = "";
        


        private void Manager_Load(object sender, EventArgs e)
        {
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            strDBconnectionString = scsb.ToString();

            loadOrder();
        }


        bool checkOrder = true;


        private void button2_Click(object sender, EventArgs e)
        {
            loadOrder();
            checkOrder = true;
        }

        void loadOrder()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(strDBconnectionString);
            con.Open();
            string strCommand = @"select * from OrderInfo order by OrderID";
            SqlCommand cmd = new SqlCommand(strCommand, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
            reader.Close();
            con.Close();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            loadCust();
            checkOrder = false;
        }

        void loadCust()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(strDBconnectionString);
            con.Open();
            string strCommand = @"select * from CustoMoreInfo order by CustomerID";
            SqlCommand cmd = new SqlCommand(strCommand, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
            reader.Close();
            con.Close();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Console.WriteLine(dataGridView1.FirstDisplayedScrollingColumnIndex);
            Console.WriteLine(dataGridView1.FirstDisplayedScrollingRowIndex);*/
        }



        int Row = -1;
        int Column = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Row = e.RowIndex + 1;
            Column = e.ColumnIndex;
            Console.WriteLine("Row:"+e.RowIndex);
            Console.WriteLine("Column:"+e.ColumnIndex);
            Console.WriteLine("RowNumber:" + Row);
            Console.WriteLine("ColumnNumber:"+Column);
            Console.WriteLine();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (checkOrder)
                {
                    string TempStr = "";
                    int TempOrderID = 0;
                    if (Column == 4) { MessageBox.Show("請勿更動訂單編號"); return; }
                    else if (Column == 3) { TempStr = "OrderTime"; }
                    else if (Column == 2) { TempStr = "[Amount]"; }
                    else if (Column == 1) { TempStr = "[ProductID]"; }
                    else{ TempStr = "[CustomerID]"; }

                    SqlConnection con = new SqlConnection(strDBconnectionString);
                    con.Open();
                    
                    string strCommand = @"select top "+(Row+1)+" * from OrderInfo " +
                            "except select top "+(Row)+" * from OrderInfo";
                    
                    SqlCommand cmd = new SqlCommand(strCommand, con);                   
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        TempOrderID = reader.GetInt32(4);
                    }
                    Console.WriteLine("TempOrderID:"+TempOrderID);
                    reader.Close();
                    Console.WriteLine("TStr:" +TempStr);
                    Console.WriteLine("ID:" + TempOrderID);

                    string strcommand2 = @"update OrderInfo set "+TempStr+"=@txt where OrderID=@ID";                    
                    SqlCommand cmd2 = new SqlCommand(strcommand2, con);
                    cmd2.Parameters.AddWithValue("@txt", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@ID", TempOrderID);
                    cmd2.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("修改完成");
                    loadOrder();
                }
                else
                {
                    string TempStr = "";
                    int TempCustomerID = 0;
                    if (Column == 0) { MessageBox.Show("請勿更動會員編號"); return; }
                    else if (Column == 1) { TempStr = "[MostBuyPro]"; }
                    else if (Column == 2) { TempStr = "[LastLoggin]"; }
                    else if (Column == 3) { TempStr = "[LogginTimes]"; }
                    else if (Column == 4) { TempStr = "[LotteryPoint]"; }
                    else if (Column == 5) { TempStr = "[Password]"; }
                    else { TempStr = "[Permission]"; }

                    SqlConnection con = new SqlConnection(strDBconnectionString);
                    con.Open();

                    string strCommand = @"select top " + (Row) + " * from CustoMoreInfo " +
                            "except select top " + (Row-1) + " * from CustoMoreInfo";

                    SqlCommand cmd = new SqlCommand(strCommand, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        TempCustomerID = reader.GetInt32(0);
                    }
                    Console.WriteLine("TempOrderID:" + TempCustomerID);
                    reader.Close();
                    Console.WriteLine("TStr:" + TempStr);
                    Console.WriteLine("ID:" + TempCustomerID);

                    string strcommand2 = @"update CustoMoreInfo set " + TempStr + "=@txt where CustomerID =@ID";
                    SqlCommand cmd2 = new SqlCommand(strcommand2, con);
                    cmd2.Parameters.AddWithValue("@txt", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@ID", TempCustomerID);
                    cmd2.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("修改完成");
                    loadCust();
                }
            }
            else { MessageBox.Show("請勿輸入空白"); }
        }
    }
}
