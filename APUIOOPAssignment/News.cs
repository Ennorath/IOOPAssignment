using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;

namespace APUIOOPAssignment
{
    class News
    {
        private const string connectionString = @"SERVER=31.31.198.66;DATABASE=u0994893_ioopproject;USER ID=u0994893_ioop;PASSWORD=SanatovD;";

        public static bool AddNews(string Headline, string Type, string Date, string Details, string Image)
        {
            try
            {
                if (!(Headline == null || Type == null || Date == null || Details == null))
                {
                    using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                    {
                        string CreatingNews = $"INSERT into News (Headline, Type, Date, Details, Images) VALUES ('{Headline}','{Type}','{Date}','{Details}','{Image}')";
                        MySqlCommand cmd = new MySqlCommand(CreatingNews, MySqlConn);
                        MySqlConn.Open();
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
        
    }
}