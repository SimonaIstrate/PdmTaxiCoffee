using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PdmProject
{
    public partial class RegisterPage : ContentPage
    { 
        private string Username;
        private string Password;
        private string Nume;
        private string Prenume;
        private string Email;

        public event EventHandler CreateUserSucceeded;

        private UserDb userDB;

        public RegisterPage()
        {
            InitializeComponent();
            UsernameEntry.TextChanged += UsernameEntry_TextChanged;
            PasswordEntry.TextChanged += PasswordEntry_TextChanged;
            NumeEntry.TextChanged += NumeEntry_TextChanged;
            PrenumeEntry.TextChanged += PrenumeEntry_TextChanged;
            EmailEntry.TextChanged += EmailEntry_TextChanged;
            RegisterButton.Clicked += RegisterButton_Clicked;

            userDB = new UserDb();
        }

        private void EmailEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Email = ((Entry)sender).Text;
        }

        private void PrenumeEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Prenume = ((Entry)sender).Text;
        }

        private void NumeEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Nume = ((Entry)sender).Text;
        }

        private void PasswordEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password = ((Entry)sender).Text;
        }

        private void UsernameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Username = ((Entry)sender).Text;
        }

        private void resetFields()
        {
            UsernameEntry.Text = "";
            PasswordEntry.Text = "";
            NumeEntry.Text = "";
            PrenumeEntry.Text = "";
            EmailEntry.Text = "";
        }

        private bool validateFields()
        {
            if (Username == null || Username == "")
            {
                DisplayAlert("Error", "Please insert username!", "Ok");
                return false;
            }
            if (Password == null || Password == "")
            {
                DisplayAlert("Error", "Please insert password!", "Ok");
                return false;
            }
            if (Nume == null || Nume == "")
            {
                DisplayAlert("Error", "Please insert nume!", "Ok");
                return false;
            }
            if (Prenume == null || Prenume == "")
            {
                DisplayAlert("Error", "Please insert prenume!", "Ok");
                return false;
            }
            if (Email == null || Email == "")
            {
                DisplayAlert("Error", "Please insert email!", "Ok");
                return false;
            }
            return true;
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            if (validateFields())
            {
                User user = new User(Username, Password, Nume, Prenume, Email);
                if (userDB.insert(user) > 0)
                {
                    if (CreateUserSucceeded != null)
                    {
                        resetFields();
                        CreateUserSucceeded(this, EventArgs.Empty);
                        Navigation.RemovePage(this);
                        return;
                    }
                }
                DisplayAlert("Eroare", "A aparut o eroare, incerca din nou.", "Close");
            }
        }
    }
}
