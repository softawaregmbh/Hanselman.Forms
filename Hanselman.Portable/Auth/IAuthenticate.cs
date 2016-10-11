using System.Threading.Tasks;

namespace Hanselman.Portable.Auth
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate();

        bool IsAuthenticated { get; }
    }

}
