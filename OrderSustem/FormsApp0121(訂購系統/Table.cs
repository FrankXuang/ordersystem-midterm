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
using Button = System.Windows.Forms.Button;

namespace FormsApp0121_訂購系統
{
    public partial class Table : Form
    {
        List<int> TableSelect = new List<int>();
        List<string> OrderTable = new List<string>();
        public static string TableName = "";
        public Table()
        {
            InitializeComponent();
        }

        private void Table_Load(object sender, EventArgs e)
        {
            int Day = DateTime.Now.Day;
            ReadDataBaseOrder($"Where day(ShopDate) = {Day} and CancelOrder = 0");
            TableSelectAmount();
            foreach (int i in TableSelect)
            {
                Button b = new Button();
                b.Text = "第" + i.ToString() + "桌";
                b.Width = 150;
                b.Height = 50;
                b.ForeColor = Color.Black;
                b.BackColor = Color.LightPink;
                b.Tag = i;
                b.Margin = new Padding(15, 3, 3, 10);
                b.Click += new EventHandler(b_click);
                flowLayoutPanel2.Controls.Add(b);
            }
            foreach (Button b in flowLayoutPanel2.Controls)
            {
                foreach (string j in OrderTable)
                {
                    if (b.Text.ToString() == j)
                    {
                        b.Enabled = false;
                        b.BackColor = Color.Gray;
                    }
                }
            }
            
        }
        private void b_click(object sender, EventArgs e)
        {
            TableName = (sender as Button).Text.ToString();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 桌號加入
        void TableSelectAmount()
        {
            TableSelect.Add(1);
            TableSelect.Add(2);
            TableSelect.Add(3);
            TableSelect.Add(5);
            TableSelect.Add(11);
            TableSelect.Add(13);
            TableSelect.Add(15);
            TableSelect.Add(17);
            TableSelect.Add(21);
            TableSelect.Add(22);
            TableSelect.Add(23);
            TableSelect.Add(31);
            TableSelect.Add(33);
        }
        #endregion

        #region 讀取資料庫ReadDataBaseOrder(string SQL)
        internal void ReadDataBaseOrder(string SQL)
        {
            try
            {
                SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                con.Open();
                string strSQL = ($"select [Table] from Orders {SQL}");
                SqlCommand cmd = new SqlCommand(strSQL, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read() == true)
                {
                    OrderTable.Add(reader["Table"].ToString());
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


    }
}
