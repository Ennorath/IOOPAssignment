using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for Edit_News.xaml
    /// </summary>
    public partial class Edit_News : Window
    {
        string ClubType;
        public Edit_News()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string Headline = txtHeadline.Text;
            string Type = ClubType;
            string Date = Title;
            string Details = new TextRange(txtDetailNews.Document.ContentStart, txtDetailNews.Document.ContentEnd).Text;
            News.Register(Headline, Type, Date, Details);
        }

        private void DateNews_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get DatePicker reference.
            var picker = sender as DatePicker;

            // ... Get nullable DateTime from SelectedDate.
            DateTime? date = picker.SelectedDate;
            if (date == null)
            {
                // ... A null object.
                this.Title = "No date";
            }
            else
            {
                // ... No need to display the time.
                this.Title = date.Value.ToShortDateString();
            }
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbType.SelectedIndex==0)
            {
                ClubType = "Sports";
            }
            else
            if (cmbType.SelectedIndex == 1)
            {
                ClubType = "Hobbies";
            }
            else
            if (cmbType.SelectedIndex == 2)
            {
                ClubType = "Societies";
            }
            else
            if (cmbType.SelectedIndex == 3)
            {
                ClubType = "General Interest";
            }
        }
    }
}
