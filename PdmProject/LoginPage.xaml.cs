using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PdmProject
{
    public partial class LoginPage : ContentPage
    {
        private UserDb UserDB;

        private RegisterPage registerPage;

        private string Username;
        private string Password;

        public LoginPage()
        {
            InitializeComponent();
            Title = "Login";
            registerPage = new RegisterPage();
            UserDB = new UserDb();
            registerPage.CreateUserSucceeded += RegisterPage_CreateUserSucceeded;
            UsernameEntry.TextChanged += UsernameEntry_TextChanged;
            PasswordEntry.TextChanged += PasswordEntry_TextChanged;
            LoginButton.Clicked += LoginButton_Clicked;
            RegisterButton.Clicked += RegisterButton_Clicked;

        }

        private void RegisterPage_CreateUserSucceeded(object sender, EventArgs e)
        {
            DisplayAlert("Success", "User has been created.", "Ok");
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(registerPage);
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (UserDB.checkCredentials(Username, Password))
            {
                UserManager.init(UserDB.getUser(Username, Password));
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("Error", "Incorrect credentials.", "Close");
            }
        }

        private void PasswordEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password = ((Entry)sender).Text;
        }

        private void UsernameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Username = ((Entry)sender).Text;
        }
    }
}
