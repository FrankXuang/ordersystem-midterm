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
    public partial class Main : Form
    {
        //internal static List<int> listID = new List<int>();
        //internal static List<string> listName = new List<string>();
        //internal static List<int> listPrice = new List<int>();
        //internal static List<int> listQuantity = new List<int>();
        //internal static List<string> listSweet = new List<string>();
        //internal static List<string> listIce = new List<string>();
        //internal static List<string> listSpicy = new List<string>();
        //internal static List<int> listItemTotalPrice = new List<int>();

        public Main()
        {
            InitializeComponent();
            panelrow.Height = btnActivity.Height;
            panelrow.Top = btnActivity.Top;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            if (GlobalVar.LoginSuccess == false)
            {
                Login myLoginForm = new Login();
                myLoginForm.ShowDialog();
            }
            if (GlobalVar.Permission > 1000)
            {
                btn商品管理.Enabled = false;
                btn商品管理.Visible = false;
                btnOMS.Enabled = false;
                btnOMS.Visible = false;
            }
            else
            {
                btn商品管理.Enabled = true;
                btn商品管理.Visible = true;
                btnOMS.Enabled = true;
                btnOMS.Visible = true;
            }
            Management.TheIce();
            Management.TheSweet();
            Management.TheSpicy();
            Management.主廚推薦();
            openMenuForm(new Activity());
        }

        #region 進入Menu
        private void btn訂購菜單_Click(object sender, EventArgs e)
        {
            //Menu menu = new Menu();
            //menu.ShowDialog();
            panelrow.Height = btn訂購菜單.Height;
            panelrow.Top = btn訂購菜單.Top;
            openMenuForm(new Menu());


        }
        #endregion
        #region 進入訂單管理
        private void btn訂購管理_Click(object sender, EventArgs e)
        {
            //OrderList order = new OrderList();
            //order.ShowDialog();
            panelrow.Height = btn訂購管理.Height;
            panelrow.Top = btn訂購管理.Top;
            if (GlobalVar.訂購人資訊 == "") { MessageBox.Show("會員登入才能點餐"); }
            else { openMenuForm(new OrderList()); }

        }
        #endregion
        #region 訂單管理OMS
        private void btnOMS_Click(object sender, EventArgs e)
        {
            panelrow.Height = btnOMS.Height;
            panelrow.Top = btnOMS.Top;
            if((GlobalVar.Employee == true)|| (GlobalVar.Director == true)) { openMenuForm(new OrderManagementCheck()); }

        }
        #endregion
        #region 進入會員管理
        private void btn會員管理_Click(object sender, EventArgs e)
        {
            //Member member = new Member();
            //member.ShowDialog();
            panelrow.Height = btn會員管理.Height;
            panelrow.Top = btn會員管理.Top;

            //openMenuForm(new Member());
            if(GlobalVar.Employee == true)
            {
                openMenuForm(new SystemTest());
            }
            else if(GlobalVar.Customer == true)
            {
                openMenuForm(new SystemTest());
            }
            else if(GlobalVar.Director==true)
            {
                openMenuForm(new Member());
            }
            else
            {
                openMenuForm(new Member());
            }
        }
        #endregion
        #region 進入商品管理
        private void btn商品管理_Click(object sender, EventArgs e)
        {
            //Management management = new Management();
            //management.ShowDialog();
            panelrow.Height = btn商品管理.Height;
            panelrow.Top = btn商品管理.Top;
            if ((GlobalVar.Employee == true) || (GlobalVar.Director == true)) { openMenuForm(new Management()); }
            
        }
        #endregion
        #region 進入系統管理(未寫)
        private void btn系統管理_Click(object sender, EventArgs e)
        {
            panelrow.Height = btn系統管理.Height;
            panelrow.Top = btn系統管理.Top;
        }
        #endregion
        #region 關閉程式
        private void btnClose_Click(object sender, EventArgs e)
        {
            panelrow.Height = btnClose.Height;
            panelrow.Top = btnClose.Top;
            Application.Exit();
        }
        #endregion
        #region 進入活動
        private void btnActivity_Click(object sender, EventArgs e)
        {
            panelrow.Height = btnActivity.Height;
            panelrow.Top = btnActivity.Top;
            openMenuForm(new Activity());
        }
        #endregion
        #region 登入
        private void btnLogin_Click(object sender, EventArgs e)
        {
            panelrow.Height = btnLogin.Height;
            panelrow.Top = btnLogin.Top;
            Login myLoginForm = new Login();
            myLoginForm.ShowDialog();
        }
        #endregion
        #region 登出
        private void btnLoginOut_Click(object sender, EventArgs e)
        {
            Function.Function.LoginOut();
            panelView.Refresh();
            panelView.Controls.Clear();
            panelrow.Height = btnActivity.Height;
            panelrow.Top = btnActivity.Top;
            openMenuForm(new Activity());
        }
        #endregion

        #region 動態處理
        private void Main_Activated(object sender, EventArgs e)
        {
            if (GlobalVar.LoginSuccess == false)
            {
                btn會員登入.Visible = true;
                btn會員登入.Size = new Size(148,31);
                btn會員登入.Location = new Point(18, 61);
                btn加入會員.Visible = true;
                btnLoginOut.Visible = false;
            }
            else
            {
                btnLoginOut.Visible = true;
                btnLoginOut.Size = new Size(148, 31);
                btnLoginOut.Location = new Point(18, 61);
                btn會員登入.Visible = false;
                btn加入會員.Visible = false;
            }
            if (GlobalVar.Permission > 1000)
            {
                btn商品管理.Enabled = false;
                btn商品管理.Visible = false;
                btnOMS.Enabled = false;
                btnOMS.Visible = false;
            }
            else
            {
                btn商品管理.Enabled = true;
                btn商品管理.Visible = true;
                btnOMS.Enabled = true;
                btnOMS.Visible = true;
            }
            lblName.Text = GlobalVar.訂購人資訊;
        }
        #endregion

        #region 子表單試試看
        private Form activeForm = null;  //確認表單是否開啟
        internal void openMenuForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            panelView.Controls.Clear();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill; //設定子表單位置
            panelView.Controls.Add(childForm);
            panelView.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        internal void openMemberForm()
        {
            Member m = new Member();
            panelView.Controls.Clear();
            if (activeForm != null) activeForm.Close();
            m.TopLevel = false;
            m.FormBorderStyle = FormBorderStyle.None;
            m.Dock = DockStyle.Fill; //設定子表單位置
            panelView.Controls.Add(m);
            panelView.Tag = m;
            m.BringToFront();
            m.Show();
            panelrow.Height = btn會員管理.Height;
            panelrow.Top = btn會員管理.Top;
        }



        #endregion

        private void btn訪客_Click(object sender, EventArgs e)
        {
            panelrow.Height = btn會員管理.Height;
            panelrow.Top = btn會員管理.Top;
            openMenuForm(new Member());
            GlobalVar.Visitor = true;
        }
    }
}
