using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsExperiment
{   //  1. 先建立一個public class用裡面的欄位來儲存Form2的值
    public class Class1
    {
        
        //  2. 宣告一個public的string 稱為 _Back_Value，目的是儲存Form2要回傳的值 
        public string _Back_Value;
        //  3. 設定一個public的string 用來讓Form2的參數輸入值且讓Form1的參數取值
        //     set值會使的想輸入Back_Value的值輸入到 _Back_Value
        //     get會使的取出的值是 _Back_Value的值
        //     其實就是將 _Back_Value當作全域變數用
        //     不直接宣告 public static string _Back_Value 來用的原因是我試過之後跑不動Orz
        public string Back_Value { get { return _Back_Value; } set { _Back_Value = value; } }
    }
}
