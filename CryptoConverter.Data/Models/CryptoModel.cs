using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoConverter.Data.Models
{
    public class CryptoModel
    {
        [Key]
        public string Id { get; set; } = null!;
        public string? symbol { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Price { get; set; }
    }
}
