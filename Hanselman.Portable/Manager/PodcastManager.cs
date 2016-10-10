using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hanselman.Portable.Manager
{
    public class PodcastManager : AbstractHttpManager
    {
        private string image;

        public PodcastManager(string image, string url) : base(url)
        {
            this.image = image;
        }

        /// <summary>
        /// Parse the RSS Feed
        /// </summary>
        /// <param name="rss"></param>
        /// <returns></returns>
        protected override async Task<List<FeedItem>> ParseFeed(string rss)
        {
            return await Task.Run(() =>
            {
                var xdoc = XDocument.Parse(rss);
                var id = 0;

                return (from item in xdoc.Descendants("item")
                        let enclosure = item.Element("enclosure")
                        where enclosure != null
                        select new FeedItem
                        {
                            Title = (string)item.Element("title"),
                            Description = (string)item.Element("description"),
                            Link = (string)item.Element("link"),
                            PublishDate = (string)item.Element("pubDate"),
                            Category = (string)item.Element("category"),
                            Mp3Url = (string)enclosure.Attribute("url"),
                            Image = this.image,
                            Id = id++
                        }).ToList();
            });
        }
    }
}
