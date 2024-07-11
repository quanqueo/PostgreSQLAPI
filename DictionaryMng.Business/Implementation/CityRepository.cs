using DictionaryMng.Db;
using Microsoft.EntityFrameworkCore;
using PostgreSQL_API.DB;

namespace DictionaryMng.Business.Implementation
{
    public class CityRepository : ICityRepository
    {
        private readonly CityDbContext _dbContext;
        public CityRepository(CityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<IEnumerable<City>> ListAllAsync()
        {
            var query = _dbContext.Cities;
            var result = await query.ToListAsync();
            return result;
        }
    }
}
