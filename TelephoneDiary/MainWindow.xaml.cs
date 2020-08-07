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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace TelephoneDiary
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      SqlConnection con = new SqlConnection ("Data Source=.;Initial Catalog=Telephone_Adress;Integrated Security=True");

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

            //List<User> users = new List<User>();
            //users.Add(new User() { FirstName = "Samuel", LastName = "Johnson", Mobile = 58953265, Email = "samJohn@yahoo.fr", Category = tel.Bussiness });
            //users.Add(new User() { FirstName = "Yannick", LastName = "Simo", Mobile = 4564565, Email = "s_asyncrite@yahoo.fr", Category = 0 });
            //dgUsers.ItemsSource = users;
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert Into Telephone_adres Values('" + textbox1.Text + "', '" + textbox2.Text + "','" + textbox3.Text + "','" + textbox4.Text + "','" + comboBox1.Text + "')", con);

            cmd.ExecuteNonQuery();

            //SqlDataAdapter sda = new SqlDataAdapter("select * from Telephone_Adress", con);
            //DataTable dt = new DataTable();

            //sda.Fill(dt);

            con.Close();
            MessageBox.Show("New User inserted successfully!");
            Display();

        }

        List<User> it = new List<User>();
        void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Telephone_adres", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            foreach  (DataRow item in dt.Rows)
            {
                it.Add(new User { FirstName = textbox1.Text, LastName = textbox2.Text, Mobile = textbox3.Text, Email = textbox4.Text, Category = tel.Bussiness });
                dgUsers.ItemsSource = it;
            }
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
