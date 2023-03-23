using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp0121_訂購系統
{
    public partial class OrderList : Form
    {
        string 外帶內用;
        double 打幾折;

        internal static List<int> listID = new List<int>();
        internal static List<string> listName = new List<string>();
        internal static List<int> listPrice = new List<int>();
        internal static List<int> listQuantity = new List<int>();
        internal static List<string> listSweet = new List<string>();
        internal static List<string> listIce = new List<string>();
        internal static List<string> listSpicy = new List<string>();
        internal static List<int> listItemTotalPrice = new List<int>();
        internal static List<string> listTable = new List<string>();
        int newPoint =0;

        internal static List<ArrayList> listItemDetail = new List<ArrayList>();

        public OrderList()
        {
            InitializeComponent();
        }

        internal void OrderList_Load(object sender, EventArgs e)
        {
            打幾折 = 1;
            lbl折扣內容.Text = "";
            lbl訂購人資料.Text = "訂購人" + GlobalVar.訂購人資訊;
            if (GlobalVar.訂購人資訊 != "")
            {
                ReadShopDataBase(); //讀取資料庫
                NewItemFromMenuAdd(); //增加或更新列表
                ReadDataBaseForSQLID("s_id", "Shop");
                if(GlobalVar.SQLShopID == 0) 
                { 
                    ShopDataNew("Shop");
                    ReadDataBaseForSQLID("s_id", "Shop");
                }
                ShowListViewPitcureMode(); //listView
            }
            radio外帶.Checked = true;
            radio購物袋需要.Checked = true;
            lblTable.Visible = false;
            計算總價();
            if (Table.TableName != "")
            {
                lblTable.Text = Table.TableName;
                lblTable.Visible = true;
                btnEatInSpace.Visible = false;
            }
            else
            {
                lblTable.Text = "";
                lblTable.Visible = false;
                btnEatInSpace.Visible = true;
            }

        }


        #region 清除項目(單筆或是全部)
        private void btn移除所選品項_Click(object sender, EventArgs e)
        {
            if (listViewShopDetail.SelectedIndices.Count > 0)
            {
                int index = listViewShopDetail.SelectedIndices[0];
                for (int i = (listViewShopDetail.SelectedIndices.Count - 1); i >= 0; i -= 1)
                {
                    //GlobalVar.list訂購品項資料.RemoveAt(listViewShopDetail.SelectedIndices[i]);
                    ShopDetailDelete(listID[index]);
                    listViewShopDetail.Items.RemoveAt(listViewShopDetail.SelectedIndices[i]);
                    if ((listIce[index] == "") && (listSpicy[index] == "") && (listSweet[index] == "")) { GlobalVar.ComboFood = false; }
                    listID.RemoveAt(index);
                    listName.RemoveAt(index);
                    listPrice.RemoveAt(index);
                    listQuantity.RemoveAt(index);
                    listSweet.RemoveAt(index);
                    listIce.RemoveAt(index);
                    listSpicy.RemoveAt(index);
                    listItemTotalPrice.RemoveAt(index);
                }

                計算總價();
            }
            else { MessageBox.Show("請選擇移除品項"); }
        }

        private void btn清空所有品項_Click(object sender, EventArgs e)
        {
            ShopDetailDeleteDataNew();
            listViewShopDetail.Items.Clear();
            GlobalVar.is內用 = false;
            GlobalVar.is買購物袋 = false;
            GlobalVar.ComboFood = false;
            listID.Clear();
            listName.Clear();
            listPrice.Clear();
            listQuantity.Clear();
            listSweet.Clear();
            listIce.Clear();
            listSpicy.Clear();
            listItemTotalPrice.Clear();
            radio購物袋不需要.Checked = true;
            計算總價();
        }
        #endregion
        #region 清空指定的資料ShopDetailDelete(int ProductID)
        internal void ShopDetailDelete(int ProductID)
        {
            SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
            con.Open();

            string strDelete = "delete from ShopDetail where ProductID = @DeleteID;";
            SqlCommand cmd = new SqlCommand(strDelete, con);
            cmd.Parameters.AddWithValue("@DeleteID", ProductID);
            int b = cmd.ExecuteNonQuery();
            Console.WriteLine($"刪除{0}筆", b);

            con.Close();

        }
        #endregion

        #region 計算總價
        void 計算總價()
        {
            int 總價 = 0;
            double 原價 = 0;
            打幾折 = GlobalVar.折扣;
            Console.WriteLine(打幾折);
            for (int i = 0; i < listID.Count; i++) { 原價 += listItemTotalPrice[i]; }
            if ((GlobalVar.Permission > 1000) && (GlobalVar.Permission <= 10000))
            {
                總價 = Convert.ToInt32(Math.Ceiling(原價 * 打幾折 * 0.95));
                if (GlobalVar.is買購物袋 == true)
                {
                    string 購物袋 = "3";

                    GlobalVar.總價 = 總價 + 3;
                    lbl訂單總價.Text = String.Format($"訂單總價: {總價}元(會員九五折) + 購物袋{購物袋}元");
                    lbl折扣內容.Text = "折扣: " + GlobalVar.折扣字;
                }
                else
                {
                    GlobalVar.總價 = 總價;
                    lbl訂單總價.Text = String.Format($"訂單總價: {總價}元(會員九五折)");

                }
            }
            else
            {
                總價 = Convert.ToInt32(Math.Ceiling(原價 * 打幾折 * 0.8));
                if (GlobalVar.is買購物袋 == true)
                {
                    string 購物袋 = "3";

                    GlobalVar.總價 = 總價 + 3;
                    lbl訂單總價.Text = String.Format($"訂單總價: {總價}元(員工八折) + 購物袋{購物袋}元");
                    lbl折扣內容.Text = "折扣: " + GlobalVar.折扣字;
                }
                else
                {
                    GlobalVar.總價 = 總價;
                    lbl訂單總價.Text = String.Format($"訂單總價: {總價}元(員工八折)");

                }
            }
        }
        #endregion

        #region 送出
        private void btn送出_Click(object sender, EventArgs e)
        {
            if (listID.Count != 0)
            {
                DialogResult R = MessageBox.Show("你確定要送出嗎?", "送出確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    if (GlobalVar.is內用 == true)
                    {
                        MessageBox.Show($"你的內用餐點製作當中，位置{Table.TableName}幫你預留十分鐘，歡迎前來用餐");
                        OrderDataNew();
                        ReadDataBaseForSQLID("OrderID", "Orders");
                        OrderDetailDataNew();
                        ReadDataBaseForSQLID("s_id", "Shop");
                        ShopDetailDeleteDataNew();
                        listID.Clear();
                        listName.Clear();
                        listPrice.Clear();
                        listQuantity.Clear();
                        listSweet.Clear();
                        listIce.Clear();
                        listSpicy.Clear();
                        listItemTotalPrice.Clear();
                        listItemDetail.Clear();
                        listViewShopDetail.Items.Clear();
                        Table.TableName = "";
                        GlobalVar.折扣 = 1;
                        GlobalVar.折扣字 = "";
                        GlobalVar.總價 = 0;
                        GlobalVar.ComboFood = false;
                        radio外帶.Checked = true;
                        radio購物袋需要.Checked = true;
                        計算總價();
                        GlobalVar.SQLShopID = 0;
                        //this.Close();
                    }
                    else
                    {
                        MessageBox.Show("你的外帶餐點製作當中，請稍等");
                        OrderDataNew();
                        ReadDataBaseForSQLID("OrderID", "Orders");
                        OrderDetailDataNew();
                        ReadDataBaseForSQLID("s_id", "Shop");
                        ShopDetailDeleteDataNew();
                        Table.TableName = "";
                        listID.Clear();
                        listName.Clear();
                        listPrice.Clear();
                        listQuantity.Clear();
                        listSweet.Clear();
                        listIce.Clear();
                        listSpicy.Clear();
                        listItemTotalPrice.Clear();
                        listItemDetail.Clear();
                        listViewShopDetail.Items.Clear();
                        GlobalVar.ComboFood = false;
                        GlobalVar.折扣 = 1;
                        GlobalVar.折扣字 = "";
                        GlobalVar.總價 = 0;
                        radio外帶.Checked = true;
                        radio購物袋需要.Checked = true;
                        計算總價();
                        GlobalVar.SQLShopID = 0;
                        //this.Close();

                    }
                }
            }
            else { MessageBox.Show("購物車空空 懇請點選菜色"); }
        }
        #endregion

        #region 購物袋以及外帶
        private void radio購物袋需要_CheckedChanged(object sender, EventArgs e)
        {
            if (radio購物袋需要.Checked == true)
            {
                GlobalVar.is買購物袋 = true;
                計算總價();

            }
            else
            {
                GlobalVar.is買購物袋 = false;
                計算總價();
            }
        }
        private void OrderList_Activated(object sender, EventArgs e)
        {
            if (Table.TableName != "")
            {
                btnEatInSpace.Enabled = false;
                btnEatInSpace.Visible = false;
                lblTable.Visible = true;
                lblTable.Text = Table.TableName;
            }
            else
            {
                btnEatInSpace.Enabled = true;
                btnEatInSpace.Visible = true;
                lblTable.Visible = false;
            }
            if (GlobalVar.is內用 == false)
            {
                radio外帶.Checked = true;
                radio內用.Checked = false;
                外帶內用 = "外帶";
            }
            else
            {
                radio內用.Checked = true;
                radio外帶.Checked = false;
                外帶內用 = "內用";
            }
        }
        private void radio購物袋不需要_CheckedChanged(object sender, EventArgs e)
        {
            if (radio購物袋不需要.Checked == true)
            {
                GlobalVar.is買購物袋 = false;
                計算總價();
            }
            else
            {
                GlobalVar.is買購物袋 = true;
                計算總價();
            }
        }
        private void radio內用_CheckedChanged(object sender, EventArgs e)
        {
            if (radio內用.Checked == true)
            {
                GlobalVar.is內用 = true;
                GlobalVar.is買購物袋 = false;
                radio購物袋需要.Visible = false;
                radio購物袋不需要.Visible = false;
                gbxShopBagYes.Visible = false;
                gbxEatIn.Visible = true;
                gbx外帶時間.Visible = false;
                計算總價();
                外帶內用 = "內用";
            }
            else
            {
                GlobalVar.is內用 = false;
                radio購物袋需要.Visible = true;
                radio購物袋不需要.Visible = true;
                gbxShopBagYes.Visible = true;
                gbxEatIn.Visible = false;
                gbx外帶時間.Visible = true;
                計算總價();
                外帶內用 = "外帶";
            }
        }
        private void radio外帶_CheckedChanged(object sender, EventArgs e)
        {
            if (radio外帶.Checked == true)
            {
                GlobalVar.is內用 = false;
                gbxShopBagYes.Visible = true;
                gbxEatIn.Visible = false;
                gbx外帶時間.Visible = true;
                if (radio購物袋不需要.Checked == true)
                {
                    GlobalVar.is買購物袋 = false;
                }
                else { GlobalVar.is買購物袋 = true; }
                外帶內用 = "外帶";
                計算總價();
            }
            else
            {
                gbxShopBagYes.Visible = false;
                gbxEatIn.Visible = true;
                gbx外帶時間.Visible = false;
                GlobalVar.is內用 = true;
                外帶內用 = "內用";
                計算總價();
            }
        }

        #endregion

        #region 輸出
        private void btn輸出txt_Click(object sender, EventArgs e)
        {
            string str檔案路徑 = @"C:\Users\iSpan\Desktop";
            Random myRnd = new Random();
            int rndNum = myRnd.Next(1000, 10000);
            string str檔名 = DateTime.Now.ToString("yyMMddHHmmss") + rndNum + "訂購檔.txt";
            string str完整檔案路徑 = str檔案路徑 + @"\" + str檔名;

            //輸出
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = str檔案路徑;
            sfd.FileName = str檔名;

            //以|隔開,右邊為任意名稱(*.),左邊為描述
            sfd.Filter = "Text File|*.txt";   //檔名確認

            DialogResult R = sfd.ShowDialog();

            if (R == DialogResult.OK)
            {
                str完整檔案路徑 = sfd.FileName;
            }
            else
            {
                return;
            }

            /////訂單內容存檔
            List<string> list訂單資訊 = new List<string>();
            list訂單資訊.Add("*****************餐飲店訂購單*****************");
            list訂單資訊.Add("---------------------------------------------");
            list訂單資訊.Add($"訂購時間: {DateTime.Now.ToString()} 訂購人: {GlobalVar.訂購人資訊}");
            list訂單資訊.Add("---------------------------------------------");
            list訂單資訊.Add("    <<<<<訂購品項>>>>>    ");
            for (int i = 0; i < listID.Count; i++)
            {
                int ID = listID[i];
                string 品項 = listName[i];
                int 單價 = listPrice[i];
                int 份數 = listQuantity[i];
                string 甜度 = listSweet[i];
                string 冰量 = listIce[i];
                string 辣度 = listSpicy[i];
                int 品項總價 = listItemTotalPrice[i];

                string 單品資料 = string.Format("{0} {1}元 {2}份 {3}{4}{5}{6} 品項總價: {7}元", 品項, 單價, 份數, 甜度, 冰量, 辣度, 品項總價);

                list訂單資訊.Add(單品資料);
            }
            list訂單資訊.Add("---------------------------------------------");
            if(GlobalVar.is內用==true)
            {
                外帶內用 = "內用 " + Table.TableName;
            }
            else
            {
                外帶內用 = "外帶";
            }
            list訂單資訊.Add(外帶內用);
            list訂單資訊.Add(GlobalVar.折扣字);
            list訂單資訊.Add($"{lbl訂單總價.Text}");
            list訂單資訊.Add("=============================================");
            list訂單資訊.Add("*****************謝謝光臨*****************");
            System.IO.File.WriteAllLines(str完整檔案路徑, list訂單資訊, Encoding.UTF8);
            MessageBox.Show("存檔成功");
        }
        #endregion

        #region 折扣按鈕
        private void btn折扣_Click(object sender, EventArgs e)
        {
            折扣抽獎 random = new 折扣抽獎();
            random.ShowDialog();
            計算總價();
        }
        #endregion

        #region Listview顯示
        void ShowListViewPitcureMode()
        {
            listViewShopDetail.Clear();
            listViewShopDetail.Items.Clear();
            listViewShopDetail.LargeImageList = null;
            listViewShopDetail.SmallImageList = null;

            listViewShopDetail.View = View.Details;
            //列表模式
            listViewShopDetail.Columns.Add("產品名稱", 120);
            listViewShopDetail.Columns.Add("價格", 50);
            listViewShopDetail.Columns.Add("甜度", 60);
            listViewShopDetail.Columns.Add("冰量", 60);
            listViewShopDetail.Columns.Add("辣度", 60);
            listViewShopDetail.Columns.Add("品項總價", 80);
            listViewShopDetail.GridLines = true;
            listViewShopDetail.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
            //標題與內容字體分開定義
            listViewShopDetail.FullRowSelect = true;

            for (int i = 0; i < listID.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();
                item.Font = new Font("標楷體", 9, FontStyle.Regular);
                //item.Text = listID[i].ToString();
                item.Text = listName[i].ToString();
                //item.SubItems.Add(listName[i]);
                item.SubItems.Add(listPrice[i].ToString());
                item.SubItems.Add(listSweet[i].ToString());
                item.SubItems.Add(listIce[i].ToString());
                item.SubItems.Add(listSpicy[i].ToString());
                item.SubItems.Add(listItemTotalPrice[i].ToString());

                item.Tag = listID[i];
                item.ForeColor = Color.DarkBlue;

                listViewShopDetail.Items.Add(item);
            }

        }
        #endregion

        #region 關閉前儲存
        private void OrderList_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (GlobalVar.訂購人資訊 != "")
            {
                ReadDataBaseForSQLID("s_id", "Shop");
                ShopDataNew("Shop");
                ShopDetailDeleteDataNew();
                ShopDetailDataNew();
                listID.Clear();
                listName.Clear();
                listPrice.Clear();
                listQuantity.Clear();
                listSweet.Clear();
                listIce.Clear();
                listSpicy.Clear();
                listItemTotalPrice.Clear();
                listViewShopDetail.Clear();
                listViewShopDetail.Controls.Clear();
            }


        }
        #endregion

        #region 讀取資料庫購物車ID ReadDataBaseForSQLID(string id, string Data)
        internal void ReadDataBaseForSQLID(string id, string Data)
        {
            try
            {
                SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                con.Open();
                string strSQL = "";
                if ((GlobalVar.Employee == true) || (GlobalVar.Director == true))
                {
                    strSQL = $"select {id} from {Data} Where EmployeeID = @searchID order by {id} desc";
                }
                else
                {
                    strSQL = $"select {id} from {Data} Where CustomerID = @searchID order by {id} desc";
                }
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@searchID", GlobalVar.訂購人ID);
                cmd.Parameters.AddWithValue("@Name", GlobalVar.訂購人資訊);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == false)
                { GlobalVar.SQLShopID = 0; }
                else 
                { GlobalVar.SQLShopID = (int)reader[$"{id}"]; }

                Console.WriteLine($"ID為{GlobalVar.SQLShopID}");
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
        #region ListView小圖顯示(未做完)
        public void ShowDrink()
        {
            listViewShopDetail.Clear();
            listViewShopDetail.View = View.SmallIcon;
            //LargeIcon大, SmallIcon小, List一列一列排, Tile只支援size40的small展示模式
            imgListOrder.ImageSize = new Size(40, 40);
            listViewShopDetail.LargeImageList = imgListOrder;
            Console.WriteLine($"圖片顯示飲料{imgListOrder.Images.Count}筆");

            for (int i = 0; i < imgListOrder.Images.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                //圖片索引
                item.Font = new Font("標楷體", 11, FontStyle.Regular);
                //字體
                item.Text = $"{listName[i]} {listPrice[i]}元 {listQuantity[i]}份{listSweet[i]}{listIce[i]}{listSpicy[i]} 品項總價: {listItemTotalPrice[i]}元";
                item.Tag = listID[i];
                //藏
                listViewShopDetail.Items.Add(item);
            }
        }
        #endregion

        #region 菜單新增加入購物車 NewItemFromMenuAdd()
        internal void NewItemFromMenuAdd()
        {
            foreach (var item in GlobalVar.list訂購品項資料)
            {
                var 訂購品項 = (ArrayList)item;
                listID.Add((int)訂購品項[0]);
                listName.Add(訂購品項[1].ToString());
                listPrice.Add(Convert.ToInt32(訂購品項[2]));
                listQuantity.Add((int)訂購品項[3]);
                listSweet.Add((string)訂購品項[4]);
                listIce.Add((string)訂購品項[5]);
                listSpicy.Add((string)訂購品項[6]);
                listItemTotalPrice.Add((int)訂購品項[7]);
            }
            GlobalVar.list訂購品項資料.Clear();
        }
        #endregion
        #region 讀取購物車ReadShopDataBase()
        internal void ReadShopDataBase()
        {
            try
            {
                SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                con.Open();
                string strSQL = "";
                if ((GlobalVar.Employee == true) || (GlobalVar.Director == true))
                {
                    strSQL = "select * from ShopDetail where ShopID in (select s_id from Shop Where EmployeeID = @searchID)";
                }
                else
                {
                    strSQL = "select * from ShopDetail where ShopID in (select s_id from Shop Where CustomerID = @searchID)";
                }
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@searchID", GlobalVar.訂購人ID);
                cmd.Parameters.AddWithValue("@Name", GlobalVar.訂購人資訊);
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read() == true)
                {
                    listID.Add((int)reader["ProductID"]);
                    listName.Add((string)reader["ProductName"]);
                    listPrice.Add((int)reader["UnitPrice"]);
                    listQuantity.Add((int)reader["Quantity"]);
                    listSweet.Add((string)reader["甜度"]);
                    listIce.Add((string)reader["冰量"]);
                    listSpicy.Add((string)reader["辣度"]);
                    listItemTotalPrice.Add((int)reader["品項總價"]);
                    count += 1;
                }
                Console.WriteLine($"讀取到購物車{count}筆資料");
                Console.WriteLine($"購物車{listID.Count}筆");
                //Console.WriteLine($"ID為{ GlobalVar.SQLShopID}");

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return ex;
            }
            for (int i = 0; i < listID.Count; i++)
            {
                ArrayList 單品項主菜訂購資訊 = new ArrayList();
                單品項主菜訂購資訊.Add(listID[i]);
                單品項主菜訂購資訊.Add(listName[i]);
                單品項主菜訂購資訊.Add(listPrice[i]);
                單品項主菜訂購資訊.Add(listQuantity[i]);
                單品項主菜訂購資訊.Add(listSweet[i]);
                單品項主菜訂購資訊.Add(listIce[i]);
                單品項主菜訂購資訊.Add(listSpicy[i]);
                單品項主菜訂購資訊.Add(listItemTotalPrice[i]);
                listItemDetail.Add(單品項主菜訂購資訊);
            }

        }
        #endregion

        #region 新增購物車資料ShopDataNew(string DataBase)
        internal void ShopDataNew(string DataBase)
        {
            SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
            con.Open();
            string strSQL = "";
            if (GlobalVar.SQLShopID == 0) //未有欄位須新增
            {
                if ((GlobalVar.Employee == true) || (GlobalVar.Director == true))
                {

                    strSQL = ($"insert　into {DataBase} (EmployeeID, Name, Phone, ShopDate, RequireDate, EatIn, ShopBagYes, TotalPrice) values(@NewEmpID, @NewName, @NewPhone, @NewShopDate, @NewRequireDate, @NewEatin, @NewShopBagYes, @NewTotalPrice);");
                }
                else
                {
                    strSQL = ($"insert　into {DataBase} (CustomerID, Name, Phone, ShopDate, RequireDate, EatIn, ShopBagYes, TotalPrice) values(@NewEmpID, @NewName, @NewPhone, @NewShopDate, @NewRequireDate, @NewEatin, @NewShopBagYes, @NewTotalPrice);");
                }
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewCusID", GlobalVar.訂購人ID);
                cmd.Parameters.AddWithValue("@NewEmpID", GlobalVar.訂購人ID);
                cmd.Parameters.AddWithValue("@NewName", GlobalVar.訂購人資訊);
                cmd.Parameters.AddWithValue("@NewPhone", GlobalVar.電話);
                cmd.Parameters.AddWithValue("@NewShopDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@NewRequireDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@NewEatin", GlobalVar.is內用);
                cmd.Parameters.AddWithValue("@NewShopBagYes", GlobalVar.is買購物袋);
                cmd.Parameters.AddWithValue("@NewTotalPrice", GlobalVar.總價);

                if (con.State == ConnectionState.Closed) { con.Open(); }
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
                //int rows = cmd.ExecuteNonQuery();
            }
            else  //已有欄位須更新
            {
                strSQL = "update Shop set ShopDate = @UpdateDate, RequireDate = @UpdateRequireDate, EatIn = @UpdateEatin, ShopBagYes = @UpdateBagYes, TotalPrice = @UpdateTotalPrice where s_id = @UpdateID;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@UpdateID", GlobalVar.SQLShopID);
                cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                if(GlobalVar.is內用==true)
                {
                    cmd.Parameters.AddWithValue("@UpdateRequireDate", dateTimePickerEatIn.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@UpdateRequireDate", dtp外帶時間.Value);
                }
                
                cmd.Parameters.AddWithValue("@UpdateEatin", GlobalVar.is內用);
                cmd.Parameters.AddWithValue("@UpdateBagYes", GlobalVar.is買購物袋);
                cmd.Parameters.AddWithValue("@UpdateTotalPrice", GlobalVar.總價);

                cmd.ExecuteNonQuery();

            }

            con.Close();

        }
        #endregion

        #region 清空ShopID內的資料ShopDetailDeleteDataNew()
        internal void ShopDetailDeleteDataNew()
        {
            SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
            con.Open();
            string strDelete = "";

            strDelete = "delete from ShopDetail where ShopID = @DeleteID;";
            SqlCommand ccc = new SqlCommand(strDelete, con);
            ccc.Parameters.AddWithValue("@DeleteID", GlobalVar.SQLShopID);
            int b = ccc.ExecuteNonQuery();
            Console.WriteLine($"刪除{b}筆");

            con.Close();

        }
        #endregion
        #region 更新購物車資料ShopDetailDataNew()
        internal void ShopDetailDataNew()
        {
            SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
            con.Open();
            string strSQLDetail = "";
            for (int i = 0; i < listID.Count; i++)
            {
                strSQLDetail = "insert　into ShopDetail (ShopID, ProductID, ProductName, UnitPrice, Quantity, 甜度, 冰量, 辣度, 品項總價) values(@NewShopID, @NewProductID, @NewProductName, @NewUnitPrice, @NewQuantity, @New甜度, @New冰量, @New辣度, @New品項總價);";

                SqlCommand cmd2 = new SqlCommand(strSQLDetail, con);
                cmd2.Parameters.AddWithValue("@NewShopID", GlobalVar.SQLShopID);
                cmd2.Parameters.AddWithValue("@NewProductID", listID[i]);
                cmd2.Parameters.AddWithValue("@NewProductName", listName[i]);
                cmd2.Parameters.AddWithValue("@NewUnitPrice", listPrice[i]);
                cmd2.Parameters.AddWithValue("@NewQuantity", listQuantity[i]);
                cmd2.Parameters.AddWithValue("@New甜度", listSweet[i]);
                cmd2.Parameters.AddWithValue("@New冰量", listIce[i]);
                cmd2.Parameters.AddWithValue("@New辣度", listSpicy[i]);
                cmd2.Parameters.AddWithValue("@New品項總價", listItemTotalPrice[i]);

                int rows = cmd2.ExecuteNonQuery();
                Console.WriteLine($"新增購物車資料{rows}筆");
            }
            //int rows = cmd2.ExecuteNonQuery();
            con.Close();
        }
        #endregion

        #region 新增訂單OrderDataNew()
        internal void OrderDataNew()
        {
            SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
            con.Open();
            string strSQL = "";
            if ((GlobalVar.Employee == true) || (GlobalVar.Director == true))
            {

                strSQL = "insert　into Orders (EmployeeID, [Table], ShopDate, RequireDate, EatIn, ShopBagYes, OrderCheck, TotalPrice, CancelOrder) values(@NewEmpID, @NewTable, @NewShopDate, @NewRequireDate, @NewEatin, @NewShopBagYes, @NewCheck, @NewTotalPrice, @NewCancelOrder);";
            }
            else
            {
                strSQL = "insert　into Orders (CustomerID, [Table], ShopDate, RequireDate, EatIn, ShopBagYes, OrderCheck, TotalPrice, CancelOrder) values(@NewCusID, @NewTable, @NewShopDate, @NewRequireDate, @NewEatin, @NewShopBagYes, @NewCheck,@NewTotalPrice, @NewCancelOrder);";
            }
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@NewCusID", GlobalVar.訂購人ID);
            cmd.Parameters.AddWithValue("@NewEmpID", GlobalVar.訂購人ID);
            if(GlobalVar.is內用==true)
            {
                cmd.Parameters.AddWithValue("@NewTable", lblTable.Text);
                //DateTime Time = dateTimePickerEatIn.Value.AddMinutes(30);
                //DateTime Time = DateTime.Now.AddMinutes(30);
                cmd.Parameters.AddWithValue("@NewRequireDate", dateTimePickerEatIn.Value);
            }
            else
            {
                string 外帶 = "外帶";
                cmd.Parameters.AddWithValue("@NewTable", 外帶);
               // DateTime Time = dtp外帶時間.Value.AddMinutes(30);
                cmd.Parameters.AddWithValue("@NewRequireDate", dtp外帶時間.Value);
            }
            cmd.Parameters.AddWithValue("@NewShopDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@NewEatin", GlobalVar.is內用);
            cmd.Parameters.AddWithValue("@NewShopBagYes", GlobalVar.is買購物袋);
            cmd.Parameters.AddWithValue("@NewCheck", false);
            cmd.Parameters.AddWithValue("@NewTotalPrice", GlobalVar.總價);
            cmd.Parameters.AddWithValue("@NewCancelOrder", false);
            int order = cmd.ExecuteNonQuery();
            Console.WriteLine($"新增訂單{order}筆");
            con.Close();

        }
        #endregion
        #region 新增訂單OrderDetailDataNew()
        internal void OrderDetailDataNew()
        {
            SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
            con.Open();
            string strSQLDetail = "";
            for (int i = 0; i < listID.Count; i++)
            {
                strSQLDetail = "insert　into OrderDetails (OrderID, ProductID, ProductName, UnitPrice, Quantity, 甜度, 冰量, 辣度, 品項總價) values(@NewOrderID, @NewProductID, @NewProductName, @NewUnitPrice, @NewQuantity, @New甜度, @New冰量, @New辣度, @New品項總價);";

                SqlCommand cmd2 = new SqlCommand(strSQLDetail, con);
                cmd2.Parameters.AddWithValue("@NewOrderID", GlobalVar.SQLShopID);
                cmd2.Parameters.AddWithValue("@NewProductID", listID[i]);
                cmd2.Parameters.AddWithValue("@NewProductName", listName[i]);
                cmd2.Parameters.AddWithValue("@NewUnitPrice", listPrice[i]);
                cmd2.Parameters.AddWithValue("@NewQuantity", listQuantity[i]);
                cmd2.Parameters.AddWithValue("@New甜度", listSweet[i]);
                cmd2.Parameters.AddWithValue("@New冰量", listIce[i]);
                cmd2.Parameters.AddWithValue("@New辣度", listSpicy[i]);
                cmd2.Parameters.AddWithValue("@New品項總價", listItemTotalPrice[i]);

                int orderdetail = cmd2.ExecuteNonQuery();
                Console.WriteLine($"新增訂單資料{orderdetail}筆");
            }
            con.Close();
        }


        #endregion

        private void OrderList_Activated_1(object sender, EventArgs e)
        {

        }

        private void btnEatInSpace_Click(object sender, EventArgs e)
        {
            Table tble = new Table();
            tble.ShowDialog();
            if (Table.TableName != "")
            {
                lblTable.Text = Table.TableName;
                lblTable.Visible = true;
                btnEatInSpace.Visible = false;
            }
            else 
            {
                lblTable.Text = "";
                lblTable.Visible = false;
                btnEatInSpace.Visible = true;
            }


        }

        #region 怪怪的時間
        private void dateTimePickerEatIn_ValueChanged(object sender, EventArgs e)
        {
            //DateTime selectedTime = dateTimePickerEatIn.Value;
            //int minute = selectedTime.Minute;

            //// 调整分钟数为最接近 15 分钟的整数
            //if (minute < 15)
            //{
            //    selectedTime = selectedTime.AddMinutes(15 - minute);
            //}
            //else if (minute >= 15 && minute < 30)
            //{
            //    selectedTime = selectedTime.AddMinutes(30 - minute);
            //}
            //else if (minute >= 30 && minute < 45)
            //{
            //    selectedTime = selectedTime.AddMinutes(45 - minute);
            //}
            //else if (minute >= 45)
            //{
            //    selectedTime = selectedTime.AddMinutes(60 - minute);
            //}

            //dateTimePickerEatIn.Value = selectedTime;
        }

        private void dtp外帶時間_ValueChanged(object sender, EventArgs e)
        {
            //DateTime selectedTime = dtp外帶時間.Value;
            //int minute = selectedTime.Minute;

            //// 调整分钟数为最接近 15 分钟的整数
            //if (minute < 15)
            //{
            //    selectedTime = selectedTime.AddMinutes(15 - minute);
            //}
            //else if (minute >= 15 && minute < 30)
            //{
            //    selectedTime = selectedTime.AddMinutes(30 - minute);
            //}
            //else if (minute >= 30 && minute < 45)
            //{
            //    selectedTime = selectedTime.AddMinutes(45 - minute);
            //}
            //else if (minute >= 45)
            //{
            //    selectedTime = selectedTime.AddMinutes(60 - minute);
            //}

            //dtp外帶時間.Value = selectedTime;
        }
        #endregion


    }
}
