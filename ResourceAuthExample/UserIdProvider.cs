using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ResourceAuthExample
{
    public class UserIdProvider : IUserIdProvider
    {
        public Task<string> GetId(HttpContext context)
        {
            var userId = "1"; //Access from context.User, e.g.: context.User?.FindFirst("sub")?.Value;
            return Task.FromResult(userId);
        }
    }
}
