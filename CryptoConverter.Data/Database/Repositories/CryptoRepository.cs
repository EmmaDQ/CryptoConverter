using CryptoConverter.Data.Models;
using CryptoConverterData.Database;
using Microsoft.EntityFrameworkCore;

namespace CryptoConverter.Data.Database.Repositories
{
    public class CryptoRepository : ICryptoRepository
    {
        private readonly AppDbContext _dbContext;

        public CryptoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(CryptoModel crypto)
        {
            await _dbContext.Cryptos.AddAsync(crypto);
        }

        public async Task<List<CryptoModel>> GetAll()
        {
            List<CryptoModel> cryptos = await _dbContext.Cryptos.ToListAsync();
            return cryptos;
        }

        public async Task<CryptoModel?> GetById(string currencyId)
        {
            CryptoModel? crypto = await _dbContext.Cryptos.FirstOrDefaultAsync(c => c.cryptoAPI_Id == currencyId);

            if (crypto != null)
            {
                return crypto;
            }

            return null;
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
