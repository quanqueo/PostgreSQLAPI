using DictionaryMng.Business.Models;
using PostgreSQL_API.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryMng.Business.Implementation
{
    public interface ICityRepository
    {
        public Task<IEnumerable<City>> ListAllAsync();
    }
}
