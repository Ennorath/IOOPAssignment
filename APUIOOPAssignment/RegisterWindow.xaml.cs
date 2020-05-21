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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow sw = new MainWindow();
            sw.Show();
            this.Close();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = FirstNameBox.Text;
            string Surname = SurnameBox.Text;
            string Email = EmailBox.Text;
            string StudentTP = StudentTPBox.Text;
            string Password = PasswordBox.Text;
            string RPassword = RPasswordBox.Text;
            Authorization.Register(FirstName, Surname, Email, StudentTP, Password, RPassword);
        }
    }
}
