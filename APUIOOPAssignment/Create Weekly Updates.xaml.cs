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
            if (Weekly_Updates_Representative.SendWeeklyUpdID != null) {
                string weeklyId = Weekly_Updates_Representative.SendWeeklyUpdID;
                List<string> weekDetails = new List<string>();
                byte[] image = Database.takeWeeklyUpd(weeklyId, out weekDetails);
                img.Source = convertImage.toPicture(image);
                txtHeadline.Text = weekDetails[1];
                txtClubName.Text = weekDetails[2];
                cmbType.Text = weekDetails[3];
                txtDate.Text = weekDetails[4];
                cmbTime1.Text = weekDetails[5];
                cmbTime2.Text = weekDetails[6];
                txtLocation.Text = weekDetails[7];
                TextRange textRange = new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd);
                textRange.Text = weekDetails[8];
                TextRange textRangeAch = new TextRange(txtAchievement.Document.ContentStart, txtAchievement.Document.ContentEnd);
                textRangeAch.Text = weekDetails[9];
                byte[] Image = convertImage.toBin(imagePath.Text);
            }
        }
        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp;";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                imagePath.Text = dlg.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imagePath.Text);
                bitmap.EndInit();
                img.Source = bitmap;
            }
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            string Headline = txtHeadline.Text;
            string ClubName = txtClubName.Text;
            string Type = cmbType.Text;
            string Date = txtDate.Text;
            string TimeStart = cmbTime1.Text;
            string TimeEnd = cmbTime2.Text;
            string Location = txtLocation.Text;
            string Description = new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd).Text;
            string Achievement = new TextRange(txtAchievement.Document.ContentStart, txtAchievement.Document.ContentEnd).Text;
            byte[] Image = convertImage.toBin(imagePath.Text);

            if (Weekly_Updates_Representative.SendWeeklyUpdID == null)
            {
                Database.AddWeeklyUpd(Headline, ClubName, Type, Date, TimeStart, TimeEnd, Location, Description, Achievement, Image);
            }
            else {
                Database.UpdWeeklyUpd(Weekly_Updates_Representative.SendWeeklyUpdID, Headline, ClubName, Type, Date, TimeStart, TimeEnd, Location, Description, Achievement, Image);
            }
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
