using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using FormsApp0121_訂購系統;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace Function
{
    internal class Function
    {
        static bool Checkcancel = false;
        
        #region Form讀取資料庫FormReadDataBasePicture()
        public static void FormReadDataBasePicture()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "MyMiddle";
            scsb.IntegratedSecurity = true;
            GlobalVar.myDBConnectionString = scsb.ConnectionString;
            GlobalVar.image_dir = @"C:\Users\iSpan\Desktop\全端\OrderSystem(0218\Database\";
        }
        #endregion

        #region Form讀取資料庫FormReadDataBasePicture()
        public static void FormReadDataBaseCustomer()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "MyMiddle";
            scsb.IntegratedSecurity = true;
            GlobalVar.myDBConnectionString = scsb.ConnectionString;
        }
        #endregion

        #region 身分驗證
        public static bool isLogin (string phone, string password)
        {
            bool isLoginSuccess = false;
            SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
            con.Open();
            //string strSQLTEST = "select*from Customers where c_phone = '" + phone + "' and c_pwd = '" + password + "' ";
            //string strSQL3 = "select*from Employee where e_phone = '" + phone + "' and e_pwd = '" + password + "' ";
            string strSQL = "select c_id as 'ID', c_name as '姓名', c_phone as '電話', c_birthday, c_address as '地址', c_permission as '權限',c_cancel as '名單' from Customers where c_phone = '" + phone + "' and c_pwd = '" + password + "' union select e_id as 'ID',e_name as '姓名', e_phone as '電話', e_birthday, e_address as '地址', e_permission as '權限', e_work as '名單' from Employee where e_phone = '" + phone + "' and e_pwd = '" + password + "' ";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            //DataTable dt = new DataTable();
            //SqlDataAdapter reader = new SqlDataAdapter(cmd);
            //reader.Fill(dt);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() == true)
            {
                GlobalVar.訂購人ID = (int)reader["ID"];
                GlobalVar.訂購人資訊 = reader["姓名"].ToString();
                GlobalVar.電話 = reader["電話"].ToString();
                GlobalVar.地址 = reader["地址"].ToString();
                Checkcancel = Convert.ToBoolean(reader["名單"]);
                //GlobalVar.MemberPoint = (int)reader["c_memberpoint"];
                //GlobalVar.MemberCancel = Convert.ToBoolean(reader["c_cancel"]);
                GlobalVar.Permission = (int)reader["權限"];
                //isLoginSuccess = true;
                if((GlobalVar.Permission >1000) && (GlobalVar.Permission <= 10000))
                {
                    if (Checkcancel == false)
                    {
                        isLoginSuccess = true;
                        GlobalVar.Customer = true;
                     }
                    else 
                    {
                        isLoginSuccess = false;
                        GlobalVar.訂購人ID = 0;
                        GlobalVar.訂購人資訊 = "";
                        GlobalVar.電話 = "";
                        GlobalVar.地址 = "";
                        GlobalVar.Permission = 10000;
                    }
                }
                else if((GlobalVar.Permission > 100) && (GlobalVar.Permission <= 1000))
                {
                    if (Checkcancel == true)
                    {
                        isLoginSuccess = true;
                        GlobalVar.Employee = true;
                    }
                    else 
                    { 
                        isLoginSuccess = false;
                        GlobalVar.訂購人資訊 = "";
                        GlobalVar.電話 = "";
                        GlobalVar.地址 = "";
                        GlobalVar.Permission = 10000;
                        GlobalVar.Customer = false;
                        GlobalVar.Employee = false;
                        GlobalVar.System = false;
                        GlobalVar.Director = false;
                    }
                }
                else if ((GlobalVar.Permission > 10) && (GlobalVar.Permission <= 100))
                {
                    if (Checkcancel == true)
                    {
                        isLoginSuccess = true;
                        GlobalVar.Director = true;
                    }
                    else 
                    { 
                        isLoginSuccess = false;
                        GlobalVar.訂購人資訊 = "";
                        GlobalVar.電話 = "";
                        GlobalVar.地址 = "";
                        GlobalVar.Permission = 10000;
                        GlobalVar.Customer = false;
                        GlobalVar.Employee = false;
                        GlobalVar.System = false;
                        GlobalVar.Director = false;
                    }
                }
                else if (GlobalVar.Permission <= 10)
                {
                    if (Checkcancel == true)
                    {
                        isLoginSuccess = true;
                        GlobalVar.System = true;
                    }
                    else
                    { 
                        isLoginSuccess = false;
                        GlobalVar.訂購人資訊 = "";
                        GlobalVar.電話 = "";
                        GlobalVar.地址 = "";
                        GlobalVar.Permission = 10000;
                        GlobalVar.Customer = false;
                        GlobalVar.Employee = false;
                        GlobalVar.System = false;
                        GlobalVar.Director = false;
                    }
                }
            }
            else
            { 
                Console.WriteLine("客戶查無此人");
                isLoginSuccess = false;
                GlobalVar.Customer = false;
                GlobalVar.Employee = false;
                GlobalVar.System = false;
                GlobalVar.Director = false;
            }
            //if (dt.Rows.Count > 0)
            //{
            //    isMember = true;
            //}
            //else
            //{
            //    isMember = false;
            //}
            reader.Close();
            con.Close();

            return isLoginSuccess;
        }
        #endregion

        #region 登出
        public static void LoginOut()
        {
            GlobalVar.Customer = false;
            GlobalVar.LoginSuccess = false;
            GlobalVar.Employee = false;
            GlobalVar.System = false;
            GlobalVar.Visitor = true;
            GlobalVar.Director = false;
            GlobalVar.ComboFood = false;
            GlobalVar.訂購人資訊 = "";
            GlobalVar.Permission = 10000;
            GlobalVar.電話 = "";
            GlobalVar.地址 = "";
            GlobalVar.總價 = 0;
            GlobalVar.SQLShopID = 0;
            MessageBox.Show("你已登出....\n再見請慢走");
        }
        #endregion

        #region 電話確認
        public static bool CheckPhone(string phone)
        {
            bool telcheck = Regex.IsMatch(phone, @"^09[0-9]{8}$");//規則:09開頭，後面接著8個0~9的數字，@是避免跳脫字元
                                                                //isMatch回傳布林值T或F
            return telcheck;
        }
        #endregion

        #region 名字確認
        public static bool CheckChinese(string Name)
        {
            bool namecheck = Regex.IsMatch(Name, @"[\u4e00-\u9fa5]");
            return namecheck;
        }
        #endregion



    }
    #region 讀取甜點產品資料庫ReadDataBaseDessertPicture()(class取消)

    //internal class ReadDataBaseDessertPicture
    //{
    //    internal ReadDataBaseDessertPicture(string strSQL, ImageList image, string type)
    //    {
    //        try
    //        {

    //            SqlConnection con = new SqlConnection(GlobalVar.myDBConnectionString);
    //            con.Open();
    //            //string strSQL = "select * from Products where p_type = '甜點'";
    //            SqlCommand cmd = new SqlCommand(strSQL, con);
    //            SqlDataReader reader = cmd.ExecuteReader();
    //            string image_name = "";
    //            int count = 0;
    //            switch (type)
    //            {
    //                case "Dessert":
    //                    while (reader.Read() == true)
    //                    {
    //                        GlobalVar.listDessertID.Add((int)reader["p_id"]);
    //                        GlobalVar.listDessert.Add(reader["p_name"].ToString());
    //                        GlobalVar.listDessertPrice.Add((int)reader["p_price"]);
    //                        image_name = reader["p_image"].ToString();
    //                        string PictureAllAddress = GlobalVar.image_dir + image_name;
    //                        Image imgProductsPicture = Image.FromFile(PictureAllAddress);
    //                        //GlobalVar.maintest.imgListPicture.Images.Add(imgProductsPicture);
    //                        GlobalVar.maintest.imgListDessert.Images.Add(imgProductsPicture);
    //                        count += 1;
    //                    }
    //                    Console.WriteLine($"圖片{GlobalVar.maintest.imgListDessert.Images.Count}筆");
    //                    break;
    //                case "Drink":
    //                    while (reader.Read() == true)
    //                    {
    //                        GlobalVar.listDrinkID.Add((int)reader["p_id"]);
    //                        GlobalVar.listDrink.Add(reader["p_name"].ToString());
    //                        GlobalVar.listDrinkPrice.Add((int)reader["p_price"]);
    //                        image_name = reader["p_image"].ToString();
    //                        string PictureAllAddress = GlobalVar.image_dir + image_name;
    //                        Image imgProductsPicture = Image.FromFile(PictureAllAddress);
    //                        //GlobalVar.maintest.imgListPicture.Images.Add(imgProductsPicture);
    //                        GlobalVar.maintest.imgListDrink.Images.Add(imgProductsPicture);
    //                        count += 1;
    //                    }
    //                    Console.WriteLine($"圖片{GlobalVar.maintest.imgListDrink.Images.Count}筆");
    //                    break;
    //                case "Savouries":
    //                    while (reader.Read() == true)
    //                    {
    //                        //GlobalVar.listSavouriesID.Add((int)reader["p_id"]);
    //                        //GlobalVar.listSavouries.Add(reader["p_name"].ToString());
    //                        //GlobalVar.listSavouriesPrice.Add((int)reader["p_price"]);
    //                        image_name = reader["p_image"].ToString();
    //                        string PictureAllAddress = GlobalVar.image_dir + image_name;
    //                        Image imgProductsPicture = Image.FromFile(PictureAllAddress);
    //                        //GlobalVar.maintest.imgListPicture.Images.Add(imgProductsPicture);
    //                        GlobalVar.maintest.imgListDrink.Images.Add(imgProductsPicture);
    //                        count += 1;
    //                    }
    //                    Console.WriteLine($"圖片{GlobalVar.maintest.imgListDrink.Images.Count}筆");
    //                    break;
    //                case "Salads":
    //                    while (reader.Read() == true)
    //                    {
    //                        GlobalVar.listDrinkID.Add((int)reader["p_id"]);
    //                        GlobalVar.listDrink.Add(reader["p_name"].ToString());
    //                        GlobalVar.listDrinkPrice.Add((int)reader["p_price"]);
    //                        image_name = reader["p_image"].ToString();
    //                        string PictureAllAddress = GlobalVar.image_dir + image_name;
    //                        Image imgProductsPicture = Image.FromFile(PictureAllAddress);
    //                        //GlobalVar.maintest.imgListPicture.Images.Add(imgProductsPicture);
    //                        GlobalVar.maintest.imgListDrink.Images.Add(imgProductsPicture);
    //                        count += 1;
    //                    }
    //                    Console.WriteLine($"圖片{GlobalVar.maintest.imgListDrink.Images.Count}筆");
    //                    break;
    //                case "Seafood":
    //                    while (reader.Read() == true)
    //                    {
    //                        GlobalVar.listDrinkID.Add((int)reader["p_id"]);
    //                        GlobalVar.listDrink.Add(reader["p_name"].ToString());
    //                        GlobalVar.listDrinkPrice.Add((int)reader["p_price"]);
    //                        image_name = reader["p_image"].ToString();
    //                        string PictureAllAddress = GlobalVar.image_dir + image_name;
    //                        Image imgProductsPicture = Image.FromFile(PictureAllAddress);
    //                        //GlobalVar.maintest.imgListPicture.Images.Add(imgProductsPicture);
    //                        GlobalVar.maintest.imgListDrink.Images.Add(imgProductsPicture);
    //                        count += 1;
    //                    }
    //                    Console.WriteLine($"圖片{GlobalVar.maintest.imgListDrink.Images.Count}筆");
    //                    break;
    //                case "Meat":
    //                    while (reader.Read() == true)
    //                    {
    //                        GlobalVar.listDrinkID.Add((int)reader["p_id"]);
    //                        GlobalVar.listDrink.Add(reader["p_name"].ToString());
    //                        GlobalVar.listDrinkPrice.Add((int)reader["p_price"]);
    //                        image_name = reader["p_image"].ToString();
    //                        string PictureAllAddress = GlobalVar.image_dir + image_name;
    //                        Image imgProductsPicture = Image.FromFile(PictureAllAddress);
    //                        //GlobalVar.maintest.imgListPicture.Images.Add(imgProductsPicture);
    //                        GlobalVar.maintest.imgListDrink.Images.Add(imgProductsPicture);
    //                        count += 1;
    //                    }
    //                    Console.WriteLine($"圖片{GlobalVar.maintest.imgListDrink.Images.Count}筆");
    //                    break;
    //                case "Vegetable":
    //                    while (reader.Read() == true)
    //                    {
    //                        GlobalVar.listDrinkID.Add((int)reader["p_id"]);
    //                        GlobalVar.listDrink.Add(reader["p_name"].ToString());
    //                        GlobalVar.listDrinkPrice.Add((int)reader["p_price"]);
    //                        image_name = reader["p_image"].ToString();
    //                        string PictureAllAddress = GlobalVar.image_dir + image_name;
    //                        Image imgProductsPicture = Image.FromFile(PictureAllAddress);
    //                        //GlobalVar.maintest.imgListPicture.Images.Add(imgProductsPicture);
    //                        GlobalVar.maintest.imgListDrink.Images.Add(imgProductsPicture);
    //                        count += 1;
    //                    }
    //                    Console.WriteLine($"圖片{GlobalVar.maintest.imgListDrink.Images.Count}筆");
    //                    break;
    //                case "RiceNoodle":
    //                    while (reader.Read() == true)
    //                    {
    //                        GlobalVar.listDrinkID.Add((int)reader["p_id"]);
    //                        GlobalVar.listDrink.Add(reader["p_name"].ToString());
    //                        GlobalVar.listDrinkPrice.Add((int)reader["p_price"]);
    //                        image_name = reader["p_image"].ToString();
    //                        string PictureAllAddress = GlobalVar.image_dir + image_name;
    //                        Image imgProductsPicture = Image.FromFile(PictureAllAddress);
    //                        //GlobalVar.maintest.imgListPicture.Images.Add(imgProductsPicture);
    //                        GlobalVar.maintest.imgListDrink.Images.Add(imgProductsPicture);
    //                        count += 1;
    //                    }
    //                    Console.WriteLine($"圖片{GlobalVar.maintest.imgListDrink.Images.Count}筆");
    //                    break;

    //                case "ShrimpPancakes":
    //                    while (reader.Read() == true)
    //                    {
    //                        GlobalVar.listDrinkID.Add((int)reader["p_id"]);
    //                        GlobalVar.listDrink.Add(reader["p_name"].ToString());
    //                        GlobalVar.listDrinkPrice.Add((int)reader["p_price"]);
    //                        image_name = reader["p_image"].ToString();
    //                        string PictureAllAddress = GlobalVar.image_dir + image_name;
    //                        Image imgProductsPicture = Image.FromFile(PictureAllAddress);
    //                        //GlobalVar.maintest.imgListPicture.Images.Add(imgProductsPicture);
    //                        GlobalVar.maintest.imgListDrink.Images.Add(imgProductsPicture);
    //                        count += 1;
    //                    }
    //                    Console.WriteLine($"圖片{GlobalVar.maintest.imgListDrink.Images.Count}筆");
    //                    break;
    //                case "Soup":
    //                    while (reader.Read() == true)
    //                    {
    //                        GlobalVar.listDrinkID.Add((int)reader["p_id"]);
    //                        GlobalVar.listDrink.Add(reader["p_name"].ToString());
    //                        GlobalVar.listDrinkPrice.Add((int)reader["p_price"]);
    //                        image_name = reader["p_image"].ToString();
    //                        string PictureAllAddress = GlobalVar.image_dir + image_name;
    //                        Image imgProductsPicture = Image.FromFile(PictureAllAddress);
    //                        //GlobalVar.maintest.imgListPicture.Images.Add(imgProductsPicture);
    //                        GlobalVar.maintest.imgListDrink.Images.Add(imgProductsPicture);
    //                        count += 1;
    //                    }
    //                    Console.WriteLine($"圖片{GlobalVar.maintest.imgListDrink.Images.Count}筆");
    //                    break;
    //            }
    //            Console.WriteLine($"讀取到{count}筆資料");

    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //            //return ex;
    //        }


    //    }

    //}
    #endregion
}
