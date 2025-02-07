﻿using System;
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
    /// 
    public partial class Edit_Club : Window
    {
        public Edit_Club()
        {
            InitializeComponent();
            List<string> clubDetails = new List<string>();
            string sendClubID = "a";
            if (Club_List_Admin.SendClubID != null)
            {
                sendClubID = Club_List_Admin.SendClubID;
            }
            else if (Representative.clubID != null) {
                sendClubID = Representative.clubID;
            }
            if (sendClubID != "a")
            {
                byte[] image = Database.takeClub(sendClubID, out clubDetails);

                if (image != null)
                {
                    LogoClub.Source = convertImage.toPicture(image);
                }
                if (clubDetails != null)
                {
                    lblClubName.Content = clubDetails[1];
                    lblType.Content = clubDetails[2];
                    lblDate.Content = clubDetails[3];
                    txtPresident.Text = clubDetails[4];
                    txtVicePresident.Text = clubDetails[5];
                    txtSecretary.Text = clubDetails[6];
                    TextRange textRange = new TextRange(txtDetails.Document.ContentStart, txtDetails.Document.ContentEnd);
                    textRange.Text = clubDetails[7];
                    if (Properties.Settings.Default.role == "1") {
                        txtPresident.IsReadOnly = true;
                        txtVicePresident.IsReadOnly = true;
                        txtSecretary.IsReadOnly = true;

                    }
                }
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

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.role == "1")
            {
                Representative R = new Representative();
                R.Show();
                this.Close();
            }
            else if (Properties.Settings.Default.role == "2") {
                Admin_Page AP = new Admin_Page();
                AP.Show();
                this.Close();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string clubID = Club_List_Admin.SendClubID;
            string President = txtPresident.Text;
            string Vice = txtVicePresident.Text;
            string Secretary = txtSecretary.Text;
            string Details = new TextRange(txtDetails.Document.ContentStart, txtDetails.Document.ContentEnd).Text;
            byte[] Image = convertImage.toBin(imagePathText.Text);


            Database.updateClub(clubID, Image, President, Vice, Secretary, Details);
        }
    }
}
