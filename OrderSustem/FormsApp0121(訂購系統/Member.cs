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
using System.Text.RegularExpressions;

namespace FormsApp0121_訂購系統
{
    public partial class Member : Form
    {
        Function.Function function = new Function.Function();
        List<string> FindChange = new List<string>();
        List<int> SearchIDs = new List<int>();
        List<int> MemberID = new List<int>();
        List<string> MemberName = new List<string>();
        List<string> MemberPhone = new List<string>();
        List<string> MemberEmail = new List<string>();
        List<string> MemberAddress = new List<string>();
        List<string> MemberNotes = new List<string>();
        List<bool> MemberCancelCheck = new List<bool>();
        List<DateTime> MemberBirthday = new List<DateTime>();

        List<int> SearchEmployeeIDs = new List<int>();
        List<int> EmployeeID = new List<int>();
        List<string> EmployeeName = new List<string>();
        List<string> EmployeePhone = new List<string>();
        List<DateTime> EmployeeHireDate = new List<DateTime>();
        List<string> EmployeeAddress = new List<string>();
        List<string> EmployeeNotes = new List<string>();
        List<bool> EmployeeCancelCheck = new List<bool>();
        List<DateTime> EmployeeBirthday = new List<DateTime>();
        List<string> EmployeePassWord = new List<string>();
        List<int> EmployeePermission = new List<int>();
        List<bool> EmployeeWork = new List<bool>();

        int MemberCancel = 0;


        public Member()
        {
            InitializeComponent();
        }

        private void Member_Load(object sender, EventArgs e)
        {
            Function.Function.FormReadDataBaseCustomer();

            if (GlobalVar.Employee == true)
            {
                EmployeeShow();
            }
            else if(GlobalVar.Customer == true)
            {
                CustomerShow();
            }
            else if ((GlobalVar.Director == true) || (GlobalVar.Permission <= 100))
            {
                DirectorShow();
            }
            else
            {
                VisitorShow();
            }
            cbx欄位關鍵字搜尋.Items.Add("姓名");
            cbx欄位關鍵字搜尋.Items.Add("電話");
            cbx欄位關鍵字搜尋.Items.Add("地址");
            cbx欄位關鍵字搜尋.Items.Add("Email");
            FindChange.Add("c_name");
            FindChange.Add("c_phone");
            FindChange.Add("c_phone");
            FindChange.Add("c_email");
            //讀取資料庫
            ReadDataBasePicture();
            ShowListViewListMode();
            //權限
            if (GlobalVar.Permission <= 10)
            {
                txt點數.Enabled = true;
                chk黑名單.Enabled = true;
                chk會員.Visible = true;
            }
            else if ((GlobalVar.Permission <= 100) && (GlobalVar.Permission > 10))
            {
                txt點數.Enabled = false;
                chk黑名單.Enabled = true;
                chk會員.Visible = true;
            }
            else if (GlobalVar.Permission > 100)
            {
                txt點數.Enabled = false;
                chk黑名單.Enabled = false;
                chk會員.Visible = false;
            }
            //預設
            cbx欄位關鍵字搜尋.SelectedIndex = 0;
            txt點數.Text = "";
            MemberCancel = 0;
            txt欄位關鍵字.Text = "%";
            chk黑名單.Checked = false;


        }

        #region 資料修改(員工會員皆可)
        private void btn資料修改_Click(object sender, EventArgs e)
        {
            int intID = 0;
            Int32.TryParse(lblID.Text, out intID);

            if ((intID > 0) && ((txt姓名.Text != "") && (txt電話.Text != "")))
            {
                if (chk會員.Checked == false)
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
                    cmd.Parameters.AddWithValue("@UpdateCancel", chk黑名單.Checked);

                    int intPoints = 0;
                    Int32.TryParse(txt點數.Text.Trim(), out intPoints);
                    cmd.Parameters.AddWithValue("@UPdatePoints", intPoints);
                    cmd.Parameters.AddWithValue("@SearchID", intID);
                    cmd.Parameters.AddWithValue("@UpdateNotes", txtNote.Text);

                    int rows = cmd.ExecuteNonQuery();
                    //執行查詢

                    con.Close();
                    MessageBox.Show($"會員資料修改完畢,{rows}筆資料受影響");
                    清空欄位();
                    重新整理();
                    ReadDataBasePicture();
                    ShowListViewListMode();
                }
                else
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
                    cmd.Parameters.AddWithValue("@UpdateCancel", chk黑名單.Checked);
                    int intPermission = 0;
                    Int32.TryParse(txt點數.Text.Trim(), out intPermission);
                    cmd.Parameters.AddWithValue("@UpdatePermission", intPermission);
                    cmd.Parameters.AddWithValue("@SearchID", intID);
                    cmd.Parameters.AddWithValue("@UpdateNotes", txtNote.Text);
                    cmd.Parameters.AddWithValue("@UpdatePwd", txtPassword.Text);

                    int rows = cmd.ExecuteNonQuery();
                    //執行查詢

                    con.Close();
                    MessageBox.Show($"員工資料修改完畢,{rows}筆資料受影響");
                    清空欄位();
                    重新整理();
                    ReadDataBaseEmployee();
                    ShowListViewListModeEmployee();
                }
            }
            else
            {
                MessageBox.Show("姓名電話不能空白");
            }
        }
        #endregion

        #region 新增資料(員工會員皆可)
        private void btn新增資料_Click(object sender, EventArgs e)
        {

            if ((txt姓名.Text != "") && (txt電話.Text != "") && (txtPassword.Text != ""))
            {
                string checkName = txt姓名.Text;
                if (Function.Function.CheckChinese(checkName) == true)
                {
                    if (chk會員.Checked == false)
                    {
                        
                        string Phone = txt電話.Text;
                        txt點數.Text = "0";
                        int permission = 10000;

                        if (Function.Function.CheckPhone(Phone) == true)
                        {

                            SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                            con.Open();

                            string strSQL = "insert　into Customers　values(@NewPassword, @NewTel, @NewName, @NewBirthday, @NewAddress, @Newemail, @NewCancel, @NewPoints, @NewNotes, @NewPermission);";

                            SqlCommand cmd = new SqlCommand(strSQL, con);
                            cmd.Parameters.AddWithValue("@NewPassword", txtPassword.Text.Trim());
                            cmd.Parameters.AddWithValue("@NewTel", txt電話.Text.Trim());
                            cmd.Parameters.AddWithValue("@NewName", txt姓名.Text.Trim());
                            cmd.Parameters.AddWithValue("@NewBirthday", dtp生日.Value);
                            cmd.Parameters.AddWithValue("@NewAddress", txt地址.Text.Trim());
                            cmd.Parameters.AddWithValue("@Newemail", txtEmail.Text.Trim());
                            cmd.Parameters.AddWithValue("@NewCancel", chk黑名單.Checked);
                            int intPoints = 0;
                            Int32.TryParse(txt點數.Text.Trim(), out intPoints);
                            cmd.Parameters.AddWithValue("@NewPoints", intPoints);
                            cmd.Parameters.AddWithValue("@NewNotes", txtNote.Text);
                            cmd.Parameters.AddWithValue("@NewPermission", permission);

                            int rows = cmd.ExecuteNonQuery();
                            //執行查詢
                            con.Close();
                            if(GlobalVar.Visitor == true)
                            {
                                MessageBox.Show("新增完畢，請重新登入"); 
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show($"會員資料新增完畢,{rows}筆資料受影響");
                            }
                            
                            清空欄位();
                            重新整理();
                            ReadDataBasePicture();
                            ShowListViewListMode();

                        }
                        else
                        {
                            MessageBox.Show("請輸入正確電話號碼");
                        }
                    }
                    else
                    {
                        string Phone = txt電話.Text;

                        if (Function.Function.CheckPhone(Phone) == true)
                        {

                            SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                            con.Open();

                            string strSQL = "insert　into Employee　(e_pwd, e_phone, e_name, e_birthday, e_address, e_work, e_permission, e_hiredate, e_notes )values(@NewPassword, @NewTel, @NewName, @NewBirthday, @NewAddress, @NewWork, @NewPermission, @NewHiredate, @NewNotes);";

                            SqlCommand cmd = new SqlCommand(strSQL, con);
                            cmd.Parameters.AddWithValue("@NewPassword", txtPassword.Text.Trim());
                            cmd.Parameters.AddWithValue("@NewTel", txt電話.Text.Trim());
                            cmd.Parameters.AddWithValue("@NewName", txt姓名.Text.Trim());
                            cmd.Parameters.AddWithValue("@NewBirthday", dtp生日.Value);
                            cmd.Parameters.AddWithValue("@NewAddress", txt地址.Text.Trim());
                            cmd.Parameters.AddWithValue("@NewWork", chk黑名單.Checked);
                            int intPermission = 0;
                            Int32.TryParse(txt點數.Text.Trim(), out intPermission);
                            cmd.Parameters.AddWithValue("@NewPermission", intPermission);
                            cmd.Parameters.AddWithValue("@NewHiredate", dtpEmployee.Value);
                            cmd.Parameters.AddWithValue("@NewNotes", txtNote.Text);
                            int rows = cmd.ExecuteNonQuery();
                            //執行查詢
                            con.Close();
                            MessageBox.Show($"會員資料新增完畢,{rows}筆資料受影響");
                            清空欄位();
                            重新整理();
                            ReadDataBaseEmployee();
                            ShowListViewListModeEmployee();
                        }
                        else
                        {
                            MessageBox.Show("請輸入正確電話號碼");
                        }
                    }
                }
                else { MessageBox.Show("請輸入中文"); }
            }
            else
            {
                MessageBox.Show("姓名,電話以及密碼必填");
            }
        }
        #endregion

        #region 刪除資料(員工會員皆可)
        private void btn刪除資料_Click(object sender, EventArgs e)
        {
            int intID = 0;
            Int32.TryParse(lblID.Text.Trim(), out intID);

            if (intID > 0)
            {
                    if (chk會員.Checked == false)
                    {
                        try
                        {
                            DialogResult Res = MessageBox.Show("你確定要刪除此會員?", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (Res == DialogResult.Yes)
                            {
                                SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                                con.Open();
                                string strSQL = "delete from Customers where c_id = @DeleteID;";
                                SqlCommand cmd = new SqlCommand(strSQL, con);

                                cmd.Parameters.AddWithValue("@DeleteID", intID);

                                int rows = cmd.ExecuteNonQuery();
                                con.Close();
                                清空欄位();
                                MessageBox.Show($"會員資料已刪除,{rows}筆資料受影響");
                                重新整理();
                                ReadDataBasePicture();
                                ShowListViewListMode();
                            }
                            else { 清空欄位(); }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            //return ex;
                        }
                    }
                    else
                    {
                        try
                        {
                            int selectedpermission = EmployeePermission[listViewMember.SelectedItems[0].Index];
                            if (selectedpermission > 100)
                            {
                                DialogResult Re = MessageBox.Show("你確定要刪除此員工?", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (Re == DialogResult.Yes)
                                {
                                    SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                                    con.Open();
                                    string strSQL = "delete from Employee where e_id = @DeleteID;";
                                    SqlCommand cmd = new SqlCommand(strSQL, con);

                                    cmd.Parameters.AddWithValue("@DeleteID", intID);

                                    int rows = cmd.ExecuteNonQuery();
                                    con.Close();
                                    清空欄位();
                                    MessageBox.Show($"員工資料已刪除,{rows}筆資料受影響");
                                    重新整理();
                                    ReadDataBaseEmployee();
                                    ShowListViewListModeEmployee();
                                }
                                else { 清空欄位(); }
                            }
                            else
                            {
                                MessageBox.Show("此位不能刪");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            //return ex;
                        }
                    }
            }
        }
        #endregion

        #region 清空欄位+重新整理
        private void btn清空欄位_Click(object sender, EventArgs e)
        {
            清空欄位();
            重新整理();
        }
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
            chk黑名單.Checked = false;
        }
        void 重新整理()
        {
            MemberID.Clear();
            MemberName.Clear();
            MemberPhone.Clear();
            MemberEmail.Clear();
            MemberAddress.Clear();
            MemberBirthday.Clear();
            MemberNotes.Clear();
            MemberCancelCheck.Clear();
            SearchEmployeeIDs.Clear();
            EmployeeID.Clear();
            EmployeeName.Clear();
            EmployeePhone.Clear();
            EmployeeHireDate.Clear();
            EmployeeAddress.Clear();
            EmployeeNotes.Clear();
            EmployeeCancelCheck.Clear();
            EmployeeBirthday.Clear();
            EmployeePassWord.Clear();

        }
        #endregion

        #region 關鍵字搜索
        private void btn關鍵搜尋_Click(object sender, EventArgs e)
        {
            清空欄位();
            if (txt欄位關鍵字.Text != "")
            {
                SearchIDs.Clear();
                listViewMember.Clear();
                listViewMember.Items.Clear();
                MemberID.Clear();
                MemberName.Clear();
                MemberPhone.Clear();
                MemberEmail.Clear();
                MemberAddress.Clear();
                MemberBirthday.Clear();
                MemberNotes.Clear();
                MemberCancelCheck.Clear();
                string 查詢欄位名稱 = FindChange[cbx欄位關鍵字搜尋.SelectedIndex].ToString();
                string 黑名單 = "";
                if (MemberCancel == 0)
                {
                    黑名單 = "";
                }
                else if (MemberCancel == 1)
                {
                    黑名單 = "and c_cancel = 0";
                }
                else if (MemberCancel == 2)
                {
                    黑名單 = "and c_cancel = 1";
                }
                SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                con.Open();

                string strSQL = "select*from Customers where c_birthday >= @BirthStart and c_birthday <=@BirthEnd and " + 查詢欄位名稱 + " like @SearchKeyWord " + 黑名單;
                //空白處須注意以免sql帶入錯誤

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchKeyWord", $"%{txt欄位關鍵字.Text.Trim()}%");
                cmd.Parameters.AddWithValue("@BirthStart", dtp生日區間起始.Value);
                cmd.Parameters.AddWithValue("@BirthEnd", dtp生日區間結束.Value);
                //cmd.Parameters.AddWithValue("@Cancel", chk黑名單.Checked);

                SqlDataReader reader = cmd.ExecuteReader();

                int count = 0;
                while (reader.Read() == true)
                {
                    MemberID.Add((int)reader["c_id"]);
                    MemberName.Add(reader["c_name"].ToString());
                    MemberEmail.Add(reader["c_email"].ToString());
                    MemberBirthday.Add(Convert.ToDateTime(reader["c_birthday"]));
                    MemberPhone.Add(reader["c_phone"].ToString());
                    MemberAddress.Add(reader["c_address"].ToString());
                    MemberNotes.Add(reader["c_notes"].ToString());
                    MemberCancelCheck.Add(Convert.ToBoolean(reader["c_cancel"]));
                    count += 1;
                }

                ShowListViewListMode();
                if (count == 0) { MessageBox.Show("查無此人"); }

                reader.Close();
                con.Close();
            }
            else
            {
                MessageBox.Show("請輸入搜索關鍵字");
            }
        }
        #endregion

        #region ListBox選擇搜索結果(取消)
        //private void listBox搜索結果_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (listBox搜索結果.SelectedIndex >= 0)
        //    {
        //        int selectedID = SearchIDs[listBox搜索結果.SelectedIndex];
        //        try
        //        {
        //            SqlConnection com = new SqlConnection(GlobalVar.myDBConnectionString);
        //            com.Open();
        //            string strSQL = "select * from Customers where c_id = @searchID";
        //            SqlCommand cmd = new SqlCommand(strSQL, com);
        //            cmd.Parameters.AddWithValue("@searchID", selectedID);
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            if (reader.Read() == true)
        //            {
        //                lblID.Text = reader["c_id"].ToString();
        //                txt姓名.Text = reader["c_name"].ToString();
        //                txt電話.Text = reader["c_phone"].ToString();
        //                txt地址.Text = reader["c_address"].ToString();
        //                txtEmail.Text = reader["c_email"].ToString();
        //                txt點數.Text = reader["c_memberpoint"].ToString();
        //                dtp生日.Value = Convert.ToDateTime(reader["c_birthday"]);
        //                chk黑名單.Checked = Convert.ToBoolean(reader["c_cancel"]);
        //            }
        //            else { MessageBox.Show("查無此人"); 清空欄位(); }

        //            reader.Close();
        //            com.Close();
        //        }
        //        catch (Exception ex)
        //        { Console.WriteLine(ex.Message); }

        //    }
        //}
        #endregion

        #region 顯示資料表ShowListViewListMode()
        void ShowListViewListMode()
        {
            listViewMember.Clear();
            listViewMember.LargeImageList = null;
            listViewMember.SmallImageList = null;

            listViewMember.View = View.Details;
            //列表模式
            listViewMember.Columns.Add("id", 30);
            listViewMember.Columns.Add("會員姓名", 100);
            listViewMember.Columns.Add("會員信箱", 140);
            listViewMember.Columns.Add("會員生日", 100);
            listViewMember.Columns.Add("會員地址", 150);
            listViewMember.Columns.Add("會員備註", 180);
            listViewMember.GridLines = true;
            listViewMember.Font = new Font("微軟正黑體", 10, FontStyle.Bold);
            //標題與內容字體分開定義
            listViewMember.FullRowSelect = true;

            for (int i = 0; i < MemberID.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();
                item.Font = new Font("標楷體", 9, FontStyle.Regular);
                item.Text = MemberID[i].ToString();
                item.SubItems.Add(MemberName[i]);
                item.SubItems.Add(MemberEmail[i].ToString());
                item.SubItems.Add(MemberBirthday[i].ToString());
                item.SubItems.Add(MemberAddress[i].ToString());
                item.SubItems.Add(MemberNotes[i].ToString());
                //第一欄Text第二欄都為subItems
                item.Tag = MemberID[i];
                item.ForeColor = Color.DarkBlue;

                listViewMember.Items.Add(item);
            }

        }
        #endregion
        #region 讀取資料庫ReadDataBasePicture()
        internal void ReadDataBasePicture()
        {
            try
            {
                SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                con.Open();
                string strSQL = ($"select * from Customers ");
                SqlCommand cmd = new SqlCommand(strSQL, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;

                while (reader.Read() == true)
                {
                    MemberID.Add((int)reader["c_id"]);
                    MemberName.Add(reader["c_name"].ToString());
                    MemberEmail.Add(reader["c_email"].ToString());
                    MemberBirthday.Add(Convert.ToDateTime(reader["c_birthday"]));
                    MemberPhone.Add(reader["c_phone"].ToString());
                    MemberAddress.Add(reader["c_address"].ToString());
                    MemberNotes.Add(reader["c_notes"].ToString());
                    MemberCancelCheck.Add(Convert.ToBoolean(reader["c_cancel"]));
                    count += 1;
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

        #region ListView點擊顯示
        private void listViewMember_MouseClick(object sender, MouseEventArgs e)
        {
            if (chk會員.Checked == false)
            {
                try
                {
                    int selectedID = MemberID[listViewMember.SelectedItems[0].Index];

                    SqlConnection com = new SqlConnection(GlobalVar.myDBConnectionString);
                    com.Open();
                    string strSQL = "select * from Customers where c_id = @searchID";
                    SqlCommand cmd = new SqlCommand(strSQL, com);
                    cmd.Parameters.AddWithValue("@searchID", selectedID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        lblID.Text = reader["c_id"].ToString();
                        txt姓名.Text = reader["c_name"].ToString();
                        txt電話.Text = reader["c_phone"].ToString();
                        txt地址.Text = reader["c_address"].ToString();
                        txtEmail.Text = reader["c_email"].ToString();
                        txt點數.Text = reader["c_memberpoint"].ToString();
                        dtp生日.Value = Convert.ToDateTime(reader["c_birthday"]);
                        chk黑名單.Checked = Convert.ToBoolean(reader["c_cancel"]);
                    }
                    else { Console.WriteLine("查無此人"); }

                    reader.Close();
                    com.Close();

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            else
            {
                try
                {
                    int selectedID = EmployeeID[listViewMember.SelectedItems[0].Index];

                    SqlConnection com = new SqlConnection(GlobalVar.myDBConnectionString);
                    com.Open();
                    string strSQL = "select * from Employee where e_id = @searchID";
                    SqlCommand cmd = new SqlCommand(strSQL, com);
                    cmd.Parameters.AddWithValue("@searchID", selectedID);
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
                        chk黑名單.Checked = Convert.ToBoolean(reader["e_work"]);
                        txt點數.Text = reader["e_permission"].ToString();
                    }
                    else { Console.WriteLine("查無此人"); }

                    reader.Close();
                    com.Close();

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }

        #endregion

        #region 黑名單查詢
        private void radio未黑_CheckedChanged(object sender, EventArgs e)
        {
            MemberCancel = 1;
        }
        private void radio已黑_CheckedChanged(object sender, EventArgs e)
        {
            MemberCancel = 2;
        }
        private void radio全部_CheckedChanged(object sender, EventArgs e)
        {
            MemberCancel = 0;
        }
        #endregion

        #region GroupBox邊框移除(空)
        private void gbxControl_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(this.BackColor);
        }

        #endregion

        #region 關掉此Member頁面
        private void btnClose_Click(object sender, EventArgs e)
        {
            Main mainForm = (Main)Application.OpenForms["Main"];
            mainForm.openMenuForm(new Activity());
            mainForm.panelrow.Height = mainForm.btnActivity.Height;
            mainForm.panelrow.Top = mainForm.btnActivity.Top;
            this.Close();
        }
        #endregion

        /// <summary>
        /// 為啟動member頁面時修改或隱藏
        /// </summary>
        #region 會員Customer
        void CustomerShow()
        {
            Size = new Size(300, 620);
            btn資料修改.Visible = true;
            btn新增資料.Visible = false;
            btn刪除資料.Visible = false;
            btn清空欄位.Visible = false;
            gbxDGV.Visible = false;
            gbxFind.Visible = false;
            chk黑名單.Visible = false;
            lblCancel.Visible = false;
            txt點數.Visible = false;
            lblMemberPoint.Visible = false;
            btnClose.Visible = false;
            chkShowPassWord.Visible = true;
            chkShowPassWord.Location = new Point(95, 404);
            lbl顯示密碼.Location = new Point(16, 405);
            lbl顯示密碼.Visible = true;
            chk會員.Visible = false;
            dtpEmployee.Visible = false;
        }
        #endregion
        #region 員工Employee
        void EmployeeShow()
        {
            Size = new Size(1055, 620);
            btn刪除資料.Visible = true;
            btn清空欄位.Visible = true;
            gbxDGV.Visible = true;
            gbxFind.Visible = true;
            chk黑名單.Visible = true;
            lblCancel.Visible = true;
            txt點數.Visible = true;
            lblMemberPoint.Visible = true;
            btnClose.Visible = false;
            chkShowPassWord.Visible = false;
            lbl顯示密碼.Visible = false;
            chk會員.Visible = false;
        }
        #endregion
        #region 經理Director
        void DirectorShow()
        {
            Size = new Size(1055, 620);
            btn刪除資料.Visible = true;
            btn清空欄位.Visible = true;
            gbxDGV.Visible = true;
            gbxFind.Visible = true;
            chk黑名單.Visible = true;
            chk黑名單.Enabled = true;
            lblCancel.Visible = true;
            txt點數.Visible = true;
            lblMemberPoint.Visible = true;
            btnClose.Visible = false;
            chkShowPassWord.Visible = false;            
            lbl顯示密碼.Visible = false;
            chk會員.Visible = true;
            chk會員.Enabled = true;
        }
        #endregion
        #region 訪客Visitor
        void VisitorShow()
        {
            chkShowPassWord.Checked = true;

            Size = new Size(300, 620);
            chkShowPassWord.Visible = false;
            txt姓名.Text = "必填";
            txt電話.Text = "必填";
            txtPassword.Text = "必填";
            btn刪除資料.Visible = false;
            btn清空欄位.Visible = false;
            btn資料修改.Visible = false;
            gbxDGV.Visible = false;
            gbxFind.Visible = false;
            chk黑名單.Visible = false;
            lblCancel.Visible = false;
            txt點數.Visible = false;
            lblMemberPoint.Visible = false;
            btnClose.Visible = true;
            chkShowPassWord.Visible = true;
            chkShowPassWord.Location = new Point(95, 404);
            lbl顯示密碼.Location = new Point(16, 405);
            lbl顯示密碼.Visible = true;
            chk會員.Visible = false;
        }
        #endregion

        #region chk顯示密碼
        private void chkShowPassWord_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassWord.Checked == true) { txtPassword.UseSystemPasswordChar = false; }
            else { txtPassword.UseSystemPasswordChar = true;}
        }



        #endregion

        #region 切換員工還是會員(經理等級使用)chk會員
        private void chk會員_CheckedChanged(object sender, EventArgs e)
        {
            if(chk會員.Checked == true) 
            {
                清空欄位();
                重新整理();
                dtpEmployee.Visible = true;
                label5.Text = "Hire";
                chk黑名單.Text = "在職";
                chk黑名單.Checked = true;
                lblCancel.Text = "在職";
                lblMemberPoint.Text = "權限";
                txt點數.Text = "1000"; 
                chkShowPassWord.Visible = true;
                chkShowPassWord.Location = new Point(95, 430);
                lbl顯示密碼.Location = new Point(16, 431);
                lbl顯示密碼.Visible = true;
                ReadDataBaseEmployee();
                ShowListViewListModeEmployee();
                gbxFind.Visible = false;
                gbxDGV.Name = "員工資料列表";

            }
            else
            {
                清空欄位();
                重新整理();
                dtpEmployee.Visible = false;
                label5.Text = "Email";
                chk黑名單.Text = "黑下去";
                lblCancel.Text = "黑名單";
                lblMemberPoint.Text = "點數";
                chkShowPassWord.Visible = false;
                lbl顯示密碼.Visible = false;
                ReadDataBasePicture();
                ShowListViewListMode();
                gbxFind.Visible = true;
                gbxDGV.Name = "會員資料列表";
            }
        }
        #endregion

        #region 讀取資料庫ReadDataBaseEmployee()
        internal void ReadDataBaseEmployee()
        {
            try
            {
                SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                con.Open();
                string strSQL = ($"select * from Employee ");
                SqlCommand cmd = new SqlCommand(strSQL, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;

                while (reader.Read() == true)
                {
                    EmployeeID.Add((int)reader["e_id"]);
                    EmployeeName.Add(reader["e_name"].ToString());
                    EmployeeHireDate.Add(Convert.ToDateTime(reader["e_hiredate"]));
                    EmployeeBirthday.Add(Convert.ToDateTime(reader["e_birthday"]));
                    EmployeePhone.Add(reader["e_phone"].ToString());
                    EmployeeAddress.Add(reader["e_address"].ToString());
                    EmployeeNotes.Add(reader["e_notes"].ToString());
                    EmployeePassWord.Add(reader["e_pwd"].ToString());
                    EmployeeWork.Add(Convert.ToBoolean(reader["e_work"]));
                    EmployeePermission.Add((int)reader["e_permission"]);
                    EmployeeNotes.Add(reader["e_notes"].ToString());
                    count += 1;
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
        #region 顯示資料表ShowListViewListModeEmployee()
        void ShowListViewListModeEmployee()
        {
            listViewMember.Clear();
            listViewMember.Items.Clear();
            listViewMember.LargeImageList = null;
            listViewMember.SmallImageList = null;

            listViewMember.View = View.Details;
            //列表模式
            listViewMember.Columns.Add("id", 30);
            listViewMember.Columns.Add("員工姓名", 100);
            listViewMember.Columns.Add("員工信箱", 140);
            listViewMember.Columns.Add("員工生日", 100);
            listViewMember.Columns.Add("員工地址", 150);
            listViewMember.Columns.Add("員工備註", 180);
            listViewMember.GridLines = true;
            listViewMember.Font = new Font("微軟正黑體", 10, FontStyle.Bold);
            //標題與內容字體分開定義
            listViewMember.FullRowSelect = true;

            for (int i = 0; i < EmployeeID.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();
                item.Font = new Font("標楷體", 9, FontStyle.Regular);
                item.Text = EmployeeID[i].ToString();
                item.SubItems.Add(EmployeeName[i]);
                item.SubItems.Add(EmployeeHireDate[i].ToString());
                item.SubItems.Add(EmployeeBirthday[i].ToString());
                item.SubItems.Add(EmployeeAddress[i].ToString());
                item.SubItems.Add(EmployeeNotes[i].ToString());
                //第一欄Text第二欄都為subItems
                item.Tag = EmployeeID[i];
                item.ForeColor = Color.DarkBlue;

                listViewMember.Items.Add(item);
            }

        }
        #endregion

    }
}
