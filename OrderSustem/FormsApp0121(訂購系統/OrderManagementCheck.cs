using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using Button = System.Windows.Forms.Button;

namespace FormsApp0121_訂購系統
{
    public partial class OrderManagementCheck : Form
    {
        internal List<int> listID = new List<int>();
        internal List<string> listName = new List<string>();
        internal List<string> listPhone = new List<string>();
        internal List<DateTime> listShopDate = new List<DateTime>();
        internal List<DateTime> listRequireDate = new List<DateTime>();
        internal List<bool> listEatIn = new List<bool>();
        internal List<bool> listShopBagYes = new List<bool>();
        internal List<bool> listCheck = new List<bool>();
        internal List<int> listTotalPrice = new List<int>();

        internal int DailyTurnover = 0;
        internal int MonthTurnover = 0; 


        public OrderManagementCheck()
        {
            InitializeComponent();
        }

        private void OrderManagementCheck_Load(object sender, EventArgs e)
        {
            //ReadDataBaseOrder("*","Where OrderCheck = 0",0);
            FlowLayOutPanel("where CancelOrder = 0 ");
            //ShowListViewListMode();
            //TimeOut();
            營業額();
        }

        #region 讀取資料庫ReadDataBaseOrder(string SQL)
        internal void ReadDataBaseOrder(string Need,string SQL, int choose)
        {
            try
            {
                SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                con.Open();
                string strSQL = ($"select {Need} from Orders {SQL}");
                SqlCommand cmd = new SqlCommand(strSQL, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                switch (choose)
                {
                    case 0:
                        while (reader.Read() == true)
                        {
                            listID.Add((int)reader["OrderID"]);
                            listName.Add(reader["Name"].ToString());
                            listPhone.Add(reader["Phone"].ToString());
                            listShopDate.Add(Convert.ToDateTime(reader["ShopDate"]));
                            listRequireDate.Add(Convert.ToDateTime(reader["RequireDate"]));
                            listEatIn.Add(Convert.ToBoolean(reader["EatIn"]));
                            listShopBagYes.Add(Convert.ToBoolean(reader["ShopBagYes"]));
                            listCheck.Add(Convert.ToBoolean(reader["OrderCheck"]));
                            listTotalPrice.Add((int)reader["TotalPrice"]);

                            count += 1;
                        }
                        Console.WriteLine($"讀取到訂單{count}筆資料");
                        Console.WriteLine($"訂單{listID.Count}筆");
                        break;
                    case 1:
                        if (reader.Read() == true)
                        {
                            DailyTurnover = (int)reader["Price"];
                        }
                        break;
                    case 2:
                        if (reader.Read() == true)
                        {
                            MonthTurnover = (int)reader["Price"];
                        }
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

        #region Listview顯示 ShowListViewListMode() (取消)
        //void ShowListViewListMode()
        //{
        //    listViewOrder.Clear();
        //    listViewOrder.Items.Clear();
        //    listViewOrder.LargeImageList = null;
        //    listViewOrder.SmallImageList = null;

        //    listViewOrder.View = View.Details;
        //    //列表模式
        //    listViewOrder.Columns.Add("確認", 30);
        //    listViewOrder.Columns.Add("編號", 50);
        //    listViewOrder.Columns.Add("姓名", 70);
        //    listViewOrder.Columns.Add("電話", 90);
        //    listViewOrder.Columns.Add("訂購日期", 160);
        //    listViewOrder.Columns.Add("需求日期", 160);
        //    listViewOrder.Columns.Add("內用", 50);
        //    listViewOrder.Columns.Add("購物袋", 60);
        //    listViewOrder.Columns.Add("訂單確認", 70);
        //    listViewOrder.Columns.Add("訂單總金額", 80);
        //    listViewOrder.Columns.Add("經過時間", 100);
        //    listViewOrder.GridLines = true;
        //    listViewOrder.Font = new Font("微軟正黑體", 10, FontStyle.Bold);
        //    listViewOrder.CheckBoxes = true;
        //    //標題與內容字體分開定義
        //    listViewOrder.FullRowSelect = true;
        //    for (int i = 0; i < listID.Count; i += 1)
        //    {
        //        ListViewItem item = new ListViewItem();
        //        item.Font = new Font("標楷體", 9, FontStyle.Regular);
        //        //item.Text = listID[i].ToString();
        //        item.SubItems.Add(listID[i].ToString());
        //        item.SubItems.Add(listName[i]);
        //        item.SubItems.Add(listPhone[i].ToString());
        //        item.SubItems.Add(listShopDate[i].ToString());
        //        item.SubItems.Add(listRequireDate[i].ToString());
        //        item.SubItems.Add(listEatIn[i].ToString());
        //        item.SubItems.Add(listShopBagYes[i].ToString());
        //        item.SubItems.Add(listCheck[i].ToString());
        //        item.SubItems.Add(listTotalPrice[i].ToString());
        //        DateTime endTime = DateTime.Now;
        //        TimeSpan Time = endTime - listShopDate[i];
        //        item.SubItems.Add(Time.ToString());
        //        if (listCheck[i] == false) { item.Checked = false; }
        //        else { item.Checked = true; }

        //        //第一欄Text第二欄都為subItems
        //        item.Tag = listID[i];
        //        item.ForeColor = Color.DarkBlue;

        //        listViewOrder.Items.Add(item);
        //    }

        //}


        #endregion
        #region 超時(取消)
        //void TimeOut()
        //{
        //    TimeSpan timeout = TimeSpan.FromMinutes(30);

        //    foreach (ListViewItem item in listViewOrder.Items)
        //    {
        //        // 讀取該行的時間欄位
        //        DateTime time = Convert.ToDateTime(item.SubItems[4].Text);
        //        //Console.WriteLine(item.SubItems[2].Text);

        //        // 計算時間差
        //        TimeSpan timeDiff = DateTime.Now - time;

        //        // 如果超時，就將文字顏色設置為紅色
        //        if (timeDiff > timeout)
        //        {
        //            item.BackColor = Color.Red;
        //        }
        //    }
        //}
        #endregion
        #region ListView勾選(取消)
        //private void listViewOrder_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    ListViewItem item = listViewOrder.Items[e.Index];

        //    // 更新該列中的 Age 欄位
        //    if (e.NewValue == CheckState.Checked)
        //    {
        //        item.SubItems[8].Text = "True";
        //        OrderCheck(true, item.Tag);
        //    }
        //    else
        //    {
        //        item.SubItems[8].Text = "False";
        //        OrderCheck(false, item.Tag);
        //    }

        //    // 重新整理 ListView 控制項
        //    listViewOrder.Refresh();
        //    FlowLayOutPanel("Where OrderCheck = 0");
        //}
        #endregion

        private void OrderManagementCheck_Activated(object sender, EventArgs e)
        {
            //TimeOut();
            營業額();
        }

        private void btn今日訂單_Click(object sender, EventArgs e)
        {
            重新整理();
            int Day = DateTime.Now.Day;
            //ReadDataBaseOrder("*","",0);
            FlowLayOutPanel($"Where day(ShopDate) = {Day} and CancelOrder = 0");
            //ShowListViewListMode();
            //TimeOut();
        }

        private void btn今日完成_Click(object sender, EventArgs e)
        {
            重新整理();
            //ReadDataBaseOrder("*","Where OrderCheck = 1",0);
            FlowLayOutPanel("Where OrderCheck = 1 and CancelOrder = 0");
            //ShowListViewListMode();
            //TimeOut();
        }

        private void btn今日待完成_Click(object sender, EventArgs e)
        {
            重新整理();
            //ReadDataBaseOrder("*","Where OrderCheck = 0",0);
            FlowLayOutPanel("Where OrderCheck = 0 and CancelOrder = 0");
            //ShowListViewListMode();
            //TimeOut();

        }
        private void btn本月訂單_Click(object sender, EventArgs e)
        {
            int month = DateTime.Now.Month;
            重新整理();
            FlowLayOutPanel($"Where month(ShopDate) = {month}");
        }


        #region 資料修改 OrderCheck()
        void OrderCheck(bool Check, object b)
        {
            //int selectedID = listID[listViewOrder.SelectedItems[1].Index];

            SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
            con.Open();

            string strSQL = "update Orders　set OrderCheck = @UpdateCheck where OrderID = @SearchID;";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@UpdateCheck", Check);
            cmd.Parameters.AddWithValue("@SearchID", b);

            int rows = cmd.ExecuteNonQuery();
            //執行查詢

            con.Close();
            Console.WriteLine($"資料修改完畢,{rows}筆資料受影響");

        }
        #endregion
        #region 資料修改 OrderCnacel(bool Check, object b)
        void OrderCnacel(bool Check, object b)
        {
            //int selectedID = listID[listViewOrder.SelectedItems[1].Index];

            SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
            con.Open();

            string strSQL = "update Orders　set CancelOrder = @UpdateCheck where OrderID = @SearchID;";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@UpdateCheck", Check);
            cmd.Parameters.AddWithValue("@SearchID", b);

            int rows = cmd.ExecuteNonQuery();
            //執行查詢

            con.Close();
            Console.WriteLine($"資料修改完畢,{rows}筆資料受影響");

        }
        #endregion

        #region 重新整理()
        void 重新整理()
        {
            listID.Clear();
            listName.Clear();
            listPhone.Clear();
            listShopDate.Clear();
            listRequireDate.Clear();
            listTotalPrice.Clear();
            listEatIn.Clear();
            listShopBagYes.Clear();
            listCheck.Clear();
        }
        #endregion

        #region 營業額
        void 營業額()
        {
            int month = DateTime.Now.Month;
            int Day = DateTime.Now.Day;
            ReadDataBaseOrder("isnull(sum(TotalPrice), 0) as Price", $"where day(ShopDate) = {Day} and CancelOrder = 0", 1);
            lblToday.Text = DailyTurnover.ToString();
            ReadDataBaseOrder("isnull(sum(TotalPrice), 0) as Price", $"where month(ShopDate) = {month} and CancelOrder = 0", 2);

            lblMonth.Text = MonthTurnover.ToString();

        }
        #endregion


        #region 試試看 FlowLayOutPanel(string SQL)
        void FlowLayOutPanel(string SQL)
        {
            flowLayoutPanelOrder.Controls.Clear();
            flowLayoutPanelOrder.PerformLayout();
            
            try
            { 
                SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                con.Open();
                string strSQL = ($"select * from Orders {SQL}");
                SqlCommand cmd = new SqlCommand(strSQL, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                FlowLayoutPanel p1;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    p1 = new FlowLayoutPanel();
                    p1.AutoSize = true;
                    p1.Width = 10;
                    p1.Height = 10;
                    p1.FlowDirection = FlowDirection.TopDown;
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.Margin = new Padding(10, 10, 10, 10);

                    FlowLayoutPanel p2 = new FlowLayoutPanel();
                    p2 = new FlowLayoutPanel();
                    p2.BackColor = Color.FromArgb(50, 55, 89);
                    p2.AutoSize = true;
                    p2.Width = 130;
                    p2.Height = 85;
                    p2.FlowDirection = FlowDirection.TopDown;
                    p2.Margin = new Padding(0, 0, 0, 0);

                    Label lbl1 = new Label();
                    lbl1.ForeColor = Color.White;
                    lbl1.Margin = new Padding(10, 10, 3, 0);
                    lbl1.AutoSize = true;


                    Label lbl2 = new Label();
                    lbl2.ForeColor = Color.White;
                    lbl2.Margin = new Padding(10, 5, 3, 0);
                    lbl2.AutoSize = true;

                    Label lbl3 = new Label();
                    lbl3.ForeColor = Color.White;
                    lbl3.Margin = new Padding(10, 5, 3, 0);
                    lbl3.AutoSize = true;

                    Label lbl4 = new Label();
                    lbl4.ForeColor = Color.White;
                    lbl4.Margin = new Padding(10, 5, 3, 0);
                    lbl4.AutoSize = true;

                    lbl1.Text = "Table: " + dt.Rows[i]["Table"].ToString();
                    lbl2.Text = "OrderTime: " + dt.Rows[i]["ShopDate"].ToString();
                    if(dt.Rows[i]["EatIn"].ToString() == "False")
                    {
                        lbl3.Text = "Eatin: " + dt.Rows[i]["EatIn"].ToString();
                    }
                    else
                    {
                        lbl3.Text = "Eatin: " + dt.Rows[i]["EatIn"].ToString();
                    }
                    
                    lbl4.Text = "Check: " + dt.Rows[i]["OrderCheck"].ToString();

                    p2.Controls.Add(lbl1);
                    p2.Controls.Add(lbl2);
                    p2.Controls.Add(lbl3);
                    p2.Controls.Add(lbl4);

                    p1.Controls.Add(p2);

                    int mid = 0;
                    mid = Convert.ToInt32(dt.Rows[i]["OrderID"].ToString());
                    string strSQL2 = ($"select * from OrderDetails Where OrderID = {mid}");
                    SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    da2.Fill(dt2);

                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        Label lbl5 = new Label();
                        lbl5.ForeColor = Color.Black;
                        lbl5.Margin = new Padding(15, 5, 3, 0);
                        lbl5.Font = new Font("標楷體", 11, FontStyle.Regular);
                        //lbl5.AutoSize = true;
                        lbl5.Size = new Size(250, 15);
                        int no = j + 1;
                        lbl5.Text = no + "." + dt2.Rows[j]["ProductName"].ToString() + " " + dt2.Rows[j]["Quantity"].ToString() + "份" + dt2.Rows[j]["甜度"].ToString() + dt2.Rows[j]["冰量"].ToString() + " " + dt2.Rows[j]["辣度"].ToString();

                        p1.Controls.Add(lbl5);
                    }
                    if ((dt.Rows[i]["OrderCheck"].ToString() == "False")&& (dt.Rows[i]["CancelOrder"].ToString() == "False"))
                    {
                        Button bt = new Button();
                        bt.Size = new Size(80, 35);
                        bt.BackColor = Color.FromArgb(241, 85, 126);
                        bt.Margin = new Padding(30, 5, 3, 10);
                        bt.Text = "Complete";
                        bt.Tag = dt.Rows[i]["OrderID"].ToString();

                        bt.Click += new EventHandler(b_click);
                        p1.Controls.Add(bt);
                    }
                    else if ((dt.Rows[i]["OrderCheck"].ToString() == "True") && (dt.Rows[i]["CancelOrder"].ToString() == "False"))
                    {
                        Button ct = new Button();
                        ct.Size = new Size(80, 35);
                        ct.BackColor = Color.Blue;
                        ct.Margin = new Padding(140, 5, 3, 10);
                        ct.Text = "Reply";
                        ct.Tag = dt.Rows[i]["OrderID"].ToString();

                        ct.Click += new EventHandler(c_click);
                        p1.Controls.Add(ct);
                    }

                    if (dt.Rows[i]["CancelOrder"].ToString() == "False")
                    {
                        Button et = new Button();
                        et.Size = new Size(80, 35);
                        et.BackColor = Color.Red;
                        et.Margin = new Padding(30, 3, 3, 10);
                        et.Text = "Cancel";
                        et.Tag = dt.Rows[i]["OrderID"].ToString();

                        et.Click += new EventHandler(e_click);
                        p1.Controls.Add(et);
                    }

                        flowLayoutPanelOrder.Controls.Add(p1);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return ex;
            }
        }
        #endregion
        #region 完成訂單
        private void b_click(object sender, EventArgs e)
        {
            int mid = Convert.ToInt32((sender as Button).Tag.ToString());

            DialogResult R = MessageBox.Show("確定完成了嗎?", "送出確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (R == DialogResult.Yes)
            {
                OrderCheck(true, mid);
                FlowLayOutPanel("Where OrderCheck = 0");
            }
            (sender as Button).BackColor = Color.DarkGray;
        }
        #endregion
        #region 回復訂單
        private void c_click(object sender, EventArgs e)
        {
            int mid = Convert.ToInt32((sender as Button).Tag.ToString());

            DialogResult R = MessageBox.Show("確定回復?", "送出確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (R == DialogResult.Yes)
            {
                OrderCheck(false, mid);
                FlowLayOutPanel("Where OrderCheck = 0 and CancelOrder = 0");
            }
            (sender as Button).BackColor = Color.DarkGray;
            營業額();
        }
        #endregion
        #region 取消訂單
        private void e_click(object sender, EventArgs e)
        {
            int mid = Convert.ToInt32((sender as Button).Tag.ToString());

            DialogResult R = MessageBox.Show("確定取消?", "送出確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (R == DialogResult.Yes)
            {
                OrderCnacel(true, mid);
                FlowLayOutPanel("Where OrderCheck = 0 and CancelOrder = 0");
            }
            營業額();
        }
        #endregion

       
    }
}
