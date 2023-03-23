using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp0121_訂購系統
{
    public partial class Activity : Form
    {
        int 十大頁面 = 0;
        public Activity()
        {
            InitializeComponent();
        }

        private void 十大菜色_Load(object sender, EventArgs e)
        {
            倒數計時();
        }

        #region 倒數
        int time倒數;
        void 倒數計時()
        {
            timer十大.Enabled = true;
            time倒數 = 3;
            timer十大.Interval = 1000;

        }
        private void timer十大_Tick(object sender, EventArgs e)
        {

            timer十大.Enabled = true;
            if (time倒數 > 0)
            {
                time倒數--;
            }
            else if (time倒數 == 0)
            {
                time倒數 = 3;
                if (十大頁面 == 10)
                { 十大頁面 = 0; }
                else
                {
                    tab十大.SelectedTab = tab十大.TabPages[十大頁面];
                    十大頁面++;
                }
            }
        }
        #endregion

        private void btnNewMember_Click(object sender, EventArgs e)
        {
            //Controls.Clear();
            //Main main = new Main();
            Main mainForm = (Main)Application.OpenForms["Main"];
            //mainForm.openMenuForm(new Member());
            mainForm.openMemberForm();
            //main.Controls.Add(this);
        }
        
    }
}
