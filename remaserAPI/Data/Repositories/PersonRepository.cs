using remaserAPI.Data.Entitys;
using remaserAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace remaserAPI.Data.Repositories
{
    public class PersonRepository : IPersonsHttpServices
    {
        private readonly RemaserDBContext _context;
        public PersonRepository(RemaserDBContext context)
        {
            _context = context;
        }
        public async Task<List<Person>> GetAll()
        {
            try
            {
                return await _context.Persons.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Person> Get(int id)
        {
            try
            {
                return await _context.Persons.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        public async Task Post(Person person)
        {
            try
            {
                person.Id = default;
                person.Name = person.Name.ToUpper();
                person.LastName = person.LastName.ToUpper();
                _context.Add(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Put(Person person)
        {
            try
            {
                person.Name = person.Name.ToUpper();
                person.LastName = person.LastName.ToUpper();
                _context.Entry(person).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                _context.Remove(id);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> isValid(int id)
        {
            try
            {
                bool result = await _context.Persons.AnyAsync( p => p.Id == id);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
