using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace APUIOOPAssignment
{
    class Database
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

        public static byte[] clubImg(string clubID)
        {
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

        public static List<byte[]> takeClubs(out List<string> clubID, out List<string> clubNames)
        {
            UInt32 FileSize;
            byte[] Data;
            Bitmap outImage;
            clubID = new List<string>();
            clubNames = new List<string>();
            List<byte[]> clubImages = new List<byte[]>();
            try
            {
                using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                {

                    MySqlConn.Open();
                    string query = $"SELECT `clubID`, `ClubName` FROM Clubs";
                    MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                    using (MySqlDataReader club = cmd.ExecuteReader())
                    {
                        while (club.Read())
                        {
                            clubID.Add(club.GetString("clubID"));
                            //clubDetails.Add(club.GetString("Image"));
                            clubNames.Add(club.GetString("ClubName"));
                            //clubIDS += $"{club.GetInt32("clubID")}";
                            //clubNamess += $"{club.GetString("ClubName")}";
                        }
                    }
                    foreach (string id in clubID)
                    {
                        query = "SELECT Image FROM Clubs WHERE clubID = @id";
                        DataSet ds = new DataSet();
                        cmd = new MySqlCommand(query, MySqlConn);
                        cmd.Parameters.AddWithValue("@id", id);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        MySqlConn.Close();
                        da.Fill(ds);
                        clubImages.Add((byte[])ds.Tables[0].Rows[0][0]);
                        cmd.Dispose();
                    }
                    return clubImages;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

    }
}
