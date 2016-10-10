using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Hanselman.Portable.Manager;
using Xamarin.Forms;

namespace Hanselman.Portable.ViewModels
{
    public class PodcastViewModel : BaseViewModel
    {
        MenuType item;

        private IFeedManager<FeedItem> feedManager;

        public PodcastViewModel(MenuType item)
        {
            this.item = item;
            var image = string.Empty;
            var url = string.Empty;

            switch (item)
            {
                case MenuType.Hanselminutes:
                    image = "hm_full.jpg";
                    url = "http://feeds.podtrac.com/9dPm65vdpLL1";
                    Title = "Hanselminutes";
                    break;
                case MenuType.Ratchet:
                    image = "ratchet_full.jpg";
                    url = "http://feeds.feedburner.com/RatchetAndTheGeek?format=xml";
                    Title = "Ratchet & The Geek";
                    break;
                case MenuType.DeveloperLife:
                    image = "tdl_full.jpg";
                    url = "http://feeds.feedburner.com/ThisDevelopersLife?format=xml";
                    Title = "This Developer Life";
                    break;
            }

            this.feedManager = ManagerFactory.CreateHttpFeedManager(image, url);
        }


        private ObservableCollection<FeedItem> feedItems = new ObservableCollection<FeedItem>();

        /// <summary>
        /// gets or sets the feed items
        /// </summary>
        public ObservableCollection<FeedItem> FeedItems
        {
            get { return feedItems; }
            set { feedItems = value; OnPropertyChanged(); }
        }

        private FeedItem selectedFeedItem;
        /// <summary>
        /// Gets or sets the selected feed item
        /// </summary>
        public FeedItem SelectedFeedItem
        {
            get { return selectedFeedItem; }
            set
            {
                selectedFeedItem = value;
                OnPropertyChanged();
            }
        }

        private Command loadItemsCommand;
        /// <summary>
        /// Command to load/refresh items
        /// </summary>
        public Command LoadItemsCommand
        {
            get { return loadItemsCommand ?? (loadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand())); }
        }

        public async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            var error = false;
            try
            {
                FeedItems.Clear();

                var items = await this.feedManager.LoadItemsAsync();
                foreach (var feedItem in items)
                {
                    FeedItems.Add(feedItem);
                }
            }
            catch
            {
                error = true;
            }

            if (error)
            {
                var page = new ContentPage();
                var result = page.DisplayAlert("Error", "Unable to load podcast feed.", "OK");

            }


            IsBusy = false;
        }


        /// <summary>
        /// Gets a specific feed item for an Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FeedItem GetFeedItem(int id)
        {
            return FeedItems.FirstOrDefault(i => i.Id == id);
        }
    }
}
