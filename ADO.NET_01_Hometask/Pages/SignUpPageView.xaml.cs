using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ADO.NET_01_Hometask.Pages
{

    public partial class SignUpPageView : Page,INotifyPropertyChanged
    {
        public SignUpPageView()
        {
            InitializeComponent();
            DataContext = this;
        }

        private string? password2;
        private string? password1;
        private string? email;
        private int age;
        private string? lastname;
        private string? firstname;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public string? Firstname { get => firstname; set { firstname = value; OnPropertyChanged(); } }

        public string? Lastname { get => lastname; set { lastname = value; OnPropertyChanged(); } }

        public int Age { get => age; set { age = value; OnPropertyChanged(); } }

        public string? Email { get => email; set { email = value; OnPropertyChanged(); } }

        public string? Password1 { get => password1; set { password1 = value; OnPropertyChanged(); } }

        public string? Password2 { get => password2; set { password2 = value; OnPropertyChanged(); } }

        private void Cancel_btn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new LoginPageView());

        }

        private void SignUp_btn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((Firstname != null || Firstname != "") && (Lastname != null || Lastname != "") && (Email != null || Email != "") && (Password1 != null || Password1 != "") && (Password1 != null || Password1 != ""))
            {
                if (Password1 == Password2)
                {
                    string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=UsersDB;Integrated Security=SSPI;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = $@"INSERT INTO Users([FirstName],[LastName],[Age],[Email],[Password])
                                      VALUES('{Firstname}','{Lastname}',{Age},'{Email}','{Password1}')";

                        SqlCommand command = new(query, connection);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Registration Successful!!!\nYou are being directed to login page");

                        MainWindow.ReadDataFromDatabase();
                        NavigationService.Navigate(new LoginPageView());
                    }
                }

                else
                    MessageBox.Show("Incorrect Confirmation of password is detected!");
            }
        }
    }
}
