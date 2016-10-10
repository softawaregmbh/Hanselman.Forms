using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hanselman.Portable.Manager
{
    public abstract class AbstractHttpManager : IFeedManager<FeedItem>
    {
        protected string url;

        public AbstractHttpManager(string url)
        {
            this.url = url;
        }

        public async Task<IEnumerable<FeedItem>> LoadItemsAsync(string search = null)
        {

            var httpClient = new HttpClient();
            var responseString = await httpClient.GetStringAsync(this.url);

            return await ParseFeed(responseString);
        }

        protected abstract Task<List<FeedItem>> ParseFeed(string content);
    }
}
