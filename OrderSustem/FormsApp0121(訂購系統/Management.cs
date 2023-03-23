using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using System.Data.SqlClient;
using System.Security;

namespace FormsApp0121_訂購系統
{
    public partial class Management : Form
    {
        Function.Function function = new Function.Function();
        List<string> FindChange = new List<string>();
        List<int> SearchIDs = new List<int>();
        public int selectID = 0;
        string image_name = "";
        bool PictureSave = false;
        int Continue = 0;
        internal List<int> listID = new List<int>();
        internal List<string> listName = new List<string>();
        internal List<string> listType = new List<string>();
        internal List<int> listPrice = new List<int>();
        internal List<int> listStock = new List<int>();
        internal List<string> listDescribe = new List<string>();
        internal List<bool> listContinued = new List<bool>();
        internal List<string> listPicture = new List<string>();
        internal List<string> listUnit = new List<string>();


        public Management()
        {
            InitializeComponent();
        }

        private void Management_Load(object sender, EventArgs e)
        {
            //資料欄位
            cbxType.Items.Add("請選擇");
            cbxType.Items.Add("牛");
            cbxType.Items.Add("豬");
            cbxType.Items.Add("雞");
            cbxType.Items.Add("蔬菜");
            cbxType.Items.Add("月亮");
            cbxType.Items.Add("海鮮");
            cbxType.Items.Add("沙律");
            cbxType.Items.Add("酥炸");
            cbxType.Items.Add("湯");
            cbxType.Items.Add("主食");
            cbxType.Items.Add("飲料");
            cbxType.Items.Add("甜點");
            //搜尋
            cbx欄位關鍵字搜尋.Items.Add("名稱");
            cbx欄位關鍵字搜尋.Items.Add("種類");
            cbx欄位關鍵字搜尋.Items.Add("下架");
            cbx欄位關鍵字搜尋.Items.Add("庫存");
            FindChange.Add("p_name");
            FindChange.Add("p_type");
            FindChange.Add("p_discontinued");
            FindChange.Add("p_instock");

            ReadDataBasePicture();
            ShowListViewListMode();
            //預設
            cbxType.SelectedIndex = 0;
            radioAll.Enabled = false;
            radioContinue.Enabled = false;
            radioNoContinue.Enabled = false;
            radioAll.Visible = false;
            radioContinue.Visible = false;
            radioNoContinue.Visible = false;
        }


        #region 飲料冰量
        internal static void TheIce()
        {
            GlobalVar.listIce.Add("正常");
            GlobalVar.listIce.Add("熱");
            GlobalVar.listIce.Add("少冰");
            GlobalVar.listIce.Add("去冰");
            GlobalVar.listIce.Add("冰另外放");
        }
        #endregion
        #region 飲料甜度
        internal static void TheSweet()
        {
            GlobalVar.listSweet.Add("正常");
            GlobalVar.listSweet.Add("半糖");
            GlobalVar.listSweet.Add("微糖");
            GlobalVar.listSweet.Add("糖另外放");
        }
        #endregion
        #region 菜色辣度
        internal static void TheSpicy()
        {
            GlobalVar.listSpicy.Add("不辣");
            GlobalVar.listSpicy.Add("小辣");
            GlobalVar.listSpicy.Add("大辣");
            GlobalVar.listSpicy.Add("辣椒另外放");

        }
        #endregion
        #region 主廚推薦
        internal static void 主廚推薦()
        {
            GlobalVar.list主廚推薦.Add("雙人套餐");
            GlobalVar.list主廚推薦.Add("三人套餐");
            GlobalVar.list主廚推薦.Add("五人套餐");
            GlobalVar.list主廚價格.Add(1288);
            GlobalVar.list主廚價格.Add(2288);
            GlobalVar.list主廚價格.Add(3288);

        }
        #endregion     
               
        #region 回選單
        private void btn回選單_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 資料修改ok
        private void btn資料修改_Click(object sender, EventArgs e)
        {
            int intID = 0;
            Int32.TryParse(lblID.Text, out intID);

            if ((intID > 0) && (txtProductName.Text != "") && (cbxType.SelectedIndex != 0)&& (txtPrice.Text != "") && (txtStock.Text != "") && (txtPicture.Text != ""))
            {
                SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                con.Open();

                string Type = cbxType.SelectedItem.ToString();
                string strSQL = "update Products　set p_name = @UpdateName, p_type = '"+ Type + "', p_price = @UpdatePrice, p_image = @UpdateImage, p_discontinued = @UpdateDiscontinue, p_describe = @UpdateDecribe, p_instock = @UpdateStock where p_id = @SearchID;";

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@UpdateName", txtProductName.Text.Trim());
                int intPrice = 0;
                Int32.TryParse(txtPrice.Text.Trim(), out intPrice);
                cmd.Parameters.AddWithValue("@UpdatePrice", txtPrice.Text.Trim());
                cmd.Parameters.AddWithValue("@UpdateImage", txtPicture.Text.Trim());
                cmd.Parameters.AddWithValue("@UpdateDiscontinue", chkContinues.Checked);
                cmd.Parameters.AddWithValue("@UpdateDecribe", txtDecribe.Text.Trim());
                int intInstock = 0;
                Int32.TryParse(txtStock.Text.Trim(), out intInstock);
                cmd.Parameters.AddWithValue("@UpdateStock", intInstock);
                cmd.Parameters.AddWithValue("@SearchID", intID);

                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show($"資料修改完畢,{rows}筆資料受影響");
                清空欄位();
                重新整理();
            }
            else
            {
                MessageBox.Show("產品名稱、種類、價格、產品庫存、圖片名稱請填寫");
            }
        }
        #endregion

        #region 新增資料ok
        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "檔案類型 (*.jpg, *.jpeg, *.png)|*.jpeg;*.jpg;*.png";

            DialogResult R = f.ShowDialog();

            if (R == DialogResult.OK)
            {
                pbxPicture.Image = Image.FromFile(f.FileName);
                // f.SafeFileName 檔名
                Size = new Size(1316, 636);
                string 檔案副檔名 = System.IO.Path.GetExtension(f.SafeFileName);
                Random myRand = new Random();
                image_name = DateTime.Now.ToString("yyyyMMddHHmmss") + myRand.Next(1000, 10000).ToString() + 檔案副檔名;
                PictureSave = true;
                txtPicture.Text = image_name;
                Console.WriteLine(image_name);
            }
        }

        private void btn新增資料_Click(object sender, EventArgs e)
        {
            if (PictureSave == true)
            {
                txtPicture.Enabled = false;
                if ((txtProductName.Text != "") && (cbxType.SelectedIndex > 0) && (txtPrice.Text != "") && (txtStock.Text != ""))
                {
                    if (PictureSave == true)
                    {
                        pbxPicture.Image.Save(GlobalVar.image_dir + image_name);
                        Size = new Size(1020, 636);
                        PictureSave = false;
                    }
                    SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                    con.Open();
                    string Type = cbxType.SelectedItem.ToString();
                    string strSQL = "insert　into Products　values(@NewName, @NewType, @NewPrice, @NewIamge, @NewUnit, @NewDiscontinue, @NewDecribe, @NewStock);";

                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@NewName",txtProductName.Text.Trim());
                    cmd.Parameters.AddWithValue("@NewType", Type);
                    int intPrice = 0;
                    Int32.TryParse(txtPrice.Text.Trim(), out intPrice);
                    cmd.Parameters.AddWithValue("@NewPrice", intPrice);
                    cmd.Parameters.AddWithValue("@NewIamge", txtPicture.Text);
                    string Unit = "";
                    cmd.Parameters.AddWithValue("@NewUnit", Unit);
                    cmd.Parameters.AddWithValue("@NewDiscontinue", chkContinues.Checked);
                    cmd.Parameters.AddWithValue("@NewDecribe", txtDecribe.Text.Trim());
                    int intStock = 0;
                    Int32.TryParse(txtStock.Text.Trim(), out intStock);
                    cmd.Parameters.AddWithValue("@NewStock", intStock);

                    int rows = cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show($"資料儲存成功, 影響{rows}筆資料");
                    txtPicture.Enabled = true;


                    清空欄位();
                    重新整理();
                }
                else
                {
                    MessageBox.Show("姓名,電話以及密碼必填");
                }
            }
            else { MessageBox.Show("請先新增圖片"); }
        }
        #endregion

        #region 刪除資料ok
        private void btn刪除資料_Click(object sender, EventArgs e)
        {
            int intID = 0;
            Int32.TryParse(lblID.Text.Trim(), out intID);

            if (intID > 0)
            {
                DialogResult R = MessageBox.Show("你確定要刪除此商品?", "關閉確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (R == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                    con.Open();
                    string strSQL = "delete from Products where p_id = @DeleteID;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@DeleteID", intID);
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();
                    清空欄位();
                    MessageBox.Show($"資料已刪除,{rows}筆資料受影響");
                    重新整理();
                }
                else
                {
                    清空欄位();
                }

            }
        }
        #endregion

        #region 清空欄位+重新整理ok
        private void btn清空欄位_Click(object sender, EventArgs e)
        {
            清空欄位();
            重新整理();
        }
        void 清空欄位()
        {
            lblID.Text = "000";
            txtProductName.Clear();
            cbxType.SelectedIndex = 0;
            txtPrice.Clear();
            txtStock.Clear();
            txtPicture.Clear();
            chkContinues.Checked = false;
            txtDecribe.Clear();
            pbxPicture.Image = null;
        }
        void 重新整理()
        {
            listID.Clear();
            listName.Clear();
            listType.Clear();
            listPrice.Clear();
            listStock.Clear();
            listDescribe.Clear();
            listContinued.Clear();
            listPicture.Clear();
            ReadDataBasePicture();
            ShowListViewListMode();
        }
        #endregion

        #region 關鍵字搜索ok
        private void cbx欄位關鍵字搜尋_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx欄位關鍵字搜尋.SelectedIndex ==2)
            {
                radioAll.Enabled = true;
                radioContinue.Enabled= true;
                radioNoContinue.Enabled= true;
                radioAll.Visible= true;
                radioContinue.Visible = true;
                radioNoContinue.Visible = true;
                txt欄位關鍵字.Visible = false;
            }
            else
            {
                radioAll.Enabled = false;
                radioContinue.Enabled = false;
                radioNoContinue.Enabled = false;
                radioAll.Visible = false;
                radioContinue.Visible = false;
                radioNoContinue.Visible = false;
                txt欄位關鍵字.Visible = true;
            }
        }
        private void radioContinue_CheckedChanged(object sender, EventArgs e)
        {
            Continue = 0;
        }
        private void radioNoContinue_CheckedChanged(object sender, EventArgs e)
        {
            Continue = 1;
        }
        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            Continue = 2;
        }
        private void btn關鍵搜尋_Click(object sender, EventArgs e)
        {
            清空欄位();
            if (cbx欄位關鍵字搜尋.SelectedIndex != 2)
            {
                if (txt欄位關鍵字.Text != "")
                {
                    SearchIDs.Clear();
                    listViewProduct.Clear();
                    listViewProduct.Items.Clear();
                    listID.Clear();
                    listName.Clear();
                    listType.Clear();
                    listPrice.Clear();
                    listStock.Clear();
                    listDescribe.Clear();
                    listContinued.Clear();
                    listPicture.Clear();
                    
                    string 查詢欄位名稱 = FindChange[cbx欄位關鍵字搜尋.SelectedIndex].ToString();
                    SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                    con.Open();

                    string strSQL = "select*from Products where " + 查詢欄位名稱 + " like @SearchKeyWord ";
                    //空白處須注意以免sql帶入錯誤

                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@SearchKeyWord", $"%{txt欄位關鍵字.Text.Trim()}%");
                    //cmd.Parameters.AddWithValue("@Cancel", chk黑名單.Checked);

                    SqlDataReader reader = cmd.ExecuteReader();

                    int count = 0;
                    while (reader.Read() == true)
                    {
                        listID.Add((int)reader["p_id"]);
                        listName.Add(reader["p_name"].ToString());
                        listType.Add(reader["p_type"].ToString());
                        listPrice.Add((int)reader["p_price"]);
                        listStock.Add((int)reader["p_instock"]);
                        listDescribe.Add(reader["p_describe"].ToString());
                        listContinued.Add(Convert.ToBoolean(reader["p_discontinued"]));
                        listPicture.Add(reader["p_image"].ToString());
                        count += 1;
                    }

                    ShowListViewListMode();
                    if (count == 0) { MessageBox.Show("查無此項目"); }

                    reader.Close();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("請輸入搜索關鍵字");
                }
            }
            else
            {
                SearchIDs.Clear();
                listViewProduct.Clear();
                listViewProduct.Items.Clear();
                listID.Clear();
                listName.Clear();
                listType.Clear();
                listPrice.Clear();
                listStock.Clear();
                listDescribe.Clear();
                listContinued.Clear();
                listPicture.Clear();
                string 下架確認 = "";
                if (Continue == 0)
                {
                    下架確認 = "p_discontinued = 1 or p_discontinued = 0";
                }
                else if (Continue == 1)
                {
                    下架確認 = "p_discontinued = 1";
                }
                else if (Continue == 2)
                {
                    下架確認 = "p_discontinued = 0";
                }
                SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                con.Open();

                string strSQL = "select*from Products where " + 下架確認;
                //空白處須注意以免sql帶入錯誤
                SqlCommand cmd = new SqlCommand(strSQL, con);

                SqlDataReader reader = cmd.ExecuteReader();

                int count = 0;
                while (reader.Read() == true)
                {
                    listID.Add((int)reader["p_id"]);
                    listName.Add(reader["p_name"].ToString());
                    listType.Add(reader["p_type"].ToString());
                    listPrice.Add((int)reader["p_price"]);
                    listStock.Add((int)reader["p_instock"]);
                    listDescribe.Add(reader["p_describe"].ToString());
                    listContinued.Add(Convert.ToBoolean(reader["p_discontinued"]));
                    listPicture.Add(reader["p_image"].ToString());
                    count += 1;
                }

                ShowListViewListMode();
                if (count == 0) { MessageBox.Show("查無此項目"); }

                reader.Close();
                con.Close();
            }
        }
        #endregion

        #region 顯示資料表ShowListViewListMode()ok
        void ShowListViewListMode()
        {
            listViewProduct.Clear();
            listViewProduct.LargeImageList = null;
            listViewProduct.SmallImageList = null;

            listViewProduct.View = View.Details;
            //列表模式
            listViewProduct.Columns.Add("id", 30);
            listViewProduct.Columns.Add("產品名稱", 140);
            listViewProduct.Columns.Add("產品價格", 80);
            listViewProduct.Columns.Add("產品庫存", 80);
            listViewProduct.Columns.Add("產品下架", 80);
            //listViewProduct.Columns.Add("會員備註", 180);
            listViewProduct.GridLines = true;
            listViewProduct.Font = new Font("微軟正黑體", 10, FontStyle.Bold);
            //標題與內容字體分開定義
            listViewProduct.FullRowSelect = true;

            for (int i = 0; i < listID.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();
                item.Font = new Font("標楷體", 9, FontStyle.Regular);
                item.Text = listID[i].ToString();
                item.SubItems.Add(listName[i]);
                item.SubItems.Add(listPrice[i].ToString());
                item.SubItems.Add(listStock[i].ToString());
                item.SubItems.Add(listContinued[i].ToString());
                //item.SubItems.Add(MemberNotes[i].ToString());
                item.Tag = listID[i];
                item.ForeColor = Color.DarkBlue;

                listViewProduct.Items.Add(item);
            }

        }
        #endregion

        #region 讀取資料庫ReadDataBasePicture()ok
        internal void ReadDataBasePicture()
        {
            try
            {
                SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                con.Open();
                string strSQL = ("select * from Products ");
                SqlCommand cmd = new SqlCommand(strSQL, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;

                while (reader.Read() == true)
                {
                    listID.Add((int)reader["p_id"]);
                    listName.Add(reader["p_name"].ToString());
                    listType.Add(reader["p_type"].ToString());
                    listPrice.Add((int)reader["p_price"]);
                    listPicture.Add(reader["p_image"].ToString());
                    listUnit.Add(reader["p_unit"].ToString());
                    listContinued.Add(Convert.ToBoolean(reader["p_discontinued"]));
                    listDescribe.Add(reader["p_describe"].ToString());
                    listStock.Add((int)reader["p_instock"]);
                    count += 1;
                }
                Console.WriteLine($"讀取到會員{count}筆資料");
                Console.WriteLine($"飲料圖片{listID.Count}筆");

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

        #region ListView顯示ok
        private void listViewMember_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int selectedID = listID[listViewProduct.SelectedItems[0].Index];

                SqlConnection com = new SqlConnection(GlobalVar.myDBConnectionString);
                com.Open();
                string strSQL = "select * from Products where p_id = @searchID";
                SqlCommand cmd = new SqlCommand(strSQL, com);
                cmd.Parameters.AddWithValue("@searchID", selectedID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    lblID.Text = reader["p_id"].ToString();
                    txtProductName.Text = reader["p_name"].ToString();
                    string find = reader["p_type"].ToString();
                    cbxType.SelectedIndex = cbxType.FindString(find);
                    txtPrice.Text = reader["p_price"].ToString();
                    txtStock.Text = reader["p_instock"].ToString();
                    txtPicture.Text = reader["p_image"].ToString();
                    chkContinues.Checked = Convert.ToBoolean(reader["p_discontinued"]);
                    txtDecribe.Text = reader["p_describe"].ToString();
                    image_name = reader["p_image"].ToString();
                    string PictureAllAddress = GlobalVar.image_dir + image_name;
                    //圖片完整路徑
                    pbxPicture.Image = Image.FromFile(PictureAllAddress);
                }
                else { Console.WriteLine("查無項目"); }

                reader.Close();
                com.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }       

        #endregion
        //0





    }
}
