using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceAuth
{
    public class ResourceAuthorisationFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var filters = context
                    .Filters
                    .OfType<IAuthorisationRule>()
                    .Select(f => f.HasAccess(context));

            var hasAccess = await Task.WhenAll(filters);

            if (!hasAccess.All(a => a))
            {
                //At least one filter.HasAccess returned false
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
