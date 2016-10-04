using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace Softaware.UITest
{
    [TestFixture]
    public class Tests
    {
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the Android app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            app = ConfigureApp
                .Android
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                //.ApkFile ("../../../Android/bin/Debug/UITestsAndroid.apk")
                .StartApp();
        }

        //[Test]
        //public void AppLaunches()
        //{
        //    app.Screenshot("First screen.");
        //}

        [Test]
        public void Repl()
        {
            // Invoke the REPL so that we can explore the user interface
            app.Repl();
        }
        
        [Test]
        public void ClickThroughTest()
        {
            app.Tap(x => x.Marked("OK"));
            app.Tap(x => x.Text("About"));
            app.Tap(x => x.Marked("OK"));
            app.Tap(x => x.Text("Twitter"));
            app.Back();
            app.Tap(x => x.Marked("OK"));
            app.Tap(x => x.Text("Hanselminutes"));
            app.Tap(x => x.Marked("OK"));
            app.Tap(x => x.Text("About"));
            app.WaitForElement(x => x.Class("FormsImageView").Index(8));
            app.WaitForElement(x => x.Text("My name is Scott Hanselman. I'm a programmer, teacher, and speaker. I work out of my home office in Portland, Oregon for the Web Platform Team at Microsoft, but this blog, its content and opinions are my own. I blog about technology, culture, gadgets, diversity, code, the web, where we're going and where we've been. I'm excited about community, social equity, media, entrepreneurship and above all, the open web."));
            app.Screenshot("Tapped on view with class: FormsTextView");
        }


    }
}

