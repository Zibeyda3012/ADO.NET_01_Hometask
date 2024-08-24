using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_01_Hometask.Models
{
    public class Person : INotifyPropertyChanged
    {

        private string? firstname;
        private string? lastname;
        private int age;
        private string? email;
        private string? password;


        public string? FirstName { get => firstname; set { firstname = value; OnPropertyChanged(); } }

        public string? LastName { get => lastname; set { lastname = value; OnPropertyChanged(); } }

        public int Age { get => age; set { age = value; OnPropertyChanged(); } }

        public string? Email { get => email; set { email = value; OnPropertyChanged(); } }

        public string? Password { get => password; set { password = value; OnPropertyChanged(); } }

        public Person()
        {

        }

        public Person(string? name, string? surname, int age, string? email, string? password)
        {
            FirstName = name;
            LastName = surname;
            Age = age;
            Email = email;
            Password = password;
        }


        //------------------------------------------------------------------------------------------------------

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
