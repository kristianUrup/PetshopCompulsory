﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetshopCompulsory.Core.ApplicationService;

namespace PetshopCompulsory.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {

        private readonly IPetService _petService;
        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<Pet>> Get()
        {
            return _petService.GetPets();
        }

        // GET api/values/5
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
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                return Ok( _petService.Create(pet));
            } catch(Exception e)
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
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Pet petToDelete = _petService.GetPet(id);
            if(petToDelete != null)
            {
                _petService.Delete(id);
            }

        }

    }
}