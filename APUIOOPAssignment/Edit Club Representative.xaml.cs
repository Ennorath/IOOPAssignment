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
    /// Interaction logic for Edit_Club_Representative.xaml
    /// </summary>
    public partial class Edit_Club_Representative : Window
    {
        public Edit_Club_Representative()
        {
            InitializeComponent();
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp;";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                TextBox1.Text = dlg.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(TextBox1.Text);
                bitmap.EndInit();
                LogoClub.Source = bitmap;
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            ClubListRepresentative Cl = new ClubListRepresentative();
            Cl.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClubListRepresentative cl = new ClubListRepresentative();
            cl.Show();
            this.Close();
        }
    }
}
