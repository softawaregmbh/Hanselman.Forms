using System.Linq;
using System.Threading.Tasks;
using Hanselman.Portable;
using Hanselman.Portable.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Softaware.Test
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public async Task LoadTweets()
        {
            var viewModel = new TwitterViewModel();
            var task = viewModel.ExecuteLoadTweetsCommand();

            await CheckIfBusy(task, viewModel);

            Assert.IsTrue(viewModel.Tweets.Any());
        }

        [TestMethod]
        public async Task FilterTweets()
        {
            var search = "shanselman";
            var viewModel = new TwitterViewModel
            {
                Search = search
            };

            var task = viewModel.ExecuteLoadTweetsCommand();

            await CheckIfBusy(task, viewModel);

            Assert.IsTrue(viewModel.Tweets.Any(t => !t.Text.Contains(search)));
        }

        [TestMethod]
        public async Task LoadPodcastHanselminutes()
        {
            var viewModel = new PodcastViewModel(MenuType.Hanselminutes);
            var task = viewModel.ExecuteLoadItemsCommand();

            await CheckIfBusy(task, viewModel);

            Assert.IsTrue(viewModel.FeedItems.Any());
        }

        [TestMethod]
        public async Task LoadPodcastRatchet()
        {
            var viewModel = new PodcastViewModel(MenuType.Ratchet);
            var task = viewModel.ExecuteLoadItemsCommand();

            await CheckIfBusy(task, viewModel);

            Assert.IsTrue(viewModel.FeedItems.Any());
        }

        [TestMethod]
        public async Task LoadDevelopersLife()
        {
            var viewModel = new PodcastViewModel(MenuType.DeveloperLife);
            var task = viewModel.ExecuteLoadItemsCommand();

            await CheckIfBusy(task, viewModel);

            Assert.IsTrue(viewModel.FeedItems.Any());
        }

        [TestMethod]
        public async Task LoadBlog()
        {
            var viewModel = new BlogFeedViewModel();
            var task = viewModel.ExecuteLoadItemsCommand();

            await CheckIfBusy(task, viewModel);

            Assert.IsTrue(viewModel.FeedItems.Any());
        }

        private async Task CheckIfBusy(Task task, BaseViewModel model)
        {
            Assert.IsTrue(model.IsBusy);
            Assert.IsFalse(model.IsNotBusy);

            await task;

            Assert.IsFalse(model.IsBusy);
            Assert.IsTrue(model.IsNotBusy);
        }
    }
}
