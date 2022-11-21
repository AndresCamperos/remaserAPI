using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using remaserAPI.Data.Entitys;
using System.Threading.Tasks;
using remaserAPI.Services.Interfaces;

namespace remaserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingsHttpServices _buildingsHttpServices;
        public BuildingController(IBuildingsHttpServices services)
        {
            _buildingsHttpServices = services;
                
        }
        // GET: api/Building
        [HttpGet]
        public async Task<ActionResult<Building>> Get()
        {
            try
            {                
                List<Building> buildings = await _buildingsHttpServices.GetAll();
                return Ok(buildings);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/Building/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                Building building = await _buildingsHttpServices.Get(id); 
                if (building == null)
                {
                    return NotFound();
                }
                return Ok(building);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/Building
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Building building)
        {
            try
            {
                //campos obligatorios
                await _buildingsHttpServices.Post(building);
                return Created("", building);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/Building/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Building building)
        {
            try
            {
                if(building.Id != id) { return BadRequest();}
                bool result = await _buildingsHttpServices.Exist(building.Id);
                if (result)
                {
                    await _buildingsHttpServices.Put(building);
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

        // DELETE api/Building/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Building building = await _buildingsHttpServices.Get(id);
                if(building != null)
                {
                    await _buildingsHttpServices.Delete(building); 
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
