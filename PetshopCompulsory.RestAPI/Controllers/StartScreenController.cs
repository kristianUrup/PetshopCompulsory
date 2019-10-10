using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetshopCompulsory.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StartScreenController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Type 1 for getting pets", "Type 2 for getting owners" };
        }

        [HttpPost]
        public void Post([FromBody] int choice)
        {
            //switch (choice)
            //{
            //    case 1:
                    
            //}
        }
    }
}