using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Stock
    {
        public int Id { get; set; }

        public int Symbol { get; set; }

        public string CompanyName { get; set; } = string.Empty;
        
        public string Industry { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public int LastDiv { get; set; }

        public long MarketCap { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}