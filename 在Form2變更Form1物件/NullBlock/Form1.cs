using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NullBlock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Blue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

            //4.實體化(new)出一個form2後，藉由此form2抓出在Form2的event然後在Form1對他新增事件
            form2.想要他能動的事件 += new Form2.無參數的Void委派(在Form1操控的事件);
        }
        void 在Form1操控的事件()
        {
            if (label1.BackColor==Color.Blue) { label1.BackColor = Color.Red; }
            else { label1.BackColor = Color.Blue; }
        }
    }
}
