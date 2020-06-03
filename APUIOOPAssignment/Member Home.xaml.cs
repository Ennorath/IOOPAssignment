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
        public Member_Home()
        {
            InitializeComponent();
        }

        private void btnClub_Click(object sender, RoutedEventArgs e)
        {
            Member member = new Member();
            member.Show();
            this.Close();
        }

        private void btnNews_Click(object sender, RoutedEventArgs e)
        {
            NewsListMember nl = new NewsListMember();
            nl.Show();
            this.Close();

        }
    }
}
