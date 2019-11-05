using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetshopCompulsory.Core.ApplicationService;
using PetshopCompulsory.Core.DomainService.Filtering;
using PetshopCompulsory.Core.Entity;

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
        [Authorize]
        [HttpGet]
        public ActionResult<FilteredList<Owner>> Get(Filter filter)
        {
            try
            {
                return Ok(_ownerService.ReadAllOwners(filter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerService.ReadOwnerById(id);
        }

        [HttpPost]
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