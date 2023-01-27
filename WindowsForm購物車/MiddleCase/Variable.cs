using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MiddleCase
{
    internal class Variable
    {
        static public bool isMember=false;           //是否是會員
        static public int Member_ID = 11020;             //會員編號

        static public List<List<int>> TempCartThing=new List<List<int>>();  //同一個頁面下暫存的訂單
        static public List<List<int>> CartThing=new List<List<int>>();
        //按下加入購物車後把暫存訂單移到這個訂購單List，每個小List<int>有兩項，首項為商品ID，次項為購買數量
        //Loading 購物車Form時是讀取此訂購單List

        static public int SalesTimes = 0;
        static public bool isNewMember=false;

        
        


        /*
        static public string Member_Name = "";       //姓名   
        static public int Memeber_Sexual = 0;        //性別  
        static public string Member_Phone = "";      //電話
        static public string Member_Email = "";      //電子郵件
        static public int Gacha_Point = 0;           //抽獎點數
        static public int Member_LogginTime = 0;     //登入次數
        static public int Most_Buy = 0;              //最常購買商品
        static public DateTime Last_Loggin;          //最後登入時間
        static public int Loggin_Times;              //登入次數
        */
    }
}
