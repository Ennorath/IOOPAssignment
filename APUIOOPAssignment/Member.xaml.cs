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
    /// Interaction logic for Member.xaml
    /// </summary>
    public partial class Member : Window
    {
        public static string clubsID;
        public Member()
        {
            InitializeComponent();

            List<string> clubID = new List<string>();
            List<string> clubNames = new List<string>();
            List<byte[]> clubImages = new List<byte[]>();
            clubImages = Database.takeTypeClubs(out clubID, out clubNames, Sports.Name.ToString());
            drawClubs(clubID, clubNames, clubImages, Sports);
            clubImages = Database.takeTypeClubs(out clubID, out clubNames, Societies.Name.ToString());
            drawClubs(clubID, clubNames, clubImages, Societies);
            clubImages = Database.takeOtherClubs(out clubID, out clubNames);
            drawClubs(clubID, clubNames, clubImages, Others);


        }

        private void drawClubs(List<string> clubID, List<string> clubNames, List<byte[]> clubImages, Grid stack) {
            int fromLeft = 16;
            int fromTop = 20;
            int column = 0;
            for (int i = 0; i < clubID.Count(); i++)
            {
                
                StackPanel clubBox = new StackPanel();
                clubBox.HorizontalAlignment = HorizontalAlignment.Left;
                clubBox.VerticalAlignment = VerticalAlignment.Top;
                clubBox.Margin = new Thickness(fromLeft, fromTop, 0, 0);
                
                Image newImage = new Image();
                if (clubImages[i].Length != 0)
                    newImage.Source = convertImage.toPicture(clubImages[i]);
                else
                    newImage.Source = new BitmapImage(new Uri(@"\Images\No Image News.jpg", UriKind.Relative));
                newImage.Height = 135;
                newImage.Width = 135;
                newImage.HorizontalAlignment = HorizontalAlignment.Left;

                Button imageBtn = new Button();
                imageBtn.Height = 135;
                imageBtn.Width = 135;
                imageBtn.Content = newImage;
                imageBtn.Tag = clubID[i];
                imageBtn.Click += new RoutedEventHandler(this.goToClub);

                Label clubNameLabel = new Label();
                clubNameLabel.FontFamily = new FontFamily("Berlin Sans FB");
                clubNameLabel.FontSize = 16;
                clubNameLabel.Content = clubNames[i];
                clubNameLabel.HorizontalAlignment = HorizontalAlignment.Left;
                Grid.SetColumn(clubBox, column);

                stack.Children.Add(clubBox);
                clubBox.Children.Add(imageBtn);
                clubBox.Children.Add(clubNameLabel);

                fromLeft += 20;
                column++;
                if (column == 3)
                {
                    column = 0;
                    fromLeft = 20;
                    fromTop += 220;
                }
            }
        }

        private void goToClub(object sender, RoutedEventArgs e)
        {
            Button imgBtn = sender as Button;
            if (imgBtn != null)
            {
                clubsID = imgBtn.Tag as string;
                Club_Details CD = new Club_Details();
                CD.Show();
                this.Close();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Member_Home MH = new Member_Home();
            MH.Show();
            this.Close();
        }
    }
}
