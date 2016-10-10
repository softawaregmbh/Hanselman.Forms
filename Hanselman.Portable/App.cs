using Hanselman.Portable.Views;
using Xamarin.Forms;

namespace Hanselman.Portable
{
    public class App : Application
    {
        public static bool IsWindows10 { get; set; }
        public App()
        {
            // The root page of your application
            MainPage = new RootPage();
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
