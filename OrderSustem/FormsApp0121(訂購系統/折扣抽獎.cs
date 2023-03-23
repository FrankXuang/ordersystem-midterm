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

namespace FormsApp0121_訂購系統
{
    public partial class 折扣抽獎 : Form
    {
        //public static List<菜色點選> listButtons = new List<菜色點選>();
        internal static List<string> 折扣 = new List<string>();
        internal static List<double> 折扣數目 = new List<double>();

        public 折扣抽獎()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            
        }

        private void btn返回_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
