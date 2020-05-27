using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
        int count = 0;
        public Representative()
        {
            InitializeComponent();
        }

        private void button_OperatesON()
        {

            if (Count ==1)
            {
                BitmapImage logo1 = new BitmapImage();
                logo1.BeginInit();
                logo1.UriSource = new Uri("C:/Users/Yosua Daniel/source/repos/Ennorath/IOOPAssignment/APUIOOPAssignment/Images/button ON.png");
                logo1.EndInit();

                back1.Source = logo1;


            }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
                if (count == 0) 
                {
                    count = 1;
                    button_OperatesON();
                }
        }
    }
}
