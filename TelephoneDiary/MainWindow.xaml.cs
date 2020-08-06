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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace TelephoneDiary
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonPopUp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);

        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonMenuOpen.Visibility = Visibility.Collapsed;
            ButtonMenuClose.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonMenuOpen.Visibility = Visibility.Visible;
            ButtonMenuClose.Visibility = Visibility.Collapsed;
        }

        private void BttNew_Click(object sender, RoutedEventArgs e)
        {
            textbox1.Clear();
            textbox2.Clear();
            textbox3.Clear();
            textbox4.Clear();
            comboBox1.SelectedIndex = -1;
            textbox1.Focus();
        }

        private void BttInsert_Click(object sender, RoutedEventArgs e)
        {
            DataGrid data = new DataGrid();
            List<User> users = new List<User>();
            users.Add(new User() { FirstName = "Samuel", LastName = "Johnson", Mobile = 58953265, Email = "samJohn@yahoo.fr", Category = tel.Bussiness });
            users.Add(new User() { FirstName = "Yannick", LastName = "Simo", Mobile = 4564565, Email = "s_asyncrite@yahoo.fr", Category = 0 });
            dgUsers.ItemsSource = users;
            MessageBox.Show("New User inserted successfully!");
        }

        private void BttUpdate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Update successfull !");
        }

        private void BttDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("deletelSuccessfull");
        }
    }
}
