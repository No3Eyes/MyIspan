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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
         
        }


        // 6. 宣告一個在Form1的類別變數， 取名為參數在Form1中，宣告為類別變數是為了方便等等存取 Back_Value
        public Class1 Parameter_in_Form1=new Class1();



        private void btn_in_Form1_Click(object sender, EventArgs e)
        {
        // 11. 按下按鈕時產生Form2同時將關閉Form2時的指令擴充使得除了關閉Form2外還會新增我們賦予的method As_Form2_Close的效果
            Form2 form2 =new Form2();
            form2.FormClosed += new FormClosedEventHandler(As_Form2_Close);
            form2.ShowDialog();
            
        }



        // 7. 寫一個為了加入上面的 form2.FormClosed 的 method，可以參考老師DotNet元件課的第三個專案
        //    中名為 dButton_Click 的 method 加入每個產生的按鈕的方式，和此處類似
        void As_Form2_Close(object sender, EventArgs e)
        {
        // 8. 讓As_Form2_Close 這個method的引數 sender 確認此物件(object)為 Form，同時把Form2 變數令為 i 
            Form2 i=(Form2)sender;

        // 9. 把Form1中的類別變數定義為 Form2 中的參數 parameter_in_Form2 
        //    因為此時 i 為 Form2 的變數，所以可以直接 i.parameter_in_Form2叫出 parameter_in_Form2 
            Parameter_in_Form1 = i.parameter_in_Form2;
        // 10. 把Form1的TextBox定義成類別變數parameter_in_Form1 的欄位 Back_Value
            txt_in_Form1.Text = Parameter_in_Form1.Back_Value;
        }
    }
}
