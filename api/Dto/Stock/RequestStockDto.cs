using System.ComponentModel.DataAnnotations;

namespace api.Dto.stock;

public class RequestStockDto
{
    [Required]
    [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 characters")]
    public string Symbol { get; set; } = string.Empty;

    [Required]
    [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 characters")]
    public string CompanyName { get; set; } = string.Empty;
        
    [Required]
    [MaxLength(10, ErrorMessage = "Industry cannot be over 10 characters")]
    public string Industry { get; set; } = string.Empty;
        
    [Required]
    [Range(1, 1000000000)]
    public decimal Purchase { get; set; }
        
    [Required]
    [Range(0.001, 100)]
    public int LastDiv { get; set; }

    [Required]
    [Range(1, 5000000000)]
    public long MarketCap { get; set; }
}