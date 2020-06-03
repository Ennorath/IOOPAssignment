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
    /// Interaction logic for Members_and_Representative.xaml
    /// </summary>
    public partial class Members_and_Representative : Window
    {
        public Members_and_Representative()
        {
            InitializeComponent();
        }

        private void btnBlack_Click(object sender, RoutedEventArgs e)
        {
            Edit_Representative er = new Edit_Representative();
            er.Show();
            this.Close();
        }
    }
}
