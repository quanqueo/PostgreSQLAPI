using Microsoft.EntityFrameworkCore;
using PostgreSQL_API.DB;

namespace DictionaryMng.Db
{
    public class CityDbContext : DbContext
    {
        public CityDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
    }
}
