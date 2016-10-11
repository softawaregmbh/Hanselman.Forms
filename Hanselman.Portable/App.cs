using System.Threading.Tasks;
using Hanselman.Portable.Views;
using Xamarin.Forms;

namespace Hanselman.Portable
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate();
    }

    public class App : Application
    {
        public static bool IsWindows10 { get; set; }
        public App()
        {
            // The root page of your application
            MainPage = new RootPage();
        }

        public static IAuthenticate Authenticator { get; private set; }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
