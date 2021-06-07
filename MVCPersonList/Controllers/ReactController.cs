using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCPersonList.Models.Data;
using MVCPersonList.Models.Service;
using MVCPersonList.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Controllers
{
    [EnableCors("ReactPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public ReactController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public List<Person> Get()
        {
            //Response.StatusCode = 418;//Im a Tea Pot
            return _peopleService.All().PersonList;         // Take out the PersonList itself
        }

        [HttpGet("{id}")]                   // If there is an id included, this method will be executed, not the above                        
        public Person GetById(int id)
        {
            Person person = _peopleService.FindById(id);
                        
            return person;
        }

        [HttpPost]                                           
        public ActionResult<Person> Create([FromBody]CreatePerson person)
        {
            // ModelStae.isValid
            if (ModelState.IsValid)
            {
                return _peopleService.Add(person);

            }

            return BadRequest(person);
        }

        [HttpDelete("{id}")]                   // Delete request                        
        public void Delete(int id)
        {
            if (_peopleService.Remove(id))
            {
                Response.StatusCode = 200;
            }
            else
            {
                Response.StatusCode = 400;
            }
        }
    }
}
