
using System;
using Hanselman.Portable.Auth;
using Xamarin.Forms;

namespace Hanselman.Portable.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly ILoginManager loginManager;

        public LoginPage(ILoginManager loginManager)
        {
            InitializeComponent();

            this.loginManager = loginManager;

            BindingContext = new BaseViewModel
            {
                Title = "Hanselman.Forms",
                Subtitle = "Hanselman.Forms",
            };
        }

        public async void loginButton_Clicked(object sender, EventArgs e)
        {
            // See App.OnResume to see what happens after login
            await App.Authenticator.Authenticate();
        }
    }
}

