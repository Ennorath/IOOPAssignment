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
    /// Interaction logic for Members_and_Representative.xaml
    /// </summary>
    public partial class Members_and_Representative : Window
    {
        public Members_and_Representative()
        {
            InitializeComponent();
            int chosenClub = Edit_Representative.chosenClub;
            lblClubName.Content = Edit_Representative.chosenClubName;
            List<int> memberID = new List<int>(); 
            List<int> memberRole = new List<int>();
            List<string> memberNames = new List<string>();
            memberNames = Database.memberList(chosenClub, out memberID, out memberRole);
            int fromTop = 10;
            for (int i = 0; i < memberNames.Count; i++)
            {
                StackPanel group = new StackPanel();
                group.HorizontalAlignment = HorizontalAlignment.Left;
                group.VerticalAlignment = VerticalAlignment.Top;
                group.Margin = new Thickness(0, fromTop, 0, 0);

                Image img = new Image();
                BitmapImage image = new BitmapImage(new Uri(@"\Images\bg white representative.png", UriKind.Relative));
                img.Source = image;
                img.HorizontalAlignment = HorizontalAlignment.Left;
                img.VerticalAlignment = VerticalAlignment.Top;
                img.Margin = new Thickness(0, 0, 0, 0);

                Label lblName = new Label();
                lblName.FontFamily = new FontFamily("Berlin Sans FB");
                lblName.FontSize = 20;
                lblName.Content = memberNames[i];
                lblName.HorizontalAlignment = HorizontalAlignment.Left;
                lblName.VerticalAlignment = VerticalAlignment.Top;
                lblName.Margin = new Thickness(20, -38, 0, 0);

                Label lblStatus = new Label();

                if (memberRole[i] == 0)
                    lblStatus.Content = "Member";
                else if (memberRole[i] == 1)
                    lblStatus.Content = "Representative";
                else 
                    lblStatus.Content = "Admin";

                lblStatus.FontFamily = new FontFamily("Berlin Sans FB");
                lblStatus.FontSize = 20;
                lblStatus.HorizontalAlignment = HorizontalAlignment.Left;
                lblStatus.VerticalAlignment = VerticalAlignment.Top;
                lblStatus.Margin = new Thickness(260, -38, 0, 0);

                CheckBox onOff = new CheckBox();
                if (memberRole[i] > 0) {
                    onOff.IsChecked = true;
                }
                onOff.Height = 30;
                onOff.Width = 30;
                onOff.HorizontalAlignment = HorizontalAlignment.Left;
                onOff.Margin = new Thickness(480, -28, 0, 0);
                onOff.Tag = memberRole;
                onOff.Click += new RoutedEventHandler(this.CheckedButton);

                memberList.Children.Add(group);

                //<Image Source="Images\button OFF.png" Height="28" Width="56" />
                group.Children.Add(img);
                group.Children.Add(lblName);
                group.Children.Add(lblStatus);
                group.Children.Add(onOff);

                //<Button x:Name="btnUpdate" Content="Update Status" HorizontalAlignment="Left" Margin="277,910,0,0" VerticalAlignment="Top" Width="140" Height="33" FontFamily="Berlin Sans FB" FontSize="18"/>

                Button btnUpdate = new Button();
                btnUpdate.FontFamily = new FontFamily("Berlin Sans FB");
                btnUpdate.FontSize = 24;
                btnUpdate.Content = "Update Status";
                btnUpdate.HorizontalAlignment = HorizontalAlignment.Center;
                btnUpdate.VerticalAlignment = VerticalAlignment.Bottom;
                btnUpdate.Margin = new Thickness(0,30,0,30);

                memberListGrid.Children.Add(btnUpdate);
            }
        }

        private void CheckedButton(object sender, RoutedEventArgs e)
        {
            Button deleteBtn = sender as Button;
            if (deleteBtn != null)
            {
                string clubID = deleteBtn.Tag as string;
                Database.deleteClub(clubID);
                Club_List_Admin CLA = new Club_List_Admin();
                CLA.Show();
                this.Close();
            }
        }

        private void btnBlack_Click(object sender, RoutedEventArgs e)
        {
            Edit_Representative er = new Edit_Representative();
            er.Show();
            this.Close();
        }
    }
}
