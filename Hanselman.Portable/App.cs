using Hanselman.Portable.Auth;
using Hanselman.Portable.Views;
using Xamarin.Forms;

namespace Hanselman.Portable
{
    public class App : Application, ILoginManager
    {
        public static bool IsWindows10 { get; set; }
        public App()
        {
            // The root page of your application
            MainPage = new LoginPage(this);
        }

        public static IAuthenticate Authenticator { get; private set; }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }

        protected override void OnResume()
        {
            if (Authenticator.IsAuthenticated)
            {
                this.ShowMainPage();
            }
            else
            {
                this.ShowLogin();
            }
        }

        public void ShowMainPage()
        {
            MainPage = new RootPage();
        }

        public void ShowLogin()
        {
            MainPage = new LoginPage(this);
        }
    }
}
