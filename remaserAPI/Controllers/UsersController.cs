using Microsoft.AspNetCore.Mvc;
using remaserAPI.Data.Entitys;
using remaserAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace remaserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersHttpServices _usersHttp
;
        public UsersController(IUsersHttpServices usersHttpServices)
        {
            _usersHttp = usersHttpServices;
        }
        // GET: api/<UsersController>
        //[HttpGet]
        //public async Task<User><string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UsersController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                await _usersHttp.Post(user);
                return Created("", user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //// PUT api/<UsersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UsersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
