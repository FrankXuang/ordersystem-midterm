using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using System.Collections;
using System.Runtime.Remoting;

namespace FormsApp0121_訂購系統
{
    internal class GlobalVar
    {
        //菜色
        internal static List<string> listIce = new List<string>();
        internal static List<string> listSweet = new List<string>();
        internal static List<string> listSpicy = new List<string>();

        internal static List<string> list主廚推薦 = new List<string>();
        internal static List<int> list主廚價格 = new List<int>();

        public static bool ComboFood = false;
        internal static int 飲料 = 0;
        internal static int 甜點 = 0;
        internal static int 主食 = 0;


        //購物車
        internal static List<ArrayList> list訂購品項資料 = new List<ArrayList>();
        internal static bool is內用 = false;
        internal static bool is買購物袋 = false;
        internal static int 總價 = 0;
        internal static bool DataBase = false;

        //折扣
        internal static string 折扣項目 = "";

        //抽抽樂
        internal static double 折扣 = 1;
        internal static string 折扣字 = "";

        //讀取
        public static string myDBConnectionString = "";
        public static string image_dir = "";
        internal static List<string> listName = new List<string>();
        internal static List<int> listPrice = new List<int>();
        internal static List<int> listID = new List<int>();

        //登入會員或管理員
        public static bool Customer = false;
        public static bool Employee = false;
        public static bool Director = false;
        public static bool Visitor = false;
        public static bool System = false;
        public static bool LoginSuccess = false;
        internal static string 訂購人資訊 = "";
        internal static int 訂購人ID = 0;
        internal static string 地址 = "";
        internal static string 電話 = "";
        internal static bool MemberCancel = false;
        internal static int MemberPoint = 0;
        public static int Permission = 10000;
        internal static int SQLShopID = 0;
        //一般會員: 10000 , 特殊會員:5000, 店員:1000, 店長:100, 系統管理員: 10

        //產品
        //internal static bool PictureSave = false;
    }
}
