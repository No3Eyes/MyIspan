using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExperiment
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        //  4. 宣告一個類別變數，方便等等存取 Class1的欄位 Back_Value
        //     此變數我取名為參數在Form2中
        public Class1 parameter_in_Form2 = new Class1();

        private void btn_Form2_Click(object sender, EventArgs e)
        {// 5. 把Form2中的TextBox的值存進去變數的欄位 Back_Value中，此時在Class1中會把Back_Value
         //    的值存到 _Back_Value裡(因為 Back_Value的 set 的緣故)，同時按下按鈕後關閉Form2
            parameter_in_Form2.Back_Value = txt_Form2.Text;
            Close();
        }
    }
}
