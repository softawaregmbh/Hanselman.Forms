
using System;
using Xamarin.Forms;

namespace Hanselman.Portable.Views
{
    public partial class LoginPage : ContentPage
    {
        private RootPage root;
        public bool IsAuthenticated { get; private set; } = false;

        public LoginPage(RootPage root)
        {
            this.root = root;
            InitializeComponent();

            if (!App.IsWindows10)
            {
                BackgroundColor = Color.FromHex("#03A9F4");
            }

            BindingContext = new BaseViewModel
            {
                Title = "Hanselman.Forms",
                Subtitle = "Hanselman.Forms",
            };
        }

        public async void loginButton_Clicked(object sender, EventArgs e)
        {
            if (App.Authenticator != null)
                this.IsAuthenticated = await App.Authenticator.Authenticate();

            if (this.IsAuthenticated)
            {

            }
        }
    }
}

