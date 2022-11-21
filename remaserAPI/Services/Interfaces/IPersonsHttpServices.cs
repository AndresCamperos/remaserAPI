using remaserAPI.Data.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace remaserAPI.Services.Interfaces
{
    public interface IPersonsHttpServices
    {
        Task<List<Person>> GetAll();
        Task<Person> Get(int id);
        Task<bool> Exist(int id);
        Task Post(Person person);
        Task Put(Person person);
        Task Delete(Person person);
    }
}
