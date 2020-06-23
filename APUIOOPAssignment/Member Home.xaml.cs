using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace APUIOOPAssignment
{
    /// <summary>
    /// Interaction logic for Member_Home.xaml
    /// </summary>
    public partial class Member_Home : Window
    {
        public int number = 1;
        public static string weeklyID;
        public Member_Home()
        {
            InitializeComponent();
            List<string> weekIDs = new List<string>();
            List<string> weekHeads = new List<string>();
            List<string> weekDates = new List<string>();
            List<byte[]> weekImages = Database.lastWeeklyUpdates(number, out number, out weekIDs, out weekHeads, out weekDates);
            showWeekly(weekIDs, weekHeads, weekDates, weekImages);
            string weekid;
            List<byte[]> weekImage = Database.randomWeekly(weekIDs, out weekid);
            if (weekImages[0].Length != 0)
                randomWeek.Source = convertImage.toPicture(weekImage[0]);
            else
                randomWeek.Source = new BitmapImage(new Uri(@"\Images\No Image News.jpg", UriKind.Relative));
            randomWeekBtn.Tag = weekid;
            if (Properties.Settings.Default.role == "1" || Properties.Settings.Default.role == "2") {
                Button goBack = new Button();
                goBack.Content = "Go back";
                goBack.Height = 30;
                goBack.Width = 60;
                goBack.HorizontalAlignment = HorizontalAlignment.Left;
                goBack.Margin = new Thickness(340, 590, 0, 0);
                goBack.Click += new RoutedEventHandler(this.goBack);
                MHome.Children.Add(goBack);
            }
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.role == "1"){
                Representative representative = new Representative();
                representative.Show();
                this.Close();
            }
            else if (Properties.Settings.Default.role == "2") {
                Admin_Page AP = new Admin_Page();
                AP  .Show();
                this.Close();
            }
        }

        private void btnClub_Click(object sender, RoutedEventArgs e)
        {
            Member member = new Member();
            member.Show();
            this.Close();
        }


        private void btnNextNews_Click(object sender, RoutedEventArgs e)
        {
            List<string> weekIDs = new List<string>();
            List<string> weekHeads = new List<string>();
            List<string> weekDates = new List<string>();
            List<byte[]> weekImages = Database.lastWeeklyUpdates(number, out number, out weekIDs, out weekHeads, out weekDates);
            showWeekly(weekIDs, weekHeads, weekDates, weekImages);
        }

        private void showWeekly(List<string> weekIDs, List<string> weekHeads, List<string> weekDates, List<byte[]> weekImages) {
            if (weekIDs.Count >= 1)
            {
                if (weekImages[0].Length != 0)
                    picNews1.Source = convertImage.toPicture(weekImages[0]);
                else
                    picNews1.Source = new BitmapImage(new Uri(@"\Images\No Image News.jpg", UriKind.Relative));
                lblHeadline1.Content = weekHeads[0];
                lblDate1.Content = weekDates[0];
                weekly1.Tag = weekIDs[0];
            }
            if (weekIDs.Count >= 2)
            {
                if (weekImages[1].Length != 0)
                    picNews2.Source = convertImage.toPicture(weekImages[1]);
                else
                    picNews2.Source = new BitmapImage(new Uri(@"\Images\No Image News.jpg", UriKind.Relative));
                lblHeadline2.Content = weekHeads[1];
                lblDate2.Content = weekDates[1];
                weekly2.Tag = weekIDs[1];
            }
            if (weekIDs.Count == 3)
            {
                if (weekImages[2].Length != 0)
                    picNews3.Source = convertImage.toPicture(weekImages[2]);
                else
                    picNews3.Source = new BitmapImage(new Uri(@"\Images\No Image News.jpg", UriKind.Relative));
                lblHeadline3.Content = weekHeads[2];
                lblDate3.Content = weekDates[2];
                weekly3.Tag = weekIDs[2];
            }
        }

        private void weekly_Click(object sender, RoutedEventArgs e)
        {
            Button weeklyBtn = sender as Button;
            if (weeklyBtn != null)
            {
                weeklyID = weeklyBtn.Tag as string;
                Weekly_Updates WU = new Weekly_Updates();
                WU.Show();
                this.Close();
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Reset();
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }
    }
}
