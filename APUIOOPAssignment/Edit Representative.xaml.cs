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
    /// Interaction logic for Edit_Representative.xaml
    /// </summary>
    public partial class Edit_Representative : Window
    {
        public static int chosenClub;
        public static string chosenClubName;
        public List<int> clubID = new List<int>();
        public List<string> clubNames = new List<string>();

        public Edit_Representative()
        {
            InitializeComponent();
            clubNames = Database.takeClubNames(out clubID);
            for (int i = 0; i < clubID.Count(); i++) {
                cmbClubList.Items.Add(clubNames[i]);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin_Page ap = new Admin_Page();
            ap.Show();
            this.Close();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int i = clubNames.IndexOf(cmbClubList.Text);
            chosenClub = clubID[i];
            chosenClubName = cmbClubList.Text;
            Members_and_Representative MR = new Members_and_Representative();
            MR.Show();
            this.Close();
        }
    }
}
