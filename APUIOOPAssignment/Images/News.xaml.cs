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

namespace APUIOOPAssignment.Images
{
    /// <summary>
    /// Interaction logic for News.xaml
    /// </summary>
    public partial class News : Window
    {
        public News()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Member_Home MH = new Member_Home();
            MH.Show();
            this.Close();
        }
    }
}
