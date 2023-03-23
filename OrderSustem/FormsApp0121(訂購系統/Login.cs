using Function;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace FormsApp0121_訂購系統
{
    public partial class Login : Form
    {
        Function.Function function = new Function.Function();
        int count = 0;
        int num = 0;

        public Login()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void 登入畫面_Load(object sender, EventArgs e)
        {
            Function.Function.FormReadDataBasePicture();

            txtPhone.Text = "0989348623";
            txtPassword.Text = "54321";
            //按鈕顯示();
            if (GlobalVar.LoginSuccess == true)
            {
                //pbxLogin.Enabled = false;
                lblInfo.Text = GlobalVar.訂購人資訊 + " 快去點餐";
                btnNew.Visible = false;
            }
            else { lblInfo.Text = "歡迎光臨，請輸入帳號密碼"; }
        }

        #region 登入
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (GlobalVar.LoginSuccess == false)
            {
                if ((txtPhone.Text != "") && (txtPassword.Text != ""))
                {
                    string strPhone = txtPhone.Text;
                    string strPassword = txtPassword.Text;
                    if (Function.Function.isLogin(strPhone, strPassword) == true)
                    {
                        lblInfo.Text = GlobalVar.訂購人資訊 + " 歡迎你回來";
                        MessageBox.Show("登入成功");
                        GlobalVar.LoginSuccess = true;
                        Close();
                    }
                    else
                    {
                        count += 1;
                        MessageBox.Show("登入失敗");
                        GlobalVar.LoginSuccess = false;
                        lblInfo.Text = ($"帳號密碼錯誤!! 錯誤次數{count}次");
                    }
                    if(count == 5)
                    {
                        lblInfo.Text = ($"來亂的!! 錯誤次數{count}次");
                    }
                }
                else
                {
                    lblInfo.Text = "請輸入帳號密碼";
                }
            }
            else
            {
                num += 1;
                Console.WriteLine(num);
                if (num == 1) { lblInfo.Text = GlobalVar.訂購人資訊 + " 為何按登入?"; }
                else if ((num > 2) && (num < 10)) { lblInfo.Text = GlobalVar.訂購人資訊 + ($"你按了{num}次還按"); }
                else if (num == 10) { btnLogin.Visible = false; }
            }
        }
                
        #endregion

        #region 新辦帳號(跳到Member)
        private void btnNew_Click(object sender, EventArgs e)
        {
            GlobalVar.Visitor=true;
            Member member = new Member();
            member.ShowDialog();
        }
        #endregion

        #region 關不掉(取消)
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (GlobalVar.LoginSuccess == true)
            //{
            //    e.Cancel = false;
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }


        #endregion

        #region 返回
        private void pbxReturn_Click(object sender, EventArgs e)
        {
            if (GlobalVar.LoginSuccess == false)
            {
                GlobalVar.Visitor = true;
            }
            else
            {
                GlobalVar.Visitor = false;
            }
            lblInfo.Text = "";
            count = 0;
            num = 0;
            this.Close();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (GlobalVar.LoginSuccess == false)
            {
                GlobalVar.Visitor = true;
            }
            else
            {
                GlobalVar.Visitor = false;
            }
            lblInfo.Text = "";
            count = 0;
            num = 0;
            this.Close();
        }
        #endregion

        private void timerforerror_Tick(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { txtPassword.UseSystemPasswordChar = false; }
            else { txtPassword.UseSystemPasswordChar = true; }
        }
    }
}
