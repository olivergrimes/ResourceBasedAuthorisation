using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace ResourceAuth
{
    public interface IAuthorisationRule : IFilterMetadata
    {
        Task<bool> HasAccess(ActionExecutingContext context);
    }
}
