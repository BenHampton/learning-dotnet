namespace api.Dto;

public class StockDto
{
    public int Id { get; set; }

    public int Symbol { get; set; }

    public string CompanyName { get; set; } = string.Empty;
        
    public string Industry { get; set; } = string.Empty;
        
    public decimal Purchase { get; set; }
        
    public int LastDiv { get; set; }

    public long MarketCap { get; set; }

    public List<CommentDto> Comments { get; set; } = new List<CommentDto>();

}