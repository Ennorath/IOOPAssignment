using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Add_Club.xaml
    /// </summary>
    public partial class Add_Club : Window
    {
        string ClubType;
        public Add_Club()
        {
            InitializeComponent();
        }

        private void DateClub_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get DatePicker reference.
            var picker = sender as DatePicker;

            // ... Get nullable DateTime from SelectedDate.
            DateTime? date = picker.SelectedDate;
            if (date == null)
            {
                // ... A null object.
                this.Title = "No date";
            }
            else
            {
                // ... No need to display the time.
                this.Title = date.Value.ToShortDateString();
            }
        }
        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp;";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                imagePathText.Text = dlg.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imagePathText.Text);
                bitmap.EndInit();
                LogoClub.Source = bitmap;
            }
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (clubTypeCmb.SelectedIndex == 0)
            {
                ClubType = "Sports";
            }
            else
            if (clubTypeCmb.SelectedIndex == 1)
            {
                ClubType = "Hobbies";
            }
            else
            if (clubTypeCmb.SelectedIndex == 2)
            {
                ClubType = "Societies";
            }
            else
            if (clubTypeCmb.SelectedIndex == 3)
            {
                ClubType = "General Interest";
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Club_List_Admin cl = new Club_List_Admin();
            cl.Show();
            this.Close();
        }

        private void saveClub(object sender, RoutedEventArgs e)
        {
            string ClubName = clubNameText.Text;
            string Type = ClubType;
            string Date = Title;
            string President = presidentText.Text;
            string Vice = vicePresidentText.Text;
            string Secretary = secretaryText.Text;
            string Details = new TextRange(detailsText.Document.ContentStart, detailsText.Document.ContentEnd).Text;
            byte[] Image = convertImage.toBin(imagePathText.Text);


            Database.AddClub(Image, ClubName, Type, Date, President, Vice, Secretary, Details);

        }
    }
}
