using remaserAPI.Data.Entitys;
using remaserAPI.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Security.Cryptography;
using remaserAPI.Services;

namespace remaserAPI.Data.Repositories
{
    public class UserRepository : IUsersHttpServices
    {
        private readonly RemaserDBContext _Context;
        public UserRepository(RemaserDBContext context)
        {
            _Context = context;
        }

        public async Task Post(User user)
        {
            try
            {
                EncryptServices encrypt = new();
                user.Id = default;
                user.Password = encrypt.EncrypterPassword(user.Password);
                user.CreationDate = DateTime.Now;
                _Context.Add(user);
                await _Context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
