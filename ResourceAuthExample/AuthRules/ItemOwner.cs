using Microsoft.AspNetCore.Mvc.Filters;
using ResourceAuth;
using System;
using System.Threading.Tasks;

namespace ResourceAuthExample.AuthRules
{
public class ItemOwnerAttribute : Attribute, IAuthorisationRule
{
    private readonly string _idArgumentName;

    public ItemOwnerAttribute(string idArgumentName = "id")
    {
        _idArgumentName = idArgumentName;
    }

    public async Task<bool> HasAccess(ActionExecutingContext context)
    {
        var requestServices = context.HttpContext
            .RequestServices;

        var itemLookup = requestServices.GetService<IItemLookup>();
        var userIdProvider = requestServices.GetService<IUserIdProvider>();

        //Find the relevant item id from the request
        if (context.ActionArguments.TryGetValue(_idArgumentName, out var argument) &&
            argument is int id)
        {
            var userId = await userIdProvider.GetId(context.HttpContext);
            var itemOwnerId = await itemLookup.GetOwnerId(id);

            return userId == itemOwnerId;
        }

        return false;
    }
}
}
