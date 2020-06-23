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
    /// Interaction logic for Admin_Page.xaml
    /// </summary>
    public partial class Admin_Page : Window
    {
        public Admin_Page()
        {
            InitializeComponent();
        }

        private void btnClub_Click(object sender, RoutedEventArgs e)
        {
            Club_List_Admin cl = new Club_List_Admin();
            cl.Show();
            this.Close();
        }

        private void btnViewMember_Click(object sender, RoutedEventArgs e)
        {
            Member_Home mh = new Member_Home();
            mh.Show();
            this.Close();
        }

        private void btnEditRepresentative_Click(object sender, RoutedEventArgs e)
        {
            Edit_Representative er = new Edit_Representative();
            er.Show();
            this.Close();
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
