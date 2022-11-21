using remaserAPI.Data.Entitys;
using remaserAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace remaserAPI.Data.Repositories
{
    public class BuildingRepository : IBuildingsHttpServices
    {
        private readonly RemaserDBContext _context;
        public BuildingRepository(RemaserDBContext context)
        {
            _context = context;
        }
        public async Task Delete(Building building)
        {
            try
            {
                _context.Buildings.Remove(building);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Building> Get(int id)
        {
            try
            {
                return await _context.Buildings.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Building>> GetAll()
        {
            try
            {
                return await _context.Buildings.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Exist(int id)
        {
            try
            {
                bool result = await _context.Buildings.AnyAsync(b => b.Id == id);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Post(Building building)
        {
            try
            {
                building.Id = default;
                building.Name = building.Name.ToUpper();                
                _context.Add(building);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Put(Building building)
        {
            try
            {
                building.Name = building.Name.ToUpper();
                _context.Add(building);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
