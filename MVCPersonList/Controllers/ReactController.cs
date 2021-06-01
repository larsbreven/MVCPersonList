using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCPersonList.Models.Data;
using MVCPersonList.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public ReactController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [EnableCors("ReactPolicy")]

        [HttpGet]
        public List<Person> Get()
        {
            //Response.StatusCode = 418;//Im a Tea Pot
            return _peopleService.All().PersonList;         // Take out the PersonList itself
        }




    }
}
