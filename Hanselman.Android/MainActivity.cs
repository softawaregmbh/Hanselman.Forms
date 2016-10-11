
using Android.App;
using Android.Content.PM;
using Android.OS;
using Hanselman.Portable;
using HockeyApp.Android;
using HockeyApp.Android.Metrics;
using ImageCircle.Forms.Plugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace HanselmanAndroid
{
    [Activity(Label = "Hanselman",
        MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;
            base.OnCreate(bundle);
            Forms.Init(this, bundle);
            ImageCircleRenderer.Init();
            LoadApplication(new App());

            CrashManager.Register(this);
            MetricsManager.Register(this, Application, "d96e2939acc74783a114d8adf1741f91");
        }
    }
}
