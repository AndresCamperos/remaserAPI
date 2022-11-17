using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using remaserAPI.Data.Entitys;
using remaserAPI.Services.Interfaces;

namespace remaserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonsHttpServices _HttpService;
        public PersonController(IPersonsHttpServices services)
        {
            _HttpService = services;
        }
        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<Person>> Get()
        {
            try
            {
                List<Person> persons = await _HttpService.GetAll();               
                
                return Ok(persons);

            }
            catch (Exception)
            {

                throw;
            }
	
        }

        // GET api/<Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            try
            {
                Person person = await _HttpService.Get(id);
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
                await _HttpService.Post(person);
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

                bool result = await _HttpService.isValid(id);

                if (result)
                {
                    await _HttpService.Put(person);
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
                await _HttpService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
