//using Admin;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace APUIOOPAssignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginUsernameBox.Text;
            string password = LoginPasswordBox.Text;
            string loginInfo = Authorization.Login(username, password);
            if (loginInfo == "0")
            {
                Member member = new Member();
                member.Show();
                this.Close();
            }
            else if (loginInfo == "1")
            {
                Representative representative = new Representative();
                representative.Show();
                this.Close();
            }
            else if (loginInfo == "2")
            {
                Edit_News admin = new Edit_News();
                admin.Show();
                this.Close();
            }
            else { }
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow sw = new RegisterWindow();
            sw.Show();
            this.Close();

        }
    }
}
