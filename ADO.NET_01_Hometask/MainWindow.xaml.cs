using ADO.NET_01_Hometask.Models;
using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADO.NET_01_Hometask
{
    public partial class MainWindow : NavigationWindow
    {
        public static List<Person> Users { get; set; } = [];
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ReadDataFromDatabase();
        }

        public static void ReadDataFromDatabase()
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=UsersDB;Integrated Security=SSPI;";

            SqlCommand command = null;

            SqlDataReader reader = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command = new SqlCommand(@"SELECT * FROM Users", connection);
                connection.Open();

                reader = command.ExecuteReader();

                Users = new();

                while (reader.Read())
                {
                    Users.Add(new Person
                    {
                        FirstName = reader[1].ToString(),
                        LastName = reader[2].ToString(),
                        Age = Convert.ToInt32(reader[3].ToString()),
                        Email = reader[4].ToString(),
                        Password = reader[5].ToString(),
                    });
                }



            }
        }
    }
}