using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceAuthExample.AuthRules;

namespace ResourceAuthExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            //It's easier to apply resource based authorisation within the query if multiple resources are being requested 
            return new Item[0];
        }

        [HttpGet("{id}", Name = "Get")]
        [ItemOwner]
        public Item Get(int id)
        {
            Trace.WriteLine("Got");
            return new Item();
        }

        [HttpPost]
        [Authorize(Roles = "ItemCreator")]
        public void Post([FromBody]NewItem item)
        {
            Trace.WriteLine("Posted");
        }

        [HttpPut("{id}")]
        [ItemOwner]
        public void Put(int id, [FromBody]NewItem item)
        {
            Trace.WriteLine("Putted");
        }

        [HttpDelete("{id}")]
        [ItemOwner]
        public void Delete(int id)
        {
            Trace.WriteLine("Deleted");
        }
    }
}
