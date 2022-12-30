using System.Threading.Tasks;
using remaserAPI.Data.Entitys;

namespace remaserAPI.Services.Interfaces
{
    public interface IUsersHttpServices
    {
        Task Post(User user);
    }
}
