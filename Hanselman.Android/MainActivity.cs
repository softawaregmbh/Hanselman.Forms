
using Android.App;
using Android.Content.PM;
using Android.OS;
using Hanselman.Portable;
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


        }
    }
}
