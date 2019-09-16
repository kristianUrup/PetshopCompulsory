using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetshopCompulsory.Core.ApplicationService;
using PetshopCompulsory.Core.Entity;

namespace PetshopCompulsory.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        IOwnerService ownerService;
        public OwnersController(IOwnerService ownerservice)
        {
            ownerService = ownerservice;
        }
        public void Post([FromBody] Owner owner)
        {
            ownerService.Create(owner);
        }
        public ActionResult<List<Owner>> Get()
        {
            return ownerService.ReadAllOwners();
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Owner owner)
        {
            ownerService.Update(id, owner);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ownerService.Delete(id);
        }

    }
}