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

        public static void checkLogin(string FirstName, string Surname, string email, string username, string Password, string RPassword)
        {
            if (!(username == null && email == null))
            {
                try
                {
                    using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                    {
                        string receivedTP = "";
                        string receivedEmail = "";
                        string query = $"SELECT TP FROM Members WHERE TP = @username";
                        MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                        cmd.Parameters.AddWithValue("@username", username);
                        MySqlConn.Open();
                        MySqlDataReader sqlreader = cmd.ExecuteReader();
                        while (sqlreader.Read())
                        {
                            receivedTP = sqlreader[0].ToString();
                        }
                        sqlreader.Close();
                        query = $"SELECT email FROM Members WHERE email = @email";
                        cmd = new MySqlCommand(query, MySqlConn);
                        cmd.Parameters.AddWithValue("@email", email);
                        sqlreader = cmd.ExecuteReader();
                        while (sqlreader.Read())
                        {
                            receivedEmail = sqlreader[0].ToString();
                        }
                        sqlreader.Close();
                        MySqlConn.Close();

                        if (receivedTP == username)
                        {
                            MessageBox.Show("Login already exists");
                        } else if (receivedEmail == email) {
                            MessageBox.Show("Email already exists");
                        }
                        else
                        {
                            Register(FirstName, Surname, email, username, Password, RPassword);
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e);
                }
            }
            else
            {
                MessageBox.Show("Empty username or email field");
            }
        }

        public static void Login(string username, string password) {
            if (!(username == null && password == null))
            {
                try
                {
                    using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                    {
                        string receivedPass = "";
                        string role = "";
                        string id = "";
                        string query = $"SELECT id, password, role FROM Members WHERE TP = @username";
                        MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                        cmd.Parameters.AddWithValue("@username", username);
                        MySqlConn.Open();
                        MySqlDataReader sqlreader = cmd.ExecuteReader();
                        while (sqlreader.Read())
                        {
                            id = sqlreader[0].ToString();
                            receivedPass = sqlreader[1].ToString();
                            role = sqlreader[2].ToString();
                        }
                        sqlreader.Close();
                        MySqlConn.Close();

                        if (MD5Hash(password) == receivedPass)
                        {
                            Properties.Settings.Default.userID = id;
                            Properties.Settings.Default.login = username;
                            Properties.Settings.Default.role = role;
                            Properties.Settings.Default.Save();
                        }
                        else {
                            MessageBox.Show("Incorrect data");
                        }
                    }
                }
                catch (Exception e){
                    MessageBox.Show("Error: " + e);
                }
            }
            else {
                MessageBox.Show("Empty login or pass field");
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


        

    }
}
