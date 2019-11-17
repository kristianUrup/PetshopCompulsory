using PetshopCompulsory.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using PetshopCompulsory.Core.ApplicationService;
using PetshopCompulsory.Core.DomainService.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace PetshopCompulsory.RestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {

        private readonly IPetService _petService;
        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/pets?searchType=x&value=y
        [Authorize]
        [HttpGet]
        public ActionResult<FilteredList<Pet>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_petService.GetPets(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            //switch (searchType)
            //{
            //    case "cheapestPets":
            //        return _petService.FiveCheapestPets(Convert.ToInt32(value));
            //        break;
            //    case "TypeSearch":
            //        return _petService.SearchForType(value);
            //        break;
            //    default:
            //        return null;
            //    break;
            //}


        }

        // GET api/values/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.GetPet(id);
        }

        //GET api/values/name
        //[HttpGet("{id}")]
        //public List<Pet> Get(int id, string name)
        //{
        //    List<Pet> pets = new List<Pet>();
        //    foreach (var pet in _petService.GetPets())
        //    {
        //        if(pet.Name.Equals(name))
        //        {
        //            pets.Add(pet);
        //        }
        //    }
        //    return pets;

        //}

        // POST api/values
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                return Ok(_petService.Create(pet));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet updatedPet)
        {
            try
            {
                return Ok(_petService.Update(id, updatedPet));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Pet petToDelete = _petService.GetPet(id);
            if (petToDelete != null)
            {
                _petService.Delete(id);
            }

        }

    }
}