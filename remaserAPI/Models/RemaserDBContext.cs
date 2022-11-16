using Microsoft.EntityFrameworkCore;
using RemaserAPI.Models;

namespace remaserAPI.Models
{
    public class RemaserDBContext: DbContext
    {
        public RemaserDBContext(DbContextOptions<RemaserDBContext> context)
            : base(context)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
