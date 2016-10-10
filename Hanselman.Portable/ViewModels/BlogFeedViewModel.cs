using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Hanselman.Portable.Manager;
using Xamarin.Forms;

namespace Hanselman.Portable
{
    public class BlogFeedViewModel : BaseViewModel
    {
        private IFeedManager<FeedItem> feedManager;

        public BlogFeedViewModel()
        {
            Title = "Blog";
            Icon = "blog.png";

            this.feedManager = ManagerFactory.CreateBlogFeedManager("http://feeds.hanselman.com/ScottHanselman");
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
                foreach (var item in items)
                {
                    FeedItems.Add(item);
                }
            }
            catch
            {
                error = true;
            }

            if (error)
            {
                var page = new ContentPage();
                await page.DisplayAlert("Error", "Unable to load blog.", "OK");

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

