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

namespace FormsApp0121_訂購系統
{
    public partial class SystemTest : Form
    {
        Function.Function function = new Function.Function();
        internal List<int> listID = new List<int>();
        internal List<string> listName = new List<string>();
        internal List<string> listPhone = new List<string>();
        internal List<DateTime> listShopDate = new List<DateTime>();
        internal List<DateTime> listRequireDate = new List<DateTime>();
        internal List<bool> listEatIn = new List<bool>();
        internal List<bool> listShopBagYes = new List<bool>();
        internal List<bool> listCheck = new List<bool>();
        internal List<int> listTotalPrice = new List<int>();

        public SystemTest()
        {
            InitializeComponent();
        }

        private void SystemTest_Load(object sender, EventArgs e)
        {
            if (GlobalVar.Employee == true)
            { 
                txtEmail.Visible = false;
                label5.Text = "到職日期";
                dtpEmployee.Enabled = false;
                dtpEmployee.Visible = true;
            }
            else if (GlobalVar.Customer == true)
            { 
                txtEmail.Visible = true;
                label5.Text = "Email";
                dtpEmployee.Visible = false;
            }
            ReadDataBaseMember();
            ReadDataBaseOrder();
            ShowListViewListMode();
        }

        #region 顯示資料表ShowListViewListMode()
        void ShowListViewListMode()
        {
            listViewOrder.Clear();
            listViewOrder.LargeImageList = null;
            listViewOrder.SmallImageList = null;

            listViewOrder.View = View.Details;
            //列表模式
            listViewOrder.Columns.Add("編號", 30);
            listViewOrder.Columns.Add("訂單日期", 140);
            listViewOrder.Columns.Add("訂單需求日期", 140);
            listViewOrder.Columns.Add("外帶內用", 80);
            listViewOrder.Columns.Add("購物袋", 80);
            listViewOrder.Columns.Add("價格", 100);
            listViewOrder.GridLines = true;
            listViewOrder.Font = new Font("微軟正黑體", 10, FontStyle.Bold);
            //標題與內容字體分開定義
            listViewOrder.FullRowSelect = true;

            for (int i = 0; i < listID.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();
                item.Font = new Font("標楷體", 9, FontStyle.Regular);
                item.Text = listID[i].ToString();
                //item.SubItems.Add(listName[i]);
                item.SubItems.Add(listShopDate[i].ToString());
                item.SubItems.Add(listRequireDate[i].ToString());
                item.SubItems.Add(listEatIn[i].ToString());
                item.SubItems.Add(listShopBagYes[i].ToString());
                item.SubItems.Add(listTotalPrice[i].ToString());
                //第一欄Text第二欄都為subItems
                item.Tag = listID[i];
                item.ForeColor = Color.DarkBlue;

                listViewOrder.Items.Add(item);
            }

        }
        #endregion
        #region 讀取資料庫ReadDataBaseOrder(string SQL)
        internal void ReadDataBaseOrder()
        {
            try
            {
                SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                con.Open();
                string strSQL = ($"select * from Orders where CustomerID = @Name");
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@Name", GlobalVar.訂購人ID);
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                        while (reader.Read() == true)
                        {
                            listID.Add((int)reader["OrderID"]);
                            listShopDate.Add(Convert.ToDateTime(reader["ShopDate"]));
                            listRequireDate.Add(Convert.ToDateTime(reader["RequireDate"]));
                            listEatIn.Add(Convert.ToBoolean(reader["EatIn"]));
                            listShopBagYes.Add(Convert.ToBoolean(reader["ShopBagYes"]));
                            listTotalPrice.Add((int)reader["TotalPrice"]);

                            count += 1;
                        }
                        Console.WriteLine($"讀取到訂單{count}筆資料");
                        Console.WriteLine($"訂單{listID.Count}筆");


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
        #region 讀取資料庫ReadDataBaseMember()
        internal void ReadDataBaseMember()
        {
            if (GlobalVar.Customer == true)
            {
                try
                {
                    SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                    con.Open();
                    string strSQL = ($"select * from Customers where c_name = @Name");
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@Name", GlobalVar.訂購人資訊);
                    SqlDataReader reader = cmd.ExecuteReader();
                    //int count = 0;

                    if (reader.Read() == true)
                    {
                        lblID.Text = reader["c_id"].ToString();
                        txt姓名.Text = reader["c_name"].ToString();
                        txt電話.Text = reader["c_phone"].ToString();
                        txt地址.Text = reader["c_address"].ToString();
                        txtEmail.Text = reader["c_email"].ToString();
                        txt點數.Text = reader["c_memberpoint"].ToString();
                        dtp生日.Value = Convert.ToDateTime(reader["c_birthday"]);
                        txtPassword.Text = reader["c_pwd"].ToString();
                        //chk黑名單.Checked = Convert.ToBoolean(reader["c_cancel"]);
                    }

                    reader.Close();
                    con.Close();
                    if (GlobalVar.Permission > 100) { txt點數.Enabled = false; }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //return ex;
                }
            }
            else if(GlobalVar.Employee==true)
            {
                try
                {
                    //int selectedID = EmployeeID[listViewMember.SelectedItems[0].Index];

                    SqlConnection com = new SqlConnection(GlobalVar.myDBConnectionString);
                    com.Open();
                    string strSQL = "select * from Employee where e_name = @searchID";
                    SqlCommand cmd = new SqlCommand(strSQL, com);
                    cmd.Parameters.AddWithValue("@searchID", GlobalVar.訂購人資訊);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        lblID.Text = reader["e_id"].ToString();
                        txt姓名.Text = reader["e_name"].ToString();
                        txt電話.Text = reader["e_phone"].ToString();
                        txt地址.Text = reader["e_address"].ToString();
                        dtpEmployee.Value = Convert.ToDateTime(reader["e_hiredate"]);
                        dtp生日.Value = Convert.ToDateTime(reader["e_birthday"]);
                        txtPassword.Text = reader["e_pwd"].ToString();
                        txt點數.Text = reader["e_permission"].ToString();
                    }
                    else { Console.WriteLine("查無此人"); }

                    reader.Close();
                    com.Close();
                    if (GlobalVar.Permission > 100) { txt點數.Enabled = false; }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        #endregion

        #region 變更
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int intID = 0;
            Int32.TryParse(lblID.Text, out intID);
            if (GlobalVar.Customer == true)
            {
                if ((intID > 0) && ((txt姓名.Text != "") && (txt電話.Text != "")))
                {
                    SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                    con.Open();

                    string strSQL = "update Customers　set c_name = @UpdateName, c_phone = @UpdateTel, c_address = @UpdateAddress, c_email = @UpdateEmail, c_birthday = @UpdateBirthday, c_cancel = @UpdateCancel, c_memberpoint = @UpdatePoints, c_notes = @UpdateNotes where c_id = @SearchID;";

                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@UpdateName", txt姓名.Text.Trim());
                    cmd.Parameters.AddWithValue("@UpdateTel", txt電話.Text.Trim());
                    cmd.Parameters.AddWithValue("@UpdateAddress", txt地址.Text.Trim());
                    cmd.Parameters.AddWithValue("@UpdatEemail", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@UpdateBirthday", dtp生日.Value);
                    bool check = false;
                    cmd.Parameters.AddWithValue("@UpdateCancel", check);

                    int intPoints = 0;
                    Int32.TryParse(txt點數.Text.Trim(), out intPoints);
                    cmd.Parameters.AddWithValue("@UPdatePoints", intPoints);
                    cmd.Parameters.AddWithValue("@SearchID", intID);
                    string notes = "";
                    cmd.Parameters.AddWithValue("@UpdateNotes", notes);

                    int rows = cmd.ExecuteNonQuery();
                    //執行查詢

                    con.Close();
                    MessageBox.Show($"會員資料修改完畢,{rows}筆資料受影響");
                    清空欄位();
                    ReadDataBaseMember();

                }
                else
                {
                    MessageBox.Show("姓名電話不能空白");
                }
            }
            else if(GlobalVar.Employee==true)
            {

                SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                con.Open();

                string strSQL = "update Employee　set e_name = @UpdateName, e_phone = @UpdateTel, e_address = @UpdateAddress, e_birthday = @UpdateBirthday, e_hiredate = @UpdateHireDate, e_work = @UpdateCancel, e_pwd = @UpdatePwd, e_permission = @UpdatePermission, e_notes = @UpdateNotes where e_id = @SearchID;";

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@UpdateName", txt姓名.Text.Trim());
                cmd.Parameters.AddWithValue("@UpdateTel", txt電話.Text.Trim());
                cmd.Parameters.AddWithValue("@UpdateAddress", txt地址.Text.Trim());
                cmd.Parameters.AddWithValue("@UpdateHireDate", dtpEmployee.Value);
                cmd.Parameters.AddWithValue("@UpdateBirthday", dtp生日.Value);
                bool chk = true;
                cmd.Parameters.AddWithValue("@UpdateCancel", chk);
                int intPermission = 0;
                Int32.TryParse(txt點數.Text.Trim(), out intPermission);
                cmd.Parameters.AddWithValue("@UpdatePermission", intPermission);
                cmd.Parameters.AddWithValue("@SearchID", GlobalVar.訂購人ID);
                string note2 = "";
                cmd.Parameters.AddWithValue("@UpdateNotes", note2);
                cmd.Parameters.AddWithValue("@UpdatePwd", txtPassword.Text);

                int rows = cmd.ExecuteNonQuery();
                //執行查詢

                con.Close();
                MessageBox.Show($"員工資料修改完畢,{rows}筆資料受影響");
                清空欄位();
                ReadDataBaseMember();
            }
        }
        #endregion

        void 清空欄位()
        {
            lblID.Text = "000";
            txt姓名.Clear();
            txt電話.Clear();
            txtEmail.Clear();
            txt地址.Clear();
            txt點數.Clear();
            txtPassword.Clear();
            dtp生日.Value = DateTime.Now;
            dtpEmployee.Value = DateTime.Now;
        }

        private void chkPassWord_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassWord.Checked == true) { txtPassword.UseSystemPasswordChar = false; }
            else { txtPassword.UseSystemPasswordChar = true; }
        }
    }
}
