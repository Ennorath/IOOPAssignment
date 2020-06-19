using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace APUIOOPAssignment
{
    class Authorization
    {
        private const string connectionString = @"SERVER=31.31.198.66;DATABASE=u0994893_ioopproject;USER ID=u0994893_ioop;PASSWORD=SanatovD;";
        public static IList<String> LoadNews(string HeadlinePass)
        {
            using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
            {
                MySqlConn.Open();
                List<String> NewsInfo = new List<string>();
                string selectPass = $"SELECT Images, Type, Date, Details FROM News List WHERE Headline = @Headline";
                MySqlCommand cmd = new MySqlCommand(selectPass, MySqlConn);
                cmd.Parameters.AddWithValue("@Headline", HeadlinePass);
                using (MySqlDataReader da = cmd.ExecuteReader())
                {
                    while (da.Read())
                    {
                        //Image
                        string ImageLocation = da.GetValue(0).ToString();
                        NewsInfo.Add(ImageLocation);

                        //Type
                        string ClubTypeOld = da.GetValue(1).ToString();
                        NewsInfo.Add(ClubTypeOld);

                        //DatePicker
                        string idate = da.GetValue(2).ToString();
                        NewsInfo.Add(idate);

                        //Details
                        string DetailsOld = da.GetValue(3).ToString();
                        NewsInfo.Add(DetailsOld);
                    }
                }
                MySqlConn.Close();
                return NewsInfo;


            }
        }
        public static string takeNewsRows()
        {
            using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
            {
                string rowsQuery = $"SELECT count(*) FROM News List";
                MySqlCommand cmd1 = new MySqlCommand(rowsQuery, MySqlConn);
                MySqlConn.Open();
                var queryResult1 = cmd1.ExecuteScalar();
                string queryResultStr;
                if (queryResult1 != null)
                    queryResultStr = Convert.ToString(queryResult1);
                else
                    queryResultStr = "";
                MySqlConn.Close();
                MessageBox.Show(queryResultStr);
                return queryResultStr;
            }
        }

        public static string Login(string username, string password) {
            if (!(username == null && password == null))
            {
                try
                {
                    using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                    {
                        string receivedPass = "";
                        string role = "";
                        
                        string query = $"SELECT password, role FROM Members WHERE TP = @username";
                        MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                        cmd.Parameters.AddWithValue("@username", username);
                        MySqlConn.Open();
                        MySqlDataReader sqlreader = cmd.ExecuteReader();
                        while (sqlreader.Read())
                        {
                            receivedPass = sqlreader[0].ToString();
                            role = sqlreader[1].ToString();
                        }
                        sqlreader.Close();
                        MySqlConn.Close();

                        if (MD5Hash(password) == receivedPass)
                        {
                            return role;
                        }
                        else {
                            MessageBox.Show("Incorrect data");
                            return "false";
                        }
                    }
                }
                catch (Exception e){
                    MessageBox.Show("Error: " + e);
                    return "false";
                }
            }
            else {
                MessageBox.Show("Empty login or pass field");
                return "false";
            }
        }

        public static bool Register(string FirstName, string Surname, string Email, string StudentTP, string Password, string RPassword) {
            try
            {
                if (!(FirstName == null || Surname == null || StudentTP == null || Password == null || RPassword == null)){
                    using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                    {
                        string selectPass = $"INSERT into Members (TP, password, name, surname, email) VALUES ('{StudentTP}','{MD5Hash(Password)}','{FirstName}','{Surname}', '{Email}')";
                        MySqlCommand cmd = new MySqlCommand(selectPass, MySqlConn);
                        MySqlConn.Open();
                        cmd.ExecuteNonQuery();
                        MySqlConn.Close();
                        MessageBox.Show("Succesfully registered");
                        return true;
                    }
                }
                else {
                    return false;
                }
            }
            catch (Exception e) {
                MessageBox.Show("Error: " + e);
                return false;
            }
            
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }


        public static bool AddClub(byte[] Image, string ClubName, string Type, string Date, string President, string Vice, string Secretary, string Details)
        {
            try
            {
                if (!(Image == null || ClubName == null || Type == null || Date == null || President == null || Vice == null || Secretary == null || Details == null))
                {
                    using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                    {
                        string CreatingNews = $"INSERT into Clubs (Image, ClubName, Type, Date, President, Vice, Secretary, Details) VALUES (@image,'{ClubName}','{Type}','{Date}','{President}','{Vice}','{Secretary}','{Details}')";
                        MySqlCommand cmd = new MySqlCommand(CreatingNews, MySqlConn);
                        MySqlConn.Open();
                        cmd.Parameters.Add("@image", MySqlDbType.Blob).Value = Image;
                        cmd.ExecuteNonQuery();
                        MySqlConn.Close();
                        MessageBox.Show("News Successfully created");
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
                return false;
            }

        }

        public static byte[] clubImg(string clubID) {
            UInt32 FileSize;
            byte[] Data;
            Bitmap outImage;
            try
            {
                    MySqlConnection connection = new MySqlConnection(connectionString);       
                    string query = "SELECT Image FROM Clubs WHERE clubID = @id";
                    connection.Open();
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", clubID);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(ds);
                    connection.Close();
                    Data = (byte[])ds.Tables[0].Rows[0][0];
                    cmd.Dispose();
                
                return Data;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }

    }
}
