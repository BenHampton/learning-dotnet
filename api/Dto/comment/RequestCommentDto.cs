namespace api.Dto;

public class RequestCommentDto
{
    public string Title { get; set; } = string.Empty;
    
    public string Content { get; set; } = string.Empty;
    
    public int? StockId { get; set; }
}