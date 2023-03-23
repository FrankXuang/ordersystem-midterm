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
using Function;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormsApp0121_訂購系統
{
    public partial class Menu : Form
    {
        #region 取消
        //public static List<菜色點選> listButtons = new List<菜色點選>();
        //public static List<菜色點選> listdessert = new List<菜色點選>();
        //public static List<菜色點選> list主廚推薦 = new List<菜色點選>();
        //public static List<Bitmap> listimage = new List<Bitmap>();
        //public static List<Bitmap> Bitdessert = new List<Bitmap>();
        //int time倒數;
        //int 主菜編號;
        #endregion
        string ItemsName; //名字
        int 所選ID;
        int 所選份數;
        int 所選單價;
        int 所選品項總價;
        int DessertNum;
        int DrinkNum;
        int MainfoodNum;
        int ComboFoodNum;
        string 所選甜度;
        string 所選冰量;
        string 所選辣度;
        bool 套餐 = false;
        string M = "Mainfood";
        string DT = "Dessert";
        string DK = "Drink";
        internal int 月亮 = 0;
        internal int 酥烤 = 0;
        internal int 沙律 = 0;
        internal int 海鮮 = 0;
        internal int 牛豬雞 = 0;
        internal int 蔬菜 = 0;
        internal int 主食 = 0;
        internal int 湯 = 0;

        Function.Function function = new Function.Function();

        internal List<string> listMainfood = new List<string>();
        internal List<int> listMainfoodPrice = new List<int>();
        internal List<int> listMainfoodID = new List<int>();


        internal List<string> listDrink = new List<string>();
        internal List<int> listDrinkPrice = new List<int>();
        internal List<int> listDrinkID = new List<int>();
        internal List<string> listDessert = new List<string>();
        internal List<int> listDessertPrice = new List<int>();
        internal List<int> listDessertID = new List<int>();

        internal List<string> list飲料甜度冰量 = new List<string>();
        internal List<string> list菜色辣度 = new List<string>();
        internal List<string> listComboFood = new List<string>();
        internal List<int> listComboFoodPrice = new List<int>();

        internal List<int> listComboMainFoodID = new List<int>();
        //internal List<int> listComboDrinkID = new List<int>();
        internal List<int> listComboDessertID = new List<int>();
        internal List<int> listComboMainFoodSpicy = new List<int>();

        internal List<int> listComboDrinkSweet = new List<int>();
        internal List<int> listComboDrinkIce = new List<int>();
        internal List<int> listComboDrinkID = new List<int>();

        internal List<int> listComboDessertSweet = new List<int>();
        internal List<int> listComboDessertIce = new List<int>();
        int Drink = 0;
        int Dessert = 0;
        int MainFood = 0;


        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            #region 取消項目
            //Combo甜點逐一顯示();
            //ombo飲料逐一顯示();
            //甜度冰量按鈕產生();
            //倒數計時();
            //Management.主菜月亮();
            //Management.主菜酥炸();
            //Management.主菜沙律();
            //Management.主菜海鮮();
            //Management.主菜牛豬雞();
            //Management.主菜蔬菜();
            //Management.主菜主食();
            //Management.主菜湯();
            //Management.甜點();
            //Management.飲料();
            //Management.飲料甜度冰量();
            //Management.菜色辣度();
            //Management.主廚推薦();
            //飲料元件();
            //甜點元件();
            //主廚元件();
            //combo主食.SelectedIndex= 0;
            //combo月亮.SelectedIndex= 0;
            //combo沙律.SelectedIndex= 0;
            //combo海鮮.SelectedIndex= 0;
            //combo湯.SelectedIndex= 0;
            //combo酥烤.SelectedIndex = 0;
            //combo蔬菜.SelectedIndex= 0;
            //combo牛豬雞.SelectedIndex= 0;
            //Member.加會員();
            //Combo菜色逐一顯示();
            //Management.飲料甜度冰量();
            //Management.菜色辣度();
            #endregion

            Function.Function.FormReadDataBasePicture();
            ReadDataBasePicture("p_type = '月亮'", M, 0);
            ReadDataBasePicture("p_type = '酥炸'", M, 1);
            ReadDataBasePicture("p_type = '沙律'", M, 2);
            ReadDataBasePicture("p_type = '海鮮'", M, 3);
            ReadDataBasePicture("p_type = '牛' or p_type = '雞' or p_type = '豬'", M, 4);
            ReadDataBasePicture("p_type = '蔬菜'", M, 5);
            ReadDataBasePicture("p_type = '主食'", M, 6);
            ReadDataBasePicture("p_type = '湯'", M, 7);
            ReadDataBasePicture("p_type = '飲料'", DK, 8);
            ReadDataBasePicture("p_type = '甜點'", DT, 9);

            ShowMainfood();
            ShowDrink();
            ShowDessert();

            Combo冰量逐一顯示();
            Combo甜度逐一顯示();
            Combo辣度逐一顯示();
            //套餐
            ComboFoodList();
            ComboFood();


            combo辣度.SelectedIndex= 0;
            combo甜度.SelectedIndex= 0;
            combo冰量.SelectedIndex = 0;
            text份數.Text = "1";
            所選份數 = 1;
            text份數.Enabled = false;
            combo甜度.Visible = false;
            lbl甜度.Visible = false;
            combo冰量.Visible = false;
            lbl冰量.Visible = false;
            combo辣度.Visible = true;
            lbl辣度.Visible = true;
            lbl總價.Text = "";
            lbl單價.Text = "";

            ComboFoodChoose();
            if(GlobalVar.ComboFood == true)
            {
                Drink = GlobalVar.飲料;
                Dessert = GlobalVar.甜點;
                MainFood = GlobalVar.主食;
                lblTop.Text = $"點選套餐，飲料還有{Drink}份/甜點還有{Dessert}份/主食還有{MainFood}份";
            }

        }

        #region 冰量逐一顯示
        void Combo冰量逐一顯示()
        {
            for (int i = 0; i < GlobalVar.listIce.Count; i++)
            {
                string strItem = string.Format("{0}", GlobalVar.listIce[i]);
                combo冰量.Items.Add(strItem);
            }

        }
        #endregion
        #region 甜度逐一顯示
        void Combo甜度逐一顯示()
        {
            for (int i = 0; i < GlobalVar.listSweet.Count; i++)
            {
                string strItem = string.Format("{0}", GlobalVar.listSweet[i]);
                combo甜度.Items.Add(strItem);
            }

        }
        #endregion
        #region 辣度逐一顯示
        void Combo辣度逐一顯示()
        {
            for (int i = 0; i < GlobalVar.listSpicy.Count; i++)
            {
                string strItem = string.Format("{0}", GlobalVar.listSpicy[i]);
                combo辣度.Items.Add(strItem);
            }
        }
        #endregion

        #region 加入購物車
        private void btn加入訂購單_Click(object sender, EventArgs e)
        {
            //lbl訂購人你好.Text != ""
            if (GlobalVar.訂購人資訊 != "")
            {
                if (GlobalVar.ComboFood == false)
                {
                    ArrayList 單品項主菜訂購資訊 = new ArrayList();
                    單品項主菜訂購資訊.Add(所選ID);
                    單品項主菜訂購資訊.Add(ItemsName);
                    單品項主菜訂購資訊.Add(所選單價);
                    單品項主菜訂購資訊.Add(所選份數);
                    if (tab菜色點選.SelectedTab == tab菜色點選.TabPages[0])
                    {
                        所選甜度 = "";
                        所選冰量 = "";
                        所選辣度 = GlobalVar.listSpicy[combo辣度.SelectedIndex];
                        單品項主菜訂購資訊.Add(所選甜度);
                        單品項主菜訂購資訊.Add(所選冰量);
                        單品項主菜訂購資訊.Add(所選辣度);
                    }
                    else if (tab菜色點選.SelectedTab == tab菜色點選.TabPages[1])
                    {
                        所選辣度 = "";
                        所選冰量 = GlobalVar.listIce[combo冰量.SelectedIndex];
                        所選甜度 = GlobalVar.listSweet[combo甜度.SelectedIndex];
                        單品項主菜訂購資訊.Add(所選甜度);
                        單品項主菜訂購資訊.Add(所選冰量);
                        單品項主菜訂購資訊.Add(所選辣度);
                    }
                    else if (tab菜色點選.SelectedTab == tab菜色點選.TabPages[2])
                    {
                        所選辣度 = "";
                        所選冰量 = GlobalVar.listIce[combo冰量.SelectedIndex];
                        所選甜度 = GlobalVar.listSweet[combo甜度.SelectedIndex];
                        單品項主菜訂購資訊.Add(所選甜度);
                        單品項主菜訂購資訊.Add(所選冰量);
                        單品項主菜訂購資訊.Add(所選辣度);
                    }
                    else if (tab菜色點選.SelectedTab == tab菜色點選.TabPages[3])
                    {
                        所選辣度 = "";
                        所選甜度 = "";
                        所選冰量 = "";
                        單品項主菜訂購資訊.Add(所選甜度);
                        單品項主菜訂購資訊.Add(所選冰量);
                        單品項主菜訂購資訊.Add(所選辣度);
                        GlobalVar.ComboFood = true;
                        if ((int)listViewCombo.SelectedItems[0].Index == 0)
                        {
                            GlobalVar.甜點 = 2;
                            GlobalVar.飲料 = 2;
                            GlobalVar.主食 = 5;
                            Drink = GlobalVar.飲料;
                            Dessert = GlobalVar.甜點;
                            MainFood = GlobalVar.主食;
                            lblTop.Text = $"你點選兩人套餐，接下來請選擇飲料{Drink}份/甜點{Dessert}份/主食{MainFood}份";
                        }
                        else if ((int)listViewCombo.SelectedItems[0].Index == 1)
                        {
                            GlobalVar.甜點 = 2;
                            GlobalVar.飲料 = 4;
                            GlobalVar.主食 = 7;
                            Drink = GlobalVar.飲料;
                            Dessert = GlobalVar.甜點;
                            MainFood = GlobalVar.主食;
                            lblTop.Text = $"你點選四人套餐，接下來請選擇飲料{Drink}份/甜點{Dessert}份/主食{MainFood}份";
                        }
                        else
                        {
                            GlobalVar.甜點 = 3;
                            GlobalVar.飲料 = 5;
                            GlobalVar.主食 = 8;
                            Drink = GlobalVar.飲料;
                            Dessert = GlobalVar.甜點;
                            MainFood = GlobalVar.主食;
                            lblTop.Text = $"你點選五人套餐，接下來請選擇飲料{Drink}份/甜點{Dessert}份/主食{MainFood}份";
                        }
                    }
                    單品項主菜訂購資訊.Add(所選品項總價);
                    GlobalVar.list訂購品項資料.Add(單品項主菜訂購資訊);
                    MessageBox.Show("品項加入訂購單");
                    combo冰量.SelectedIndex = 0;
                    combo甜度.SelectedIndex = 0;
                    combo辣度.SelectedIndex = 0;
                }
                else
                {
                    for (int test = 0; test < listComboMainFoodID.Count; test++)
                    {
                        ArrayList 多品項套餐訂購資訊 = new ArrayList();
                        int num = listComboMainFoodID[test];
                        多品項套餐訂購資訊.Add(listMainfoodID[num]);
                        多品項套餐訂購資訊.Add(listMainfood[num].ToString());
                        多品項套餐訂購資訊.Add(listMainfoodPrice[num]);
                        多品項套餐訂購資訊.Add(1);
                        多品項套餐訂購資訊.Add(GlobalVar.listSpicy[listComboMainFoodSpicy[test]]);
                        多品項套餐訂購資訊.Add("");
                        多品項套餐訂購資訊.Add("");
                        多品項套餐訂購資訊.Add(0);
                        GlobalVar.list訂購品項資料.Add(多品項套餐訂購資訊);
                        int Remain = GlobalVar.主食 - MainFood;
                        GlobalVar.主食 = Remain;
                    }
                    for (int test = 0; test < listComboDessertID.Count; test++)
                    {
                        ArrayList 多品項套餐訂購資訊 = new ArrayList();
                        int num = listComboDessertID[test];
                        多品項套餐訂購資訊.Add(listDessertID[num]);
                        多品項套餐訂購資訊.Add(listDessert[num].ToString());
                        多品項套餐訂購資訊.Add(listDessertPrice[num]);
                        多品項套餐訂購資訊.Add(1);
                        多品項套餐訂購資訊.Add("");
                        多品項套餐訂購資訊.Add(GlobalVar.listSweet[listComboDessertSweet[test]]);
                        多品項套餐訂購資訊.Add(GlobalVar.listIce[listComboDessertIce[test]]);
                        多品項套餐訂購資訊.Add(0);
                        GlobalVar.list訂購品項資料.Add(多品項套餐訂購資訊);
                        int Remain = GlobalVar.甜點 - Dessert;
                        GlobalVar.甜點 = Remain;
                    }
                    for (int test = 0;test < listComboDrinkID.Count; test++)
                    {
                        ArrayList 多品項套餐訂購資訊 = new ArrayList();
                        int num = listComboDrinkID[test];
                        多品項套餐訂購資訊.Add(listDrinkID[num]);
                        多品項套餐訂購資訊.Add(listDrink[num].ToString());
                        多品項套餐訂購資訊.Add(listDrinkPrice[num]);
                        多品項套餐訂購資訊.Add(1);
                        多品項套餐訂購資訊.Add("");
                        多品項套餐訂購資訊.Add(GlobalVar.listSweet[listComboDrinkSweet[test]]);
                        多品項套餐訂購資訊.Add(GlobalVar.listIce[listComboDrinkIce[test]]);
                        多品項套餐訂購資訊.Add(0);
                        GlobalVar.list訂購品項資料.Add(多品項套餐訂購資訊);
                        int Remain = GlobalVar.飲料 - Drink;
                        GlobalVar.飲料 = Remain;
                    }
                    MessageBox.Show("品項加入訂購單");

                    if((Drink ==0)&&(Dessert ==0)&&(MainFood==0))
                    {
                        GlobalVar.ComboFood = false;
                        ComboFoodChoose();
                    }
                    combo冰量.SelectedIndex = 0;
                    combo甜度.SelectedIndex = 0;
                    combo辣度.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("會員登入才能點餐");
            }
        }
        #endregion

        #region 份數填寫
        private void text份數_TextChanged(object sender, EventArgs e)
        {
            if ((text份數.Text != "") || (所選份數 <= 0))
            {
                bool is杯數正確 = Int32.TryParse(text份數.Text, out 所選份數);
                if (is杯數正確 == false)
                {
                    MessageBox.Show("份數輸入不對,最少一份");
                    所選份數 = 1;
                    text份數.Text = "1";
                }
            }
            計算總價();
        }
        #endregion
        #region 計算總價
        void 計算總價()
        {
            if (GlobalVar.ComboFood == false)
            {
                if (tab菜色點選.SelectedTab == tab菜色點選.TabPages[0])
                {
                    //MainfoodNum = (int)listViewMainfood.SelectedItems[0].ImageIndex;
                    所選單價 = listMainfoodPrice[MainfoodNum];
                    所選ID = listMainfoodID[MainfoodNum];
                    所選品項總價 = 所選單價 * 所選份數;
                    lbl總價.Text = string.Format("{0}", 所選品項總價);
                }
                else if (tab菜色點選.SelectedTab == tab菜色點選.TabPages[1])
                {
                    //DessertNum = (int)listViewDessert.SelectedItems[0].ImageIndex;
                    所選單價 = listDessertPrice[DessertNum];
                    所選ID = listDessertID[DessertNum];
                    所選品項總價 = 所選單價 * 所選份數;
                    lbl總價.Text = string.Format("{0}", 所選品項總價);
                }
                else if (tab菜色點選.SelectedTab == tab菜色點選.TabPages[2])
                {
                    //DrinkNum = (int)listViewDrink.SelectedItems[0].ImageIndex;
                    所選單價 = listDrinkPrice[DrinkNum];
                    所選ID = listDrinkID[DrinkNum];
                    所選品項總價 = 所選單價 * 所選份數;
                    lbl總價.Text = string.Format("{0}", 所選品項總價);
                }
                else if (tab菜色點選.SelectedTab == tab菜色點選.TabPages[3])
                {
                    所選單價 = listComboFoodPrice[ComboFoodNum];
                    所選品項總價 = 所選單價 * 所選份數;
                    lbl總價.Text = string.Format("{0}", 所選品項總價);
                }
            }
            else
            {
                if(GlobalVar.飲料 == 2) { 所選品項總價 = 1399; }
                else if(GlobalVar.飲料 == 4) { 所選品項總價 = 2980; }
                else { 所選品項總價 = 3765; }

            }
        }
        #endregion

        #region 菜色點選事件
        private void tab菜色點選_TabPagesChanged(object sender, EventArgs e)
        {
            lbl單價.Text = "";
            lbl總價.Text = "";

            if (tab菜色點選.SelectedTab == tab菜色點選.TabPages[0])
            {
                ComboFoodChoose();
                text份數.Text = "1";
                combo甜度.Visible = false;
                lbl甜度.Visible = false;
                combo冰量.Visible = false;
                lbl冰量.Visible = false;
                combo辣度.Visible = true;
                lbl辣度.Visible = true;
                text份數.Enabled = false;
                btn加入訂購單.Enabled = false;
            }
            else if (tab菜色點選.SelectedTab == tab菜色點選.TabPages[1])
            {
                ComboFoodChoose();
                text份數.Text = "1";
                combo甜度.Visible = true;
                lbl甜度.Visible = true;
                combo冰量.Visible = true;
                lbl冰量.Visible = true;
                combo辣度.SelectedIndex = 0;
                combo辣度.Visible = false;
                lbl辣度.Visible = false;
                text份數.Enabled = false;
                btn加入訂購單.Enabled = false;
            }
            else if (tab菜色點選.SelectedTab == tab菜色點選.TabPages[2])
            {
                ComboFoodChoose();
                text份數.Text = "1";
                combo甜度.Visible = true;
                lbl甜度.Visible = true;
                combo冰量.Visible = true;
                lbl冰量.Visible = true;
                combo辣度.SelectedIndex = 0;
                combo辣度.Visible = false;
                lbl辣度.Visible = false;
                text份數.Enabled = false;
                btn加入訂購單.Enabled = false;
            }
            else
            {
                text份數.Text = "1";
                combo冰量.Visible = false;
                combo冰量.SelectedIndex = 0;
                lbl冰量.Visible = false;
                combo甜度.Visible = false;
                lbl甜度.Visible = false;
                combo甜度.SelectedIndex = 0;
                combo辣度.Visible = false;
                lbl辣度.Visible = false;
                combo辣度.SelectedIndex = 0;
                text份數.Enabled = false;
                btn加入訂購單.Enabled = false;
            }
            if (GlobalVar.ComboFood == true) { text份數.Text = "1"; text份數.Enabled = false; }
            else { text份數.Enabled = true; }

        }
        #endregion

        #region 冰量選擇
        private void combo冰量_SelectedIndexChanged(object sender, EventArgs e)
        {
            所選冰量 = GlobalVar.listIce[combo冰量.SelectedIndex];
        }
        #endregion
        #region 甜度選擇
        private void combo甜度_SelectedIndexChanged(object sender, EventArgs e)
        {
            所選甜度 = GlobalVar.listSweet[combo甜度.SelectedIndex];
        }
        #endregion
        #region 辣度選擇
        private void combo辣度_SelectedIndexChanged(object sender, EventArgs e)
        {
            所選辣度 = GlobalVar.listSpicy[combo辣度.SelectedIndex];
        }
        #endregion

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (GlobalVar.ComboFood == true) { text份數.Text = "1"; text份數.Enabled = false; }
            else { text份數.Enabled = true; }
            ComboFoodChoose();
            //lbl訂購人你好.Text = GlobalVar.訂購人資訊;
        }

        #region 飲料顯示
        public void ShowDrink()
        {
            listViewDrink.Clear();
            listViewDrink.View = View.LargeIcon;
            //LargeIcon大, SmallIcon小, List一列一列排, Tile只支援size40的small展示模式
            imgListDrink.ImageSize = new Size(100, 100);
            listViewDrink.LargeImageList = imgListDrink;

            for (int i = 0; i < imgListDrink.Images.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                //圖片索引
                item.Font = new Font("標楷體", 11, FontStyle.Regular);
                //字體
                item.Text = $"{listDrink[i]} {listDrinkPrice[i]}元";
                item.Tag = listDrinkID[i];
                //藏
                listViewDrink.Items.Add(item);
            }
        }
        #endregion
        #region 甜點顯示
        public void ShowDessert()
        {
            listViewDessert.Clear();
            listViewDessert.View = View.LargeIcon;
            //LargeIcon大, SmallIcon小, List一列一列排, Tile只支援size40的small展示模式
            imgListDessert.ImageSize = new Size(100, 100);
            listViewDessert.LargeImageList = imgListDessert;

            for (int i = 0; i < imgListDessert.Images.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                //圖片索引
                item.Font = new Font("標楷體", 10, FontStyle.Regular);
                //字體
                item.Text = $"{listDessert[i]} {listDessertPrice[i]}元";
                item.Tag = listDessertID[i];
                //藏
                listViewDessert.Items.Add(item);
            }
        }
        #endregion
        #region 主食顯示
        public void ShowMainfood()
        {
            listViewMainfood.Clear();
            listViewMainfood.View = View.LargeIcon;
            //LargeIcon大, SmallIcon小, List一列一列排, Tile只支援size40的small展示模式
            imgListPicture.ImageSize = new Size(80, 80);
            listViewMainfood.LargeImageList = imgListPicture;

            listViewMainfood.ShowGroups = true;
            listViewMainfood.Groups.Add(new ListViewGroup("月亮", HorizontalAlignment.Center));
            listViewMainfood.Groups.Add(new ListViewGroup("酥烤", HorizontalAlignment.Center));
            listViewMainfood.Groups.Add(new ListViewGroup("沙律", HorizontalAlignment.Center));
            listViewMainfood.Groups.Add(new ListViewGroup("海鮮", HorizontalAlignment.Center));
            listViewMainfood.Groups.Add(new ListViewGroup("牛豬雞", HorizontalAlignment.Center));
            listViewMainfood.Groups.Add(new ListViewGroup("蔬菜", HorizontalAlignment.Center));
            listViewMainfood.Groups.Add(new ListViewGroup("主食", HorizontalAlignment.Center));
            listViewMainfood.Groups.Add(new ListViewGroup("湯", HorizontalAlignment.Center));
            for (int i = 0; i < imgListPicture.Images.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                //圖片索引
                item.Font = new Font("標楷體", 10, FontStyle.Regular);
                //字體
                item.Text = $"{listMainfood[i]} {listMainfoodPrice[i]}元";
                item.Tag = listMainfoodID[i];
                //藏
                listViewMainfood.Items.Add(item);
            }

            int count = imgListPicture.Images.Count;
            for (int k = 0; k < imgListPicture.Images.Count; k++)
            {
                if (k < 月亮) //月亮
                { listViewMainfood.Items[k].Group = listViewMainfood.Groups[0]; }
                else if ((月亮 <= k) && (k < (酥烤 + 月亮))) //酥烤
                { listViewMainfood.Items[k].Group = listViewMainfood.Groups[1]; }
                else if (((酥烤 + 月亮) <= k) && (k < (酥烤 + 月亮 + 沙律))) //沙律
                { listViewMainfood.Items[k].Group = listViewMainfood.Groups[2]; }
                else if (((酥烤 + 月亮 + 沙律) <= k) && (k < (酥烤 + 月亮 + 沙律 + 海鮮))) //海鮮
                { listViewMainfood.Items[k].Group = listViewMainfood.Groups[3]; }
                else if ((酥烤 + 月亮 + 沙律 + 海鮮 <= k) && (k < 酥烤 + 月亮 + 沙律 + 海鮮 + 牛豬雞)) //牛豬雞
                { listViewMainfood.Items[k].Group = listViewMainfood.Groups[4]; }
                else if ((count - 主食 - 蔬菜 - 牛豬雞 <= k) && (k < count - 主食 - 湯)) //蔬菜
                { listViewMainfood.Items[k].Group = listViewMainfood.Groups[5]; }
                else if ((count - 主食 -湯 <= k) && (k < (count - 湯))) //主食
                { listViewMainfood.Items[k].Group = listViewMainfood.Groups[6]; }
                else //湯
                { listViewMainfood.Items[k].Group = listViewMainfood.Groups[7]; }
            }

            
        }

        #endregion

        #region ListView雙擊圖片事件
        private void listViewMainfood_ItemActivate(object sender, EventArgs e)
        {
            //雙擊事件
            Productdetail ThisProductDetail = new Productdetail();
            ThisProductDetail.selectID = (int)listViewMainfood.SelectedItems[0].Tag;
            ThisProductDetail.ShowDialog();
        }      
        private void listViewDessert_ItemActivate(object sender, EventArgs e)
        {
            Productdetail ThisProductDetail = new Productdetail();
            ThisProductDetail.selectID = (int)listViewDessert.SelectedItems[0].Tag;
            ThisProductDetail.ShowDialog();
        }
        private void listViewDrink_ItemActivate(object sender, EventArgs e)
        {
            Productdetail ThisProductDetail = new Productdetail();
            ThisProductDetail.selectID = (int)listViewDrink.SelectedItems[0].Tag;
            ThisProductDetail.ShowDialog();
        }
        #endregion

        #region 點擊顯示價格
        private void listViewDrink_MouseClick(object sender, MouseEventArgs e)
        {
            ComboFoodChoose();
            lbl單價.Text = "";
            lbl總價.Text = "";
            text份數.Enabled = true;
            btn加入訂購單.Enabled = true;
            text份數.Enabled = true;
            if (GlobalVar.ComboFood == false)
            {
                DrinkNum = (int)listViewDrink.SelectedItems[0].ImageIndex;
                lbl單價.Text = listDrinkPrice[DrinkNum].ToString();
                ItemsName = listDrink[DrinkNum].ToString();
            }
            計算總價();
        }
        private void listViewDessert_MouseClick(object sender, MouseEventArgs e)
        {
            ComboFoodChoose();
            lbl單價.Text = "";
            lbl總價.Text = "";
            text份數.Enabled = true;
            btn加入訂購單.Enabled = true;
            if (GlobalVar.ComboFood == false)
            {
                DessertNum = (int)listViewDessert.SelectedItems[0].ImageIndex;
                lbl單價.Text = listDessertPrice[DessertNum].ToString();
                ItemsName = listDessert[DessertNum].ToString();
            }
            計算總價();
        }
        private void listViewMainfood_MouseClick(object sender, MouseEventArgs e)
        {
            ComboFoodChoose();
            lbl單價.Text = "";
            lbl總價.Text = "";
            text份數.Enabled = true;
            btn加入訂購單.Enabled = true;
            if (GlobalVar.ComboFood == false)
            {
                
                MainfoodNum = (int)listViewMainfood.SelectedItems[0].ImageIndex;
                lbl單價.Text = listMainfoodPrice[MainfoodNum].ToString();
                ItemsName = listMainfood[MainfoodNum].ToString();
            }
            計算總價();
        }
        #endregion

        #region 讀取產品資料庫ReadDataBasePicture(string SQL, string type, int num)
        internal void ReadDataBasePicture(string SQL, string type, int num)
        {
            try
            {
                SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                con.Open();
                string strSQL = ($"select * from Products where p_discontinued = 0 and {SQL}");
                SqlCommand cmd = new SqlCommand(strSQL, con);
                SqlDataReader reader = cmd.ExecuteReader();
                string image_name = "";
                int count = 0;
                switch (type)
                {
                    case "Drink":
                        while (reader.Read() == true)
                        {
                            listDrinkID.Add((int)reader["p_id"]);
                            listDrink.Add(reader["p_name"].ToString());
                            listDrinkPrice.Add((int)reader["p_price"]);
                            image_name = reader["p_image"].ToString();
                            string PictureAllAddress = GlobalVar.image_dir + image_name;
                            Image imgProductsPicture = Image.FromFile(PictureAllAddress);
                            imgListDrink.Images.Add(imgProductsPicture);
                            count += 1;
                        }
                        break;
                    case "Dessert":
                        while (reader.Read() == true)
                        {
                            listDessertID.Add((int)reader["p_id"]);
                            listDessert.Add(reader["p_name"].ToString());
                            listDessertPrice.Add((int)reader["p_price"]);
                            image_name = reader["p_image"].ToString();
                            string PictureAllAddress = GlobalVar.image_dir + image_name;
                            Image imgProductsPicture = Image.FromFile(PictureAllAddress);
                            imgListDessert.Images.Add(imgProductsPicture);
                            count += 1;
                        }
                        break;
                    case "Mainfood":
                        while (reader.Read() == true)
                        {
                            listMainfoodID.Add((int)reader["p_id"]);
                            listMainfood.Add(reader["p_name"].ToString());
                            listMainfoodPrice.Add((int)reader["p_price"]);
                            image_name = reader["p_image"].ToString();
                            string PictureAllAddress = GlobalVar.image_dir + image_name;
                            Image imgProductsPicture = Image.FromFile(PictureAllAddress);
                            imgListPicture.Images.Add(imgProductsPicture);
                            count += 1;
                        }
                        switch (num)
                        {
                            case 0:
                                月亮 = count;
                                break;
                            case 1:
                                酥烤 = count;
                                break;
                            case 2:
                                沙律 = count;
                                break;
                            case 3:
                                海鮮 = count;
                                break;
                            case 4:
                                牛豬雞 = count;
                                break;
                            case 5:
                                蔬菜 = count;
                                break;
                            case 6:
                                主食 = count;
                                break;
                            case 7:
                                湯 = count;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("種類錯誤");
                        break;
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return ex;
            }
        }



        #endregion

        #region 套餐 ComboFoodList()/ComboFood()
        void ComboFoodList()
        {

            listComboFood.Add("兩人套餐");
            listComboFood.Add("四人套餐");
            listComboFood.Add("五人套餐");
            listComboFoodPrice.Add(1399);
            listComboFoodPrice.Add(2980);
            listComboFoodPrice.Add(3765);

        }
        void ComboFood()
        {
            listViewCombo.Clear();
            listViewCombo.View = View.LargeIcon;
            
            //imgListCombo.ImageSize = new Size(180, 180);
            listViewCombo.LargeImageList = imgListCombo;

            for (int i = 0; i < listComboFoodPrice.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                //圖片索引
                item.Font = new Font("標楷體", 11, FontStyle.Regular);
                //字體
                item.Text = $"{listComboFood[i]} {listComboFoodPrice[i]}元";
                //item.Tag = listDrinkID[i];
                //藏
                listViewCombo.Items.Add(item);
            }
        }
        #endregion
        #region 套餐點選
        private void listViewCombo_MouseClick(object sender, MouseEventArgs e)
        {
            lbl單價.Text = "";
            lbl總價.Text = "";
            text份數.Enabled = true;
            ComboFoodNum = (int)listViewCombo.SelectedItems[0].Index;
            lbl單價.Text = listComboFoodPrice[ComboFoodNum].ToString();
            text份數.Enabled = true;
            btn加入訂購單.Enabled = true;
            ItemsName = listComboFood[ComboFoodNum].ToString();
            計算總價();
        }

        private void listViewCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCombo.SelectedItems.Count > 0)
            {
                
            }
        }
        #endregion
        #region ComboFoodChoose
        void ComboFoodChoose()
        {
            if(GlobalVar.ComboFood == true)
            {
                listViewDessert.MultiSelect = true;
                listViewDessert.CheckBoxes = true;
                listViewMainfood.MultiSelect = true;
                listViewMainfood.CheckBoxes = true;
                listViewDrink.CheckBoxes = true;
                listViewDrink.MultiSelect = true;
                text份數.Text = "1"; 
                text份數.Enabled = false;
                
            }
            else
            {
                listViewDessert.MultiSelect = false;
                listViewDessert.CheckBoxes = false;
                listViewMainfood.MultiSelect = false;
                listViewMainfood.CheckBoxes = false;
                listViewDrink.MultiSelect = false;
                listViewDrink.CheckBoxes = false;
                lblTop.Text = "菜色點選";
            }
            
        }
        #endregion

        #region 套餐點選飲料/主食/甜點事件
        int ComboMainFood = 0;
        private void listViewMainfood_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ComboFoodChoose();
            if (GlobalVar.ComboFood == true)
            {
                ListViewItem item = listViewMainfood.Items[e.Index];
                if (ComboMainFood < GlobalVar.主食)
                {
                    if (e.NewValue == CheckState.Checked)
                    {
                        MainFood--;
                        ComboMainFood++;
                        MainfoodNum = item.ImageIndex;
                        lbl單價.Text = listMainfoodPrice[MainfoodNum].ToString();
                        ItemsName = listMainfood[MainfoodNum].ToString();
                        listComboMainFoodID.Add(item.ImageIndex);
                        listComboMainFoodSpicy.Add(combo辣度.SelectedIndex);
                        lblTop.Text = $"點選套餐，飲料還有{Drink}份/甜點還有{Dessert}份/主食還有{MainFood}份";
                    }
                    else
                    {
                        MainFood++;
                        ComboMainFood--;
                        MainfoodNum = item.ImageIndex;
                        lbl單價.Text = listMainfoodPrice[MainfoodNum].ToString();
                        ItemsName = listMainfood[MainfoodNum].ToString();
                        int lastIndexOfNum = listComboMainFoodID.LastIndexOf(MainfoodNum);
                        if (lastIndexOfNum >= 0)
                        {
                            listComboMainFoodSpicy.RemoveAt(lastIndexOfNum);
                        }
                        listComboMainFoodID.Remove(item.ImageIndex);
                        lblTop.Text = $"點選套餐，飲料還有{Drink}份/甜點還有{Dessert}份/主食還有{MainFood}份";
                    }
                    //e.NewValue = CheckState.Unchecked;  // 取消勾選
                    //MessageBox.Show("飲料選超過數量了");
                    //Console.WriteLine($"ID加了{listComboDrinkID.Count}個");
                    //lblTop.Text = $"點選套餐，飲料還有{Drink}份/甜點還有{Dessert}份/主食還有{MainFood}份";
                    //return;
                }
                else
                {
                    MessageBox.Show("主食選超過數量了,若要加點請先點完套餐");
                    e.NewValue = CheckState.Unchecked;
                    listViewMainfood.CheckBoxes = false;
                    lblTop.Text = $"點選套餐，飲料還有{Drink}份/甜點還有{Dessert}份/主食還有{MainFood}份";
                }
                listViewMainfood.Refresh();
            }
        }
        int combodessert = 0;
        private void listViewDessert_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ComboFoodChoose();
            if (GlobalVar.ComboFood == true)
            {
                ListViewItem item = listViewDessert.Items[e.Index];
                if (combodessert < GlobalVar.甜點)
                {
                    if (e.NewValue == CheckState.Checked)
                    {
                        Dessert--;
                        combodessert++;
                        DessertNum = item.ImageIndex;
                        lbl單價.Text = listDessertPrice[DessertNum].ToString();
                        ItemsName = listDessert[DessertNum].ToString();
                        listComboDessertID.Add(item.ImageIndex);
                        listComboDessertIce.Add(combo冰量.SelectedIndex);
                        listComboDessertSweet.Add(combo甜度.SelectedIndex);
                        lblTop.Text = $"點選套餐，飲料還有{Drink}份/甜點還有{Dessert}份/主食還有{MainFood}份";
                    }
                    else
                    {
                        Dessert++;
                        combodessert--;
                        DessertNum = item.ImageIndex;
                        lbl單價.Text = listDessertPrice[DessertNum].ToString();
                        ItemsName = listDessert[DessertNum].ToString();
                        int lastIndexOfNum = listComboDessertID.LastIndexOf(DessertNum);
                        if (lastIndexOfNum >= 0)
                        {
                            listComboDessertIce.RemoveAt(lastIndexOfNum);
                            listComboDessertSweet.RemoveAt(lastIndexOfNum);
                        }
                        listComboDessertID.Remove(item.ImageIndex);
                        lblTop.Text = $"點選套餐，飲料還有{Drink}份/甜點還有{Dessert}份/主食還有{MainFood}份";
                    }
                    //e.NewValue = CheckState.Unchecked;  // 取消勾選
                    //MessageBox.Show("飲料選超過數量了");
                    //Console.WriteLine($"ID加了{listComboDrinkID.Count}個");
                    //lblTop.Text = $"點選套餐，飲料還有{Drink}份/甜點還有{Dessert}份/主食還有{MainFood}份";
                    //return;
                }
                else
                {
                    MessageBox.Show("甜點選超過數量了,若要加點請先點完套餐");
                    e.NewValue = CheckState.Unchecked;
                    listViewDessert.CheckBoxes = false;
                    lblTop.Text = $"點選套餐，飲料還有{Drink}份/甜點還有{Dessert}份/主食還有{MainFood}份";
                }
                listViewDessert.Refresh();
            }
        }
        int combodrink = 0;
        private void listViewDrink_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ComboFoodChoose();
            if (GlobalVar.ComboFood == true)
            {
                ListViewItem item = listViewDrink.Items[e.Index];
                if (combodrink < GlobalVar.飲料)
                {
                    if (e.NewValue == CheckState.Checked)
                    {
                        Drink--;
                        combodrink++;
                        DrinkNum = item.ImageIndex;
                        lbl單價.Text = listDrinkPrice[DrinkNum].ToString();
                        ItemsName = listDrink[DrinkNum].ToString();
                        listComboDrinkID.Add(item.ImageIndex);
                        listComboDrinkIce.Add(combo冰量.SelectedIndex);
                        listComboDrinkSweet.Add(combo甜度.SelectedIndex);
                        lblTop.Text = $"點選套餐，飲料還有{Drink}份/甜點還有{Dessert}份/主食還有{MainFood}份";
                    }
                    else
                    {
                        Drink++;
                        combodrink--;
                        DrinkNum = item.ImageIndex;
                        lbl單價.Text = listDrinkPrice[DrinkNum].ToString();
                        ItemsName = listDrink[DrinkNum].ToString();
                        int lastIndexOfNum = listComboDrinkID.LastIndexOf(DrinkNum);
                        if (lastIndexOfNum >= 0)
                        {
                            listComboDrinkIce.RemoveAt(lastIndexOfNum);
                            listComboDrinkSweet.RemoveAt(lastIndexOfNum);
                        }
                        listComboDrinkID.Remove(item.ImageIndex);
                        lblTop.Text = $"點選套餐，飲料還有{Drink}份/甜點還有{Dessert}份/主食還有{MainFood}份";
                    }
                    //e.NewValue = CheckState.Unchecked;  // 取消勾選
                    //MessageBox.Show("飲料選超過數量了");
                    //Console.WriteLine($"ID加了{listComboDrinkID.Count}個");
                    //lblTop.Text = $"點選套餐，飲料還有{Drink}份/甜點還有{Dessert}份/主食還有{MainFood}份";
                    //return;
                }
                else
                {
                    MessageBox.Show("飲料選超過數量了,若要加點請先點完套餐");
                    e.NewValue = CheckState.Unchecked;
                    listViewDrink.CheckBoxes = false;
                    lblTop.Text = $"點選套餐，飲料還有{Drink}份/甜點還有{Dessert}份/主食還有{MainFood}份";
                }
                listViewDrink.Refresh();
            }
        }
        #endregion
    }
}
