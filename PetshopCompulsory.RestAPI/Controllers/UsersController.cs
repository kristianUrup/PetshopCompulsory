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
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET api/users?searchType=x&value=y
        [Authorize]
        [HttpGet]
        public ActionResult<FilteredList<User>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_userService.ReadAllUsers(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
        
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _userService.ReadById(id);
        }

        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userService.Create(user);
        }

        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User updatedUser)
        {

            if (id == updatedUser.Id && id < 1) 
            {
                return BadRequest("Id and id doesnt match");
            }
            else
            {
                return Ok(_userService.Update(updatedUser));
            }
        }
    }
}