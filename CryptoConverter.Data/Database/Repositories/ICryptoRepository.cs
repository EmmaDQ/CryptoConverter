using CryptoConverter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoConverter.Data.Database.Repositories
{
    public interface ICryptoRepository
    {
        public Task<CryptoModel?> GetById(string currencyId);
        public Task<List<CryptoModel>> GetAll();
        public Task Add(CryptoModel model);
        public Task SaveChanges();
    }
}
