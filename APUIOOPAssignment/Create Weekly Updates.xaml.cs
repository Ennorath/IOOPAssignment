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
    /// Interaction logic for Create_Weekly_Updates.xaml
    /// </summary>
    public partial class Create_Weekly_Updates : Window
    {
        public Create_Weekly_Updates()
        {
            InitializeComponent();
        }
        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Weekly_Updates_Representative WR = new Weekly_Updates_Representative();
            WR.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Weekly_Updates_Representative WR = new Weekly_Updates_Representative();
            WR.Show();
            this.Close();
        }
    }
}
