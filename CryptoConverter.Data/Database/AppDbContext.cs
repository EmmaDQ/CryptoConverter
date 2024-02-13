using CryptoConverter.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoConverterData.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CryptoModel> Cryptos { get; set; }
    }
}
