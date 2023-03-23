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
using Function;
using FormsApp0121_訂購系統;


namespace FormsApp0121_訂購系統
{
    public partial class Productdetail : Form
    {
        public int selectID = 0;
        string image_name = "";
        public Productdetail()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowPictureDetail();
        }

        #region 顯示商品詳細資訊
        void ShowPictureDetail()
        {
            if (selectID > 0)
            {
                SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
                con.Open();
                string strSQL = "select * from products where p_id = @searchID;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@searchID", selectID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    lblID.Text = reader["p_id"].ToString();
                    txtName.Text = reader["p_name"].ToString();
                    txtPrice.Text = reader["p_price"].ToString();
                    txtDecribe.Text = reader["p_describe"].ToString();
                    image_name = reader["p_image"].ToString();

                    string PictureAllAddress = GlobalVar.image_dir + image_name;
                    //圖片完整路徑
                    pctboxProduct.Image = Image.FromFile(PictureAllAddress);
                }

                reader.Close();
                con.Close();
            }
            else
            {

            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
