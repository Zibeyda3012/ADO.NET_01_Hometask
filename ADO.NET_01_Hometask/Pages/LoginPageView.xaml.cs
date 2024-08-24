using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public partial class LoginPageView : Page,INotifyPropertyChanged
    {
        public LoginPageView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string? _password;
        private string? _email;

        public string? email { get => _email; set { _email = value; OnPropertyChanged(); } }

        public string? password { get => _password; set { _password = value; OnPropertyChanged(); } }

        private void SignUp_btn_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new SignUpPageView());
        }

        private void SignIn_btn_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var CurrentUser = MainWindow.Users.FirstOrDefault(x => x.Email == email);

            if (CurrentUser is not null)
            {
                if (CurrentUser.Password == password)
                {
                    MessageBox.Show($"Welcome {CurrentUser.FirstName} {CurrentUser.LastName}!");
                    email = "";
                    password = "";
                }
                else
                {
                    MessageBox.Show("Incorrect Password,try again");
                    password = "";
                }

            }

            else
            {
                MessageBox.Show("User NOT FOUND!!!");
                email = "";
                password = "";
            }
        }
    }
}
