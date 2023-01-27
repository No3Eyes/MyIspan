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
    public partial class Vodka : Form
    {
        public Vodka()
        {
            InitializeComponent();
        }
        List<int> VodkaList = new List<int>();

        private void Vodka_Load(object sender, EventArgs e)
        {
            Variable.TempCartThing.Clear();
            for(int i = 311002; i < 311008; i++) { VodkaList.Add(i); }
            int x = 0;

            foreach (ComboBox c in this.Controls.OfType<ComboBox>().OrderBy(c => c.TabIndex))
            {
                for(int i = 0; i < 11; i++)
                {
                    c.Items.Add(i);
                }
                c.Tag = VodkaList[x];                             //將對應商品的ID丟進對應的ComboBox中
                c.DropDownStyle = ComboBoxStyle.DropDownList;    //ComboBox設定為不可輸入
                c.MouseWheel += new MouseEventHandler(BanMouseWheel);     //禁止滾輪改變ComboBox的值
                c.SelectedIndexChanged += new EventHandler(ChangeAmount); //改變ComboBox的選擇後把選好
                c.SelectedIndex = -1;//預設值設為空白                      //的結果放進Variable.TempCart
                x++;
            }

        }
        void BanMouseWheel(object sender, EventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;  //true時把[滑鼠滾輪滾動]事件移到父容器上
        }
        void ChangeAmount(object sender, EventArgs e)
        {
            ComboBox s = (ComboBox)sender;
            int a = 0;                        //檢查Variable.TempCartThing有沒有重複的商品ID
            int b = 0;                        //紀錄重複商品ID在Variable.TempCartThing的位置
            List<int> ll = new List<int>();   //暫時存放此訂單紀錄的List
            ll.Add(Convert.ToInt32(s.Tag));   //把ComboBox中Tag裡的商品ID先丟到暫存List第一項
            if (s.SelectedIndex != 0)         //選擇數量後塞進Variable.CartThing中，重複項會覆蓋
            {
                ll.Add(Convert.ToInt32(s.Text));
                for (int i = 0; i < Variable.TempCartThing.Count; i++)
                {
                    if (Convert.ToInt32(s.Tag) == Variable.TempCartThing[i][0]) { a += 1; b = i; }
                }
                if (a > 0) { Variable.TempCartThing[b] = ll; }
                else
                {
                    Variable.TempCartThing.Add(ll);
                }
            }
            else                              //選擇0後要把Variable.TempCartThing的東西清空
            {
                for (int i = 0; i < Variable.TempCartThing.Count; i++)
                {
                    if (Convert.ToInt32(s.Tag) == Variable.TempCartThing[i][0])
                    {
                        Variable.TempCartThing.RemoveAt(i);
                    }
                }
            }
        }
    }
}
