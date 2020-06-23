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
    /// Interaction logic for Sports_Hobbies_Details.xaml
    /// </summary>
    public partial class Club_Details : Window
    {
        public Club_Details()
        {
            InitializeComponent();
            string clubID = Member.clubsID;
            List<string> clubDetails = new List<string>();
            byte[] clubImage = Database.takeClub(clubID, out clubDetails);
            if (clubImage.Length != 0)
                picClubLogo.Source = convertImage.toPicture(clubImage);
            else
                picClubLogo.Source = new BitmapImage(new Uri(@"\Images\No Image News.jpg", UriKind.Relative));
            lblClubName.Content = clubDetails[1];
            lblType.Content = clubDetails[2];
            lblDate.Content = clubDetails[3];
            lblPresident.Content = clubDetails[4];
            lblVice.Content = clubDetails[5];
            lblSecretary.Content = clubDetails[6];
            lblDescription.Content = clubDetails[7];
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Member_Home MH = new Member_Home();
            MH.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Member M = new Member();
            M.Show();
            this.Close();
        }

        private void joinBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.role == "0")
            {
                Database.joinClub(Properties.Settings.Default.userID, Member.clubsID);
            }
            else if (Properties.Settings.Default.role == "1")
            {
                MessageBox.Show("You will lose representative role, because you are moving to another club");
                Database.joinClub(Properties.Settings.Default.userID, Member.clubsID);
            }
            else {
                MessageBox.Show("Admin can't be in club.");
            }
        }
    }
}
