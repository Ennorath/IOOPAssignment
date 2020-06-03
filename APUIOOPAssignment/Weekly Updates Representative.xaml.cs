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
    /// Interaction logic for Weekly_Updates_Representative.xaml
    /// </summary>
    public partial class Weekly_Updates_Representative : Window
    {
        public Weekly_Updates_Representative()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Create_Weekly_Updates CW = new Create_Weekly_Updates();
            CW.Show();
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
