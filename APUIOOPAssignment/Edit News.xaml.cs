using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace APUIOOPAssignment
{
    /// <summary>
    /// Interaction logic for Edit_News.xaml
    /// </summary>
    public partial class Edit_News : Window
    {
        string ClubType;
        string imgLocation = "";
        public Edit_News()
        {
            /*txtHeadline.Text = "Sports";
            string ImageLocation, ClubTypeOld, idate, DetailsOld = Authorization.LoadNews(txtHeadline.Text);

            //Image
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(ImageLocation);
            bitmap.EndInit();
            ImageNewsNew.Source = bitmap;

            //Club type
            cmbType.Text = ClubTypeOld;

            //Date
            DateTime dt = Convert.ToDateTime(idate);
            DateNews.SelectedDate = dt;

            //Details
            (txtDetailNews.Document.ContentStart, txtDetailNews.Document.ContentEnd).Text = Details;*/

            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            File.Copy(textbox1.Text, System.IO.Path.Combine(@"C:\Users\Yosua Daniel\source\repos\Ennorath\IOOPAssignment\APUIOOPAssignment\Images\", System.IO.Path.GetFileName(textbox1.Text)), true);

            string Image = textbox1.Text;
            string Headline = txtHeadline.Text;
            string Type = ClubType;
            string Date = Title;
            string Details = new TextRange(txtDetailNews.Document.ContentStart, txtDetailNews.Document.ContentEnd).Text;
            News.AddNews(Headline, Type, Date, Details, Image);
        }

        private void DateNews_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
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

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbType.SelectedIndex == 0)
            {
                ClubType = "Sports";
            }
            else
            if (cmbType.SelectedIndex == 1)
            {
                ClubType = "Hobbies";
            }
            else
            if (cmbType.SelectedIndex == 2)
            {
                ClubType = "Societies";
            }
            else
            if (cmbType.SelectedIndex == 3)
            {
                ClubType = "General Interest";
            }
        }

        private void btnAddImageNews_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp;";
           
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                textbox1.Text = dlg.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(textbox1.Text);
                bitmap.EndInit();
                ImageNewsNew.Source = bitmap;

            }
        }
    }
}
