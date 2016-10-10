using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Hanselman.Portable.Manager;
using Xamarin.Forms;

namespace Hanselman.Portable
{
    public class TwitterViewModel : BaseViewModel
    {
        private IFeedManager<Tweet> twitterManger;
        public ObservableCollection<Tweet> Tweets { get; set; }

        public TwitterViewModel()
        {
            Title = "Twitter";
            Icon = "slideout.png";
            Tweets = new ObservableCollection<Tweet>();

            this.twitterManger = ManagerFactory.CreateTwitterManager(
                "ZTmEODUCChOhLXO4lnUCEbH2I",
                "Y8z2Wouc5ckFb1a0wjUDT9KAI6DUat5tFNdmIkPLl8T4Nyaa2J");
        }

        private Command loadTweetsCommand;

        public Command LoadTweetsCommand
        {
            get
            {
                return loadTweetsCommand ??
                  (loadTweetsCommand = new Command(async () =>
                  {
                      await ExecuteLoadTweetsCommand();
                  }, () =>
                  {
                      return !IsBusy;
                  }));
            }
        }

        public async Task ExecuteLoadTweetsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            LoadTweetsCommand.ChangeCanExecute();
            var error = false;
            try
            {
                var tweets = await this.twitterManger.LoadItemsAsync(this.Search);

                Tweets.Clear();
                foreach (var tweet in tweets)
                {
                    Tweets.Add(tweet);
                }

                if (Device.OS == TargetPlatform.iOS)
                {
                    // only does anything on iOS, for the Watch
                    DependencyService.Get<ITweetStore>().Save(tweets.ToList());
                }
            }
            catch
            {
                error = true;
            }

            if (error)
            {
                var page = new ContentPage();
                await page.DisplayAlert("Error", "Unable to load tweets.", "OK");
            }

            IsBusy = false;
            LoadTweetsCommand.ChangeCanExecute();
        }
    }
}

