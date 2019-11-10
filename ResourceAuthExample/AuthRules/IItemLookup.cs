using System.Threading.Tasks;

namespace ResourceAuthExample.AuthRules
{
    public interface IItemLookup
    {
        Task<string> GetOwnerId(int itemId);
    }
}
