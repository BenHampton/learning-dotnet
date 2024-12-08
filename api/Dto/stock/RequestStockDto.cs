namespace api.Dto.stock;

public class RequestStockDto
{
    public int Symbol { get; set; }

    public string CompanyName { get; set; } = string.Empty;
        
    public string Industry { get; set; } = string.Empty;
        
    public decimal Purchase { get; set; }
        
    public int LastDiv { get; set; }

    public long MarketCap { get; set; }
}