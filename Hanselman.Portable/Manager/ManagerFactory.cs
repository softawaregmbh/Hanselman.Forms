namespace Hanselman.Portable.Manager
{
    public static class ManagerFactory
    {
        public static bool IsMocked { get; set; } = false;

        public static IFeedManager<Tweet> CreateTwitterManager(string consumerKey, string consumerSecret)
        {
            return IsMocked
                ? new MockTwitterManager() as IFeedManager<Tweet>
                : new TwitterManager(consumerKey, consumerSecret);
        }

        public static IFeedManager<FeedItem> CreateHttpFeedManager(string image, string url)
        {
            return IsMocked
                ? new MockFeedItemManager() as IFeedManager<FeedItem>
                : new PodcastManager(image, url);
        }

        public static IFeedManager<FeedItem> CreateBlogFeedManager(string url)
        {
            return IsMocked
                ? new MockFeedItemManager() as IFeedManager<FeedItem>
                : new BlogFeedManager(url);
        }
    }
}
