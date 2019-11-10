using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ResourceAuthExample
{
    public interface IUserIdProvider
    {
        Task<string> GetId(HttpContext context);
    }
}
