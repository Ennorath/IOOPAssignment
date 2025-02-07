﻿//using Admin;
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
            if (Properties.Settings.Default.userID != "") {
                redirect();
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginUsernameBox.Text;
            string password = LoginPasswordBox.Password;
            Authorization.Login(username, password);
            redirect();
        }

        private void redirect() {

                if (Properties.Settings.Default.role == "0")
                {
                    Member_Home MH = new Member_Home();
                    MH.Show();
                    this.Close();
                }
                else if (Properties.Settings.Default.role == "1")
                {
                    Representative representative = new Representative();
                    representative.Show();
                    this.Close();
                }
                else if (Properties.Settings.Default.role == "2")
                {
                    Admin_Page admin = new Admin_Page();
                    admin.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You don't have any roles, bug happened.");
                }
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow sw = new RegisterWindow();
            sw.Show();
            this.Close();

        }
    }
}
