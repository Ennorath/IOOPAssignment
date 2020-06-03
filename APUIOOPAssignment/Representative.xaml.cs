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
    /// Interaction logic for Representative.xaml
    /// </summary>
    public partial class Representative : Window
    {
        public Representative()
        {
            InitializeComponent();
        }

        private void ButtonClubInfo_Click(object sender, RoutedEventArgs e)
        {
            ClubListRepresentative Cl = new ClubListRepresentative();
            Cl.Show();
            this.Close();
        }

        private void btnWeekly_Click(object sender, RoutedEventArgs e)
        {
            Weekly_Updates_Representative WR = new Weekly_Updates_Representative();
            WR.Show();
            this.Close();
        }

        private void btnViewMember_Click(object sender, RoutedEventArgs e)
        {
            Member_Home MH = new Member_Home();
            MH.Show();
            this.Close();
        }
    }
}
