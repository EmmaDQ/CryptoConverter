using CryptoConverter.Data.Models;

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
