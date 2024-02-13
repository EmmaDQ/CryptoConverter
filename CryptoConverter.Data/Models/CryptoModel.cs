using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public PriceDbModel Price { get; set; }
    }

    public class PriceDbModel()
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
    }
}
