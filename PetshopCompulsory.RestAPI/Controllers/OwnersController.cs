using Microsoft.AspNetCore.Mvc;
using PetshopCompulsory.Core.ApplicationService;
using PetshopCompulsory.Core.DomainService.Filtering;
using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetshopCompulsory.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        IOwnerService _ownerService;
        public OwnersController(IOwnerService ownerservice)
        {
            _ownerService = ownerservice;
        }
        [HttpGet]
        public ActionResult<List<Owner>> Get(Filter filter)
        {
            try
            {
                return Ok(_ownerService.ReadAllOwners(filter));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            return _ownerService.Create(owner);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Owner owner)
        {
            _ownerService.Update(id, owner);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ownerService.Delete(id);
        }

    }
}