using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for News_List_Admin.xaml
    /// </summary>
    public partial class News_List_Admin : Window
    {
        public News_List_Admin()
        {
            InitializeComponent();
        }
        private void News_List_Admin_Load(object sender, EventArgs e)
        {

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string HeadlinePass = "Sports";
            Edit_News sw = new Edit_News();
            sw.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string NumOfRows = Database.takeNewsRows();
            int NewHeight = int.Parse(NumOfRows);

            /*do
            {
                int NumberofNews = 0;
                PictureBox picture = new PictureBox
                {
                    Name = "pictureBox",
                    Size = new Size(16, 16),
                    Location = new Point(100, 100),
                    Image = Image.FromFile("hello.jpg"),
                }
                this.Height += 200;
                NewHeight--;
            } while (NewHeight > 0);*/
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Admin_Page sw = new Admin_Page();
            sw.Show();
            this.Close();
        }
    }
}