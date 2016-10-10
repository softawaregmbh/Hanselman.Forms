using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hanselman.Portable.Manager
{
    public interface IFeedManager<T>
    {
        Task<IEnumerable<T>> LoadItemsAsync(string search = null);
    }
}
