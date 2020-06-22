﻿using MySql.Data.MySqlClient;
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

        public static byte[] takeClub(string clubID, out List<string> clubDetails)
        {
            byte[] Data;
            clubDetails = new List<string>();
            List<byte[]> clubImage = new List<byte[]>();
            try
            {
                using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                {
                    MySqlConn.Open();
                    string query = $"SELECT `clubID`, `ClubName`, `Type`, `Date`, `President`, `Vice`, `Secretary`, `Details` FROM Clubs WHERE clubID = @id";
                    MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                    cmd.Parameters.AddWithValue("@id", clubID);
                    using (MySqlDataReader club = cmd.ExecuteReader())
                    {
                        while (club.Read())
                        {
                            clubDetails.Add(club.GetString("clubID"));
                            clubDetails.Add(club.GetString("ClubName"));
                            clubDetails.Add(club.GetString("Type"));
                            clubDetails.Add(club.GetString("Date"));
                            clubDetails.Add(club.GetString("President"));
                            clubDetails.Add(club.GetString("Vice"));
                            clubDetails.Add(club.GetString("Secretary"));
                            clubDetails.Add(club.GetString("Details"));
                            //clubIDS += $"{club.GetInt32("clubID")}";
                            //clubNamess += $"{club.GetString("ClubName")}";
                        }
                    }
                    query = "SELECT Image FROM Clubs WHERE clubID = @id";
                    DataSet ds = new DataSet();
                    cmd = new MySqlCommand(query, MySqlConn);
                    cmd.Parameters.AddWithValue("@id", clubID);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    MySqlConn.Close();
                    if (da != null)
                    {
                        da.Fill(ds);
                        Data = (byte[])ds.Tables[0].Rows[0][0];
                        cmd.Dispose();
                        return Data;
                    }
                    else
                        return null;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static List<string> takeClubNames(out List<int> clubID)
        {
            List<string> clubNames = new List<string>();
            clubID = new List<int>();
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
                            clubID.Add(Convert.ToInt32(club.GetString("clubID")));
                            clubNames.Add(club.GetString("ClubName"));
                        }
                    }
                    return clubNames;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static bool updateClub(string clubID, byte[] Image, string President, string Vice, string Secretary, string Details)
        {
            try
            {
                if (!(clubID == null || President == null || Vice == null || Secretary == null || Details == null))
                {
                    if (Image != null)
                    {
                        using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                        {
                            string query = $"UPDATE Clubs SET Image = @image, President = '{President}', Vice = '{Vice}', Secretary = '{Secretary}', Details = '{Details}' WHERE clubID = '{clubID}'";
                            MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                            MySqlConn.Open();
                            cmd.Parameters.Add("@image", MySqlDbType.Blob).Value = Image;
                            cmd.ExecuteNonQuery();
                            MySqlConn.Close();
                            MessageBox.Show("Club Successfully updated");
                            return true;
                        }
                    }
                    else {
                        using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                        {
                            string query = $"UPDATE Clubs SET President = '{President}', Vice = '{Vice}', Secretary = '{Secretary}', Details = '{Details}' WHERE clubID = {clubID}";
                            MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                            MySqlConn.Open();
                            cmd.ExecuteNonQuery();
                            MySqlConn.Close();
                            MessageBox.Show("Club Successfully updated");
                            return true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("All boxes must be filled!");
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
                return false;
            }

        }

        public static void AddWeeklyUpd(string Headline, string ClubName, string Type, string Date, string TimeStart, string TimeEnd, string Location, string Description, string Achievement, byte[] Image)
        {
            try
            {
                if (!(Image == null || Headline == null || ClubName == null || Type == null || Date == null || TimeStart == null || TimeEnd == null || Location == null || Description == null || Achievement == null))
                {
                    using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                    {
                        string CreatingWeek = $"INSERT into WeeklyUpd (Headline, ClubName, Type, Date, TimeStart, TimeEnd, Location, Description, Achievement, Image) VALUES ('{Headline}','{ClubName}','{Type}','{Date}','{TimeStart}','{TimeEnd}','{Location}','{Description}', '{Achievement}', @image)";
                        MySqlCommand cmd = new MySqlCommand(CreatingWeek, MySqlConn);
                        MySqlConn.Open();
                        cmd.Parameters.Add("@image", MySqlDbType.Blob).Value = Image;
                        cmd.ExecuteNonQuery();
                        MySqlConn.Close();
                        MessageBox.Show("News Successfully created");
                    }
                }
                else if (!(Headline == null || ClubName == null || Type == null || Date == null || TimeStart == null || TimeEnd == null || Location == null || Description == null || Achievement == null))
                {
                    using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                    {
                        string CreatingWeek = $"INSERT into WeeklyUpd (Headline, ClubName, Type, Date, TimeStart, TimeEnd, Location, Description, Achievement) VALUES ('{Headline}','{ClubName}','{Type}','{Date}','{TimeStart}','{TimeEnd}','{Location}','{Description}', '{Achievement}')";
                        MySqlCommand cmd = new MySqlCommand(CreatingWeek, MySqlConn);
                        MySqlConn.Open();
                        cmd.ExecuteNonQuery();
                        MySqlConn.Close();
                        MessageBox.Show("Weekly updates Successfully created");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }

        }

        public static List<byte[]> weeklyUpds(out List<string> weeklyIds, out List<string> weeklyHeaders)
        {
            weeklyIds = new List<string>();
            weeklyHeaders = new List<string>();
            List<byte[]> weeklyImages = new List<byte[]>();
            try
            {
                using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                {

                    MySqlConn.Open();
                    string query = $"SELECT `weekID`, `Headline` FROM WeeklyUpd";
                    MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                    using (MySqlDataReader club = cmd.ExecuteReader())
                    {
                        while (club.Read())
                        {
                            weeklyIds.Add(club.GetString("weekID"));
                            weeklyHeaders.Add(club.GetString("Headline"));
                        }
                    }
                    foreach (string id in weeklyIds)
                    {
                        query = "SELECT Image FROM WeeklyUpd WHERE weekID = @id";
                        DataSet ds = new DataSet();
                        cmd = new MySqlCommand(query, MySqlConn);
                        cmd.Parameters.AddWithValue("@id", id);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        MySqlConn.Close();
                        da.Fill(ds);
                        weeklyImages.Add((byte[])ds.Tables[0].Rows[0][0]);
                        cmd.Dispose();
                    }
                    return weeklyImages;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static byte[] takeWeeklyUpd(string weekID, out List<string> weekDetails)
        {
            byte[] Data;
            weekDetails = new List<string>();
            List<byte[]> weekImage = new List<byte[]>();
            try
            {
                using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                {
                    MySqlConn.Open();
                    string query = $"SELECT `weekID`, `Headline`, `ClubName`, `Type`, `Date`, `TimeStart`, `TimeEnd`, `Location`, `Description`, `Achievement` FROM WeeklyUpd WHERE weekID = @id";
                    MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                    cmd.Parameters.AddWithValue("@id", weekID);
                    using (MySqlDataReader week = cmd.ExecuteReader())
                    {
                        while (week.Read())
                        {
                            weekDetails.Add(week.GetString("weekID"));
                            weekDetails.Add(week.GetString("Headline"));
                            weekDetails.Add(week.GetString("ClubName"));
                            weekDetails.Add(week.GetString("Type"));
                            weekDetails.Add(week.GetString("Date"));
                            weekDetails.Add(week.GetString("TimeStart"));
                            weekDetails.Add(week.GetString("TimeEnd"));
                            weekDetails.Add(week.GetString("Location"));
                            weekDetails.Add(week.GetString("Description"));
                            weekDetails.Add(week.GetString("Achievement"));
                        }
                    }
                    query = "SELECT Image FROM WeeklyUpd WHERE weekID = @id";
                    DataSet ds = new DataSet();
                    cmd = new MySqlCommand(query, MySqlConn);
                    cmd.Parameters.AddWithValue("@id", weekID);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    MySqlConn.Close();
                    if (da != null)
                    {
                        da.Fill(ds);
                        Data = (byte[])ds.Tables[0].Rows[0][0];
                        cmd.Dispose();
                        return Data;
                    }
                    else
                        return null;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static void UpdWeeklyUpd(string weekID, string Headline, string ClubName, string Type, string Date, string TimeStart, string TimeEnd, string Location, string Description, string Achievement, byte[] Image)
        {
            try
            {
                if (!(weekID == null || Image == null || Headline == null || ClubName == null || Type == null || Date == null || TimeStart == null || TimeEnd == null || Location == null || Description == null || Achievement == null))
                {
                    using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                    {
                        string CreatingWeek = $"UPDATE WeeklyUpd SET Headline = '{Headline}', ClubName = '{ClubName}', Type = '{Type}', Date = '{Date}', TimeStart = '{TimeStart}', TimeEnd = '{TimeEnd}', Location = '{Location}', Description = '{Description}', Achievement = '{Achievement}', Image = @image WHERE weekID = '{weekID}'";
                        MySqlCommand cmd = new MySqlCommand(CreatingWeek, MySqlConn);
                        MySqlConn.Open();
                        cmd.Parameters.Add("@image", MySqlDbType.Blob).Value = Image;
                        cmd.ExecuteNonQuery();
                        MySqlConn.Close();
                        MessageBox.Show("News Successfully created");
                    }
                }
                else if (!(weekID == null || Headline == null || ClubName == null || Type == null || Date == null || TimeStart == null || TimeEnd == null || Location == null || Description == null || Achievement == null))
                {
                    using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                    {
                        string CreatingWeek = $"UPDATE WeeklyUpd SET Headline = '{Headline}', ClubName = '{ClubName}', Type = '{Type}', Date = '{Date}', TimeStart = '{TimeStart}', TimeEnd = '{TimeEnd}', Location = '{Location}', Description = '{Description}', Achievement = '{Achievement}' WHERE weekID = '{weekID}'";
                        MySqlCommand cmd = new MySqlCommand(CreatingWeek, MySqlConn);
                        MySqlConn.Open();
                        cmd.ExecuteNonQuery();
                        MySqlConn.Close();
                        MessageBox.Show("Weekly updates Successfully created");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }

        }

        public static List<string> memberList(int clubID, out List<int> memberID, out List<int> memberRole)
        {
            List<string> memberNames = new List<string>();
            memberID = new List<int>();
            memberRole = new List<int>();
            try
            {
                using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                {
                    MySqlConn.Open();
                    string query = $"SELECT `id`, `name`, `surname`, `role` FROM Members WHERE clubMember = {clubID}";
                    MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                    using (MySqlDataReader member = cmd.ExecuteReader())
                    {
                        while (member.Read())
                        {
                            memberID.Add(Convert.ToInt32(member.GetString("id")));
                            memberNames.Add(member.GetString("name") + " " + member.GetString("surname"));
                            memberRole.Add(Convert.ToInt32(member.GetString("role")));
                        }
                    }
                    return memberNames;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        
        public static string checkMemberClub(int userID)
        {
            try
            {
                using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                {
                    string clubMember = "0";
                    MySqlConn.Open();
                    string query = $"SELECT `clubMember` FROM Members WHERE id = {userID}";
                    MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                    using (MySqlDataReader member = cmd.ExecuteReader())
                    {
                        while (member.Read())
                        {
                            clubMember = member.GetString("clubMember");
                        }
                    }
                    return clubMember;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return "0";
            }
        }

        public static bool deleteClub(string clubID)
        {
            try
            {
                using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                {
                    string query = $"DELETE FROM `Clubs` WHERE clubID = '{clubID}'";
                    MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                    MySqlConn.Open();
                    cmd.ExecuteNonQuery();
                    MySqlConn.Close();
                    MessageBox.Show("Club Successfully deleted");
                    return true;
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
