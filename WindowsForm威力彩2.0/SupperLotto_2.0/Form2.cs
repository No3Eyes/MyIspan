using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupperLotto_2._0
{
    public partial class Form2 : Form
    {
        int Prizz = 0;
        bool Sepp;
        public Form2(int Priz,bool Sep)
        {
            InitializeComponent();
            Prizz= Priz;
            Sepp= Sep;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lbl.Text = Convert.ToString(Prizz)+"+"+Convert.ToString(Sepp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
