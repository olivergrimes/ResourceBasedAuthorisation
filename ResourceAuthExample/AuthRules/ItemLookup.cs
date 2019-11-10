using System.Threading.Tasks;

namespace ResourceAuthExample.AuthRules
{
    public class ItemLookup : IItemLookup
    {
        public Task<string> GetOwnerId(int itemId)
        {
            var ownerId = "1"; //Access from item store, e.g.: database table of items
            return Task.FromResult(ownerId);
        }
    }
}
