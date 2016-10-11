
using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Hanselman.Portable;
using Hanselman.Portable.Auth;
using HockeyApp.Android;
using HockeyApp.Android.Metrics;
using ImageCircle.Forms.Plugin.Droid;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace HanselmanAndroid
{
    [Activity(Label = "Hanselman",
        MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity, IAuthenticate
    {
        // Define a authenticated user.
        private MobileServiceUser user;

        protected override void OnCreate(Bundle bundle)
        {
            // Set the current instance of MainActivity.
            instance = this;

            ToolbarResource = Resource.Layout.toolbar;
            TabLayoutResource = Resource.Layout.tabs;
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            ImageCircleRenderer.Init();
            App.Init(this);

            LoadApplication(new App());


            // Notification which does not work at the moment
            //try
            //{
            //    // Check to ensure everything's setup right
            //    GcmClient.CheckDevice(this);
            //    GcmClient.CheckManifest(this);

            //    // Register for push notifications
            //    System.Diagnostics.Debug.WriteLine("Registering...");
            //    GcmClient.Register(this, PushHandlerBroadcastReceiver.SENDER_IDS);
            //}
            //catch (Java.Net.MalformedURLException)
            //{
            //    CreateAndShowDialog("There was an error creating the client. Verify the URL.", "Error");
            //}
            //catch (Exception e)
            //{
            //    CreateAndShowDialog(e.Message, "Error");
            //}
        }

        private void CreateAndShowDialog(String message, String title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }

        public async Task<bool> Authenticate()
        {
            var success = false;
            var message = string.Empty;
            try
            {
                // Sign in with Facebook login using a server-managed flow.
                user = await ServiceClientManager.Instance.Client.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook);

                if (user != null)
                {
                    message = string.Format("you are now signed-in as {0}.",
                        user.UserId);
                    success = true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            // Display the success or failure message.
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle("Sign-in result");
            builder.Create().Show();

            return success;
        }

        // Create a new instance field for this activity.
        static MainActivity instance = null;

        // Return the current activity instance.
        public static MainActivity CurrentActivity
        {
            get
            {
                return instance;
            }
        }
    }
}
