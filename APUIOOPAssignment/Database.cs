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
            byte[] Data;
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

        public static bool joinClub(string userID, string clubID)
        {
            try
            {
                        using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                        {
                            string query = $"UPDATE Members SET `role` = '0', `clubMember` = {clubID} WHERE id = '{userID}'";
                            MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                            MySqlConn.Open();
                            cmd.ExecuteNonQuery();
                            MySqlConn.Close();
                            MessageBox.Show("You was Successfully joined to club");
                            return true;
                        }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
                return false;
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
                            clubNames.Add(club.GetString("ClubName"));
                        }
                    }
                    foreach (string id in clubID)
                    {
                        clubImages.Add(clubImg(id));
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

        public static List<byte[]> takeTypeClubs(out List<string> clubID, out List<string> clubNames, string type)
        {
            clubID = new List<string>();
            clubNames = new List<string>();
            List<byte[]> clubImages = new List<byte[]>();
            try
            {
                using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                {

                    MySqlConn.Open();
                    string query = $"SELECT `clubID`, `ClubName` FROM Clubs WHERE `Type` = '{type}'";
                    MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                    using (MySqlDataReader club = cmd.ExecuteReader())
                    {
                        while (club.Read())
                        {
                            clubID.Add(club.GetString("clubID"));
                            clubNames.Add(club.GetString("ClubName"));
                        }
                    }
                    foreach (string id in clubID)
                    {
                        clubImages.Add(clubImg(id));
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

        public static List<byte[]> takeOtherClubs(out List<string> clubID, out List<string> clubNames)
        {
            clubID = new List<string>();
            clubNames = new List<string>();
            List<byte[]> clubImages = new List<byte[]>();
            try
            {
                using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                {

                    MySqlConn.Open();
                    string query = $"SELECT `clubID`, `Type`, `ClubName` FROM Clubs";
                    MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                    using (MySqlDataReader club = cmd.ExecuteReader())
                    {
                        while (club.Read())
                        {
                            if (club.GetString("Type") != "Sports" && club.GetString("Type") != "Societies")
                            {
                                clubID.Add(club.GetString("clubID"));
                                clubNames.Add(club.GetString("ClubName"));
                            }
                        }
                    }
                    foreach (string id in clubID)
                    {
                        clubImages.Add(clubImg(id));
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
                        return clubImg(clubID);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        public static byte[] takeWeekly(string weeklyID, out List<string> weeklyDetails)
        {
            byte[] Data;
            weeklyDetails = new List<string>();
            List<byte[]> weeklyImage = new List<byte[]>();
            try
            {
                using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                {
                    MySqlConn.Open();
                    string query = $"SELECT `weekID`, `Headline`, `clubName`, `Type`, `Date`, `TimeStart`, `TimeEnd`, `Location`, `Description`, `Achievement` FROM WeeklyUpd WHERE weekID = @id";
                    MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                    cmd.Parameters.AddWithValue("@id", weeklyID);
                    using (MySqlDataReader club = cmd.ExecuteReader())
                    {
                        while (club.Read())
                        {
                            weeklyDetails.Add(club.GetString("weekID"));
                            weeklyDetails.Add(club.GetString("Headline"));
                            weeklyDetails.Add(club.GetString("clubName"));
                            weeklyDetails.Add(club.GetString("Type"));
                            weeklyDetails.Add(club.GetString("Date"));
                            weeklyDetails.Add(club.GetString("TimeStart"));
                            weeklyDetails.Add(club.GetString("TimeEnd"));
                            weeklyDetails.Add(club.GetString("Location"));
                            weeklyDetails.Add(club.GetString("Description"));
                            weeklyDetails.Add(club.GetString("Achievement"));
                        }
                    }
                    query = "SELECT Image FROM WeeklyUpd WHERE weekID = @id";
                    DataSet ds = new DataSet();
                    cmd = new MySqlCommand(query, MySqlConn);
                    cmd.Parameters.AddWithValue("@id", weeklyID);
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

        public static void addRole (string userID)
        {
            try
            {
                using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                {
                    string query = $"UPDATE Members SET role = '1' WHERE id = {userID}";
                    MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                    MySqlConn.Open();
                    cmd.ExecuteNonQuery();
                    MySqlConn.Close();
                    MessageBox.Show("Representative was given to user");
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void deleteRole(string userID)
        {
            try
            {
                using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                {
                    string query = $"UPDATE Members SET role = '0' WHERE id = {userID}";
                    MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                    MySqlConn.Open();
                    cmd.ExecuteNonQuery();
                    MySqlConn.Close();
                    MessageBox.Show("Representative was removed");
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static List<byte[]> lastWeeklyUpdates(int number, out int number1, out List<string> weekIDs, out List<string> weekHeads, out List<string> weekDates)
        {
            List<string> weekID = new List<string>();
            weekIDs = new List<string>();
            weekHeads = new List<string>();
            weekDates = new List<string>();
            List<byte[]> weekImages = new List<byte[]>();
            try
            {
                using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                {
                    MySqlConn.Open();
                    string query = $"SELECT `weekID` FROM WeeklyUpd";
                    MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                    using (MySqlDataReader week = cmd.ExecuteReader())
                    {
                        while (week.Read())
                        {
                            weekID.Add(week.GetValue(0).ToString());
                        }
                    }
                    MySqlConn.Close();
                    int newNum = 1;
                    int maxNum = 0;
                    if (weekID.Count - number * 3 >= 0)
                    {
                        newNum = weekID.Count - number * 3;
                        maxNum = weekID.Count - number * 3 + 3;
                    }
                    else if (weekID.Count - number * 3 == -1)
                    {
                        newNum = weekID.Count - number * 3 + 1;
                        maxNum = 2;
                    }
                    else if (weekID.Count - number * 3 == -2)
                    {
                        newNum = weekID.Count - number * 3 + 2;
                        maxNum = 1;
                    }
                    else {
                        newNum = 1;
                    }
                    for (int i = newNum; i < maxNum; i++) {
                        MySqlConn.Open();
                        query = $"SELECT `weekID`, `Headline`, `Date` FROM WeeklyUpd WHERE weekID = @id";
                        cmd = new MySqlCommand(query, MySqlConn);
                        cmd.Parameters.AddWithValue("@id", weekID[i]);
                        using (MySqlDataReader week = cmd.ExecuteReader())
                        {
                            while (week.Read())
                            {
                                weekIDs.Add(week.GetString("weekID"));
                                weekHeads.Add(week.GetString("Headline"));
                                weekDates.Add(week.GetString("Date"));
                            }
                        }
                        query = "SELECT Image FROM WeeklyUpd WHERE weekID = @id";
                        DataSet ds = new DataSet();
                        cmd = new MySqlCommand(query, MySqlConn);
                        cmd.Parameters.AddWithValue("@id", weekID[i]);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        MySqlConn.Close();
                        da.Fill(ds);
                        weekImages.Add((byte[])ds.Tables[0].Rows[0][0]);
                        cmd.Dispose();
                    }
                    if (weekID.Count - number * 3 > 0)
                    {
                        number1 = number + 1;
                    } else{
                        number1 = 1;
                    }
                    return weekImages;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                number1 = 1;
                return null;
            }
        }

        public static List<byte[]> randomWeekly(List<string> weekIDs, out string weekID)
        {
            weekID = "";
            List<byte[]> weekImage = new List<byte[]>();
            Random r = new Random();
            int number = r.Next(0, weekIDs.Count());
            try
            {
                using (MySqlConnection MySqlConn = new MySqlConnection(connectionString))
                {
                        MySqlConn.Open();
                        string query = $"SELECT `weekID` FROM WeeklyUpd WHERE weekID = @id";
                        MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                        cmd.Parameters.AddWithValue("@id", weekIDs[number]);
                        using (MySqlDataReader week = cmd.ExecuteReader())
                        {
                            while (week.Read())
                            {
                                weekID = week.GetString("weekID");
                            }
                        }
                        query = "SELECT Image FROM WeeklyUpd WHERE weekID = @id";
                        DataSet ds = new DataSet();
                        cmd = new MySqlCommand(query, MySqlConn);
                        cmd.Parameters.AddWithValue("@id", weekIDs[number]);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        MySqlConn.Close();
                        da.Fill(ds);
                        weekImage.Add((byte[])ds.Tables[0].Rows[0][0]);
                        cmd.Dispose();
                        return weekImage;
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
