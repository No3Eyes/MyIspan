using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NullBlock
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
        //1.宣告一個delegate用來傳到Form1，因為我們無法直接在Form2使用Form1的物件，所以用委派來傳遞event
        public delegate void 無參數的Void委派();

        //2.宣告一個event屬於上面宣告的delegate
        public event 無參數的Void委派 想要他能動的事件;

        private void button1_Click(object sender, EventArgs e)
        {   
            //3.當我點擊Form2中的Button時檢查上面宣告的事件是否為空，不為空就執行，執行內容寫在Form1
            if (想要他能動的事件 != null) { 想要他能動的事件(); }
        }
    }
}
