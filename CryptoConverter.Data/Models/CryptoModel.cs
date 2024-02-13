using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CryptoConverter.Data.Models.ApiModel;

namespace CryptoConverter.Data.Models
{
    public class CryptoModel
    {
        [Key]
        public string Id { get; set; } = null!;
        public string? Symbol { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public PriceModel Price { get; set; }
    }
}
