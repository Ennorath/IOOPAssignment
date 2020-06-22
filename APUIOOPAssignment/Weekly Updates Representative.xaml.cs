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
        public static string SendWeeklyUpdID;
        public Weekly_Updates_Representative()
        {
            InitializeComponent();
            List<string> weeklyIds = new List<string>();
            List<string> weeklyHeaders = new List<string>();
            List<byte[]> weeklyImages = new List<byte[]>();
            weeklyImages = Database.weeklyUpds(out weeklyIds, out weeklyHeaders);

            int fromTop = 10;
            for (int i = 0; i < weeklyIds.Count; i++) {
                StackPanel group = new StackPanel();
                group.HorizontalAlignment = HorizontalAlignment.Left;
                group.VerticalAlignment = VerticalAlignment.Top;
                group.Margin = new Thickness(0, fromTop, 0, 0);
                Image newImage = new Image();
                newImage.Height = 135;
                newImage.Width = 135;
                newImage.HorizontalAlignment = HorizontalAlignment.Left;
                if (weeklyImages[i].Length != 0)
                {
                    newImage.Source = convertImage.toPicture(weeklyImages[i]);
                }
                else {
                    newImage.Source = new BitmapImage(new Uri(@"\Images\No Image News.jpg", UriKind.Relative));
                }
                Label headlineLabel = new Label();
                headlineLabel.FontFamily = new FontFamily("Berlin Sans FB");
                headlineLabel.FontSize = 14;
                headlineLabel.Content = weeklyHeaders[i];
                headlineLabel.HorizontalAlignment = HorizontalAlignment.Left;
                headlineLabel.Margin = new Thickness(0, 0, 0, 0);

                Button editButton = new Button();
                editButton.Content = "Edit";
                editButton.FontFamily = new FontFamily("Berlin Sans FB");
                editButton.FontSize = 18;
                editButton.Height = 34;
                editButton.Width = 75;
                editButton.HorizontalAlignment = HorizontalAlignment.Left;
                editButton.Margin = new Thickness(400, -100, 0, 0);
                editButton.Tag = weeklyIds[i];
                editButton.Click += new RoutedEventHandler(this.EditButton);

                WeeklyList.Children.Add(group);
                group.Children.Add(newImage);
                group.Children.Add(headlineLabel);
                group.Children.Add(editButton);

            }
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            Button editBtn = sender as Button;
            if (editBtn != null)
            {
                SendWeeklyUpdID = editBtn.Tag as string;
                Create_Weekly_Updates CW = new Create_Weekly_Updates();
                CW.Show();
                this.Close();
            }
        }


        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Representative Re = new Representative();
            Re.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Create_Weekly_Updates CW = new Create_Weekly_Updates();
            CW.Show();
            this.Close();
        }
    }
}
