using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CryptoConverter.Data.Models.ApiModel;

namespace CryptoConverter.Data.Models
{
    public class CryptoModel
    {
        [Key]
        public int Id { get; set; }
        public string cryptoAPI_Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Symbol { get; set; }
        public int? MarketCapRank { get; set; }
        public int? Price { get; set; }
    }
}
