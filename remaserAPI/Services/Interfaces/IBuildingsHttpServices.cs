using remaserAPI.Data.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace remaserAPI.Services.Interfaces
{
    public interface IBuildingsHttpServices
    {
        Task<List<Building>> GetAll();
        Task<Building> Get(int id);
        Task<bool> Exist(int id);
        Task Post(Building person);
        Task Put(Building person);
        Task Delete(Building person);
    }
}
