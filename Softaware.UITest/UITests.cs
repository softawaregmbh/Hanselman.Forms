using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace Softaware.UITest
{
    [TestFixture]
    public class UITests
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

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        //[Test]
        //public void Repl()
        //{
        //    // Invoke the REPL so that we can explore the user interface
        //    app.Repl();
        //}

        [Test]
        public void ClickThroughTest()
        {
            this.TestMenuItem("About");
            this.TestMenuItem("Blog");
            this.TestMenuItem("Twitter");
            this.TestMenuItem("Hanselminutes");
            this.TestMenuItem("Ratchet");
            this.TestMenuItem("Developers Life");

            //app.Tap(x => x.Marked("OK"));
            //app.Tap(x => x.Text("About"));

            //app.WaitForElement(x => x.Class("FormsImageView").Index(8));
            //app.WaitForElement(x => x.Text("My name is Scott Hanselman. I'm a programmer, teacher, and speaker. I work out of my home office in Portland, Oregon for the Web Platform Team at Microsoft, but this blog, its content and opinions are my own. I blog about technology, culture, gadgets, diversity, code, the web, where we're going and where we've been. I'm excited about community, social equity, media, entrepreneurship and above all, the open web."));

            //app.Screenshot("Tapped on view with class: FormsTextView");
        }

        private void TestMenuItem(string name)
        {
            app.WaitForElement(x => x.Marked("OK"));
            app.Tap(x => x.Marked("OK"));

            app.WaitForElement(x => x.Marked(name));
            app.Tap(x => x.Text(name));

            app.Screenshot(name);
        }

        [Test]
        public void ValidTweetFilter()
        {
            app.Tap(x => x.Marked("OK"));
            app.WaitForElement(x => x.Marked("Twitter"));
            app.Tap(x => x.Text("Twitter"));

            app.WaitForElement(x => x.Marked("search_bar"));
            app.ClearText(c => c.Marked("search_bar"));
            app.EnterText(c => c.Marked("search_bar"), ".NET");
            app.PressEnter();
            app.Screenshot("Valid tweet filter");

            //app.WaitFor(() =>
            //{
            //    return app.Query(x => x.Class("LisView").Child()).Length > 0;
            //});
            app.WaitForElement(x => x.Class("ListView").Index(0));
            app.Tap(x => x.Class("ListView").Index(0));
            app.Screenshot("Valid tweet filter - First Item Tap");
        }

        [Test]
        public void TweetFilterResultsInEmptyList()
        {
            app.Tap(x => x.Marked("OK"));
            app.WaitForElement(x => x.Marked("Twitter"));
            app.Tap(x => x.Text("Twitter"));

            app.WaitForElement(x => x.Marked("search_bar"));
            app.ClearText(x => x.Marked("search_bar"));
            app.EnterText(x => x.Marked("search_bar"), "asdfghjlk123456 stupd search");
            app.PressEnter();

            app.Screenshot("Empty Tweet List");

            // this should result in an error as no tweets match the search pattern
            app.WaitForElement(x => x.Class("ListView").Index(0));
        }
    }
}

