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
    /// Interaction logic for Club_List_Admin.xaml
    /// </summary>
    public partial class Club_List_Admin : Window
    {
        public Club_List_Admin()
        {
            InitializeComponent();

            List<string> clubID = new List<string>();
            List<string> clubNames = new List<string>();

            List <byte[]> clubImages = Database.takeClubs(out clubID, out clubNames);

            int fromLeft = 20;
            int fromTop = 0;
            int column = 0;
            for (int i = 0; i < clubID.Count(); i++) {

                StackPanel clubBox = new StackPanel();
                clubBox.HorizontalAlignment = HorizontalAlignment.Left;
                clubBox.VerticalAlignment = VerticalAlignment.Top;
                clubBox.Margin = new Thickness(fromLeft, fromTop, 0, 0);

                Image newImage = new Image();
                newImage.Source = convertImage.toPicture(clubImages[i]);
                newImage.Height = 135;
                newImage.Width = 135;
                newImage.HorizontalAlignment = HorizontalAlignment.Left;

                Label clubNameLabel = new Label();
                clubNameLabel.FontFamily = new FontFamily("Berlin Sans FB");
                clubNameLabel.FontSize = 16;
                clubNameLabel.Content = clubNames[i];
                clubNameLabel.HorizontalAlignment = HorizontalAlignment.Left;

                Button editButton = new Button();
                editButton.Content = "Edit";
                editButton.Height = 30;
                editButton.Width = 60;
                editButton.HorizontalAlignment = HorizontalAlignment.Left;
                editButton.Margin = new Thickness(-5, 10, 0, 0);
                editButton.Tag = clubID[i];
                editButton.Click += new RoutedEventHandler(this.EditButton);

                Button deleteButton = new Button();
                deleteButton.Content = "Delete";
                deleteButton.Height = 30;
                deleteButton.Width = 60;
                deleteButton.HorizontalAlignment = HorizontalAlignment.Left;
                deleteButton.Margin = new Thickness(80, -30, 0, 0);
                deleteButton.Tag = clubID[i];
                deleteButton.Click += new RoutedEventHandler(this.DeleteButton);
                Grid.SetColumn(clubBox, column);

                GridName.Children.Add(clubBox);

                clubBox.Children.Add(newImage);
                clubBox.Children.Add(clubNameLabel);
                clubBox.Children.Add(editButton);
                clubBox.Children.Add(deleteButton);
                fromLeft += 20;
                column++;
                if (column == 3) {
                    column = 0;
                    fromLeft = 20;
                    fromTop += 220;
                }
            }
            
            //<Image HorizontalAlignment="Left" Height="135" Margin="50,0,0,0" VerticalAlignment="Top" Width="136" Source="Images\No Image.jpg"/>
            //<Button x:Name="editNewsBtn" Content="Edit" HorizontalAlignment="Left" FontFamily="Berlin Sans FB" Margin="190,0,0,0" VerticalAlignment="Top" Width="56" Height="23" Click="editNewsBtn_Click"/>
            //<Button x:Name="deleteNewsBtn" Content="Delete" HorizontalAlignment="Left" FontFamily="Berlin Sans FB" Margin="20,0,0,0" VerticalAlignment="Top" Width="56" Height="23" Click="deleteNewsBtn_Click"/>
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            Button editBtn = sender as Button;
            if (editBtn != null)
            {
                Admin_Page hm = new Admin_Page();
                string num = editBtn.Tag as string;
                hm.Show();
                this.Close();
            }
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            Button deleteBtn = sender as Button;
            if (deleteBtn != null) {
                string clubID = deleteBtn.Tag as string;
                //Database.deleteClub(clubID);
            }
        }



        private void AddNewClubBtn_Click(object sender, RoutedEventArgs e)
        {
            Add_Club sw = new Add_Club();
            sw.Show();
            this.Close();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Admin_Page AP = new Admin_Page();
            AP.Show();
            this.Close();
        }
    }
}
