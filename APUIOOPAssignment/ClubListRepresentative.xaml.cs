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
    /// Interaction logic for ClubListRepresentative.xaml
    /// </summary>
    public partial class ClubListRepresentative : Window
    {
        public ClubListRepresentative()
        {
            InitializeComponent();
        }

        private void btnEditNews_Click(object sender, RoutedEventArgs e)
        {
            Edit_Club NC = new Edit_Club();
            NC.Show();
            this.Close();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Representative Re = new Representative();
            Re.Show();
            this.Close();
        }
    }
}
