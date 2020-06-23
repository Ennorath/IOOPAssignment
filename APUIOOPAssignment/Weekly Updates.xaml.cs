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
    /// Interaction logic for Weekly_Updates.xaml
    /// </summary>
    public partial class Weekly_Updates : Window
    {
        public static string weeklyID;
        public Weekly_Updates()
        {
            InitializeComponent();
            string weeklyID = Member_Home.weeklyID;
            List<string> weeklyDetails = new List<string>();
            byte[] weeklyImage = Database.takeWeekly(weeklyID, out weeklyDetails);
            if (weeklyImage.Length != 0)
                weeklyImg.Source = convertImage.toPicture(weeklyImage);
            else
                weeklyImg.Source = new BitmapImage(new Uri(@"\Images\No Image News.jpg", UriKind.Relative));
            lblCurrentHeadline.Content = weeklyDetails[1];
            lblCurrentClub.Content = weeklyDetails[2];
            lblCurrentDate.Content = weeklyDetails[4];
            lblCurrentTime.Content = weeklyDetails[6];
            lblCurrentLocation.Content = weeklyDetails[7];
            lblCurrentDescription.Content = weeklyDetails[8];
            lblCurrentAchievement.Content = weeklyDetails[9];

            int number = 1;
            List<string> weekIDs = new List<string>();
            List<string> weekHeads = new List<string>();
            List<string> weekDates = new List<string>();
            List<byte[]> weekImages = Database.lastWeeklyUpdates(number, out number, out weekIDs, out weekHeads, out weekDates);

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

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Member_Home MH = new Member_Home();
            MH.Show();
            this.Close();
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

        private void btnMoreNews_Click(object sender, RoutedEventArgs e)
        {
            Member_Home MH = new Member_Home();
            MH.Show();
            this.Close();
        }
    }
}
