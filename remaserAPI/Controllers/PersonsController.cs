using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using remaserAPI.Data.Entitys;
using remaserAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace remaserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsHttpServices _personHttpService;
        public PersonsController(IPersonsHttpServices services)
        {
            _personHttpService = services;
        }
        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                List<Person> persons = await _personHttpService.GetAll();               
                
                return Ok(persons);

            }
            catch (Exception)
            {

                throw;
            }
	
        }

        // GET api/<Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                Person person = await _personHttpService.Get(id);
                if(person == null)
                {
                    return NotFound();
                }
                return Ok(person);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //POST api/<PersonController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            try
            {
                await _personHttpService.Post(person);
                return Created("", person);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/Person/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Person person)
        {
            try
            {
                if(person.Id != id) { return BadRequest(); }

                bool result = await _personHttpService.Exist(id);

                if (result)
                {
                    await _personHttpService.Put(person);
                }
                else
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/Person/5
        [HttpDelete("{id}")]
        public async Task<ActionResult>  Delete(int id)
        {
            try
            {
                Person person = await _personHttpService.Get(id);

                if (person != null)
                {
                    await _personHttpService.Delete(person);
                }
                else
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
