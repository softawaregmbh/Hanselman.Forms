using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hanselman.Portable.Manager
{
    public class MockFeedItemManager : IFeedManager<FeedItem>
    {
        public async Task<IEnumerable<FeedItem>> LoadItemsAsync(string search = null)
        {
            await Task.Delay(2000);

            var items = new[] {
                new FeedItem() { Description = "Tweet1" },
                new FeedItem() { Description = "Tweet2" },
                new FeedItem() { Description = "Tweet3" },
                new FeedItem() { Description = "Tweet4" },
            };

            if (!string.IsNullOrWhiteSpace(search))
            {
                items = items.Where(i => i.Description.Contains(search)).ToArray();
            }

            return items;
        }
    }
}
