using Microsoft.EntityFrameworkCore;
using remaserAPI.Data.Entitys;

namespace remaserAPI.Data
{
    public class RemaserDBContext : DbContext
    {
        public RemaserDBContext(DbContextOptions<RemaserDBContext> context)
            : base(context)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Building> Buildings { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
