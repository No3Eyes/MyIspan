using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiddleCase
{
    public partial class Congratulations : Form
    {
        public Congratulations()
        {
            InitializeComponent();
        }

        private void Congratulations_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            Random rand1 = new Random(Guid.NewGuid().GetHashCode());
            Random rand2 = new Random(Guid.NewGuid().GetHashCode());
            this.BackColor = Color.FromArgb(rand.Next(0, 255), rand1.Next(0, 255), rand2.Next(0, 255));
        }
    }
}

