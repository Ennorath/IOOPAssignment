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
    /// Interaction logic for Club_List_Admin.xaml
    /// </summary>
    public partial class Club_List_Admin : Window
    {
        public Club_List_Admin()
        {
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Admin_Page hm = new Admin_Page();
            hm.Show();
            this.Close();
        }

        private void AddNewClubBtn_Click(object sender, RoutedEventArgs e)
        {
            Add_Club sw = new Add_Club();
            sw.Show();
            this.Close();
        }

        private void editNewsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteNewsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
