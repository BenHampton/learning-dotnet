using api.Dto;
using api.Dto.stock;
using api.Model;

namespace api.Mapper;

//todo extension methods
public static class StockMapper
{
    public static StockDto ToDto(this Stock stock)
    {
        return new StockDto
        {
            Id = stock.Id,
            Symbol = stock.Symbol,
            CompanyName = stock.CompanyName,
            Industry = stock.Industry,
            LastDiv = stock.LastDiv,
            MarketCap = stock.MarketCap,
            Purchase = stock.Purchase,
            Comments = stock.Comments
                .Select(c => c.ToDto())
                .ToList(),
        };
    }

    public static Stock ToStockFromDto(this RequestStockDto dto)
    {
        return new Stock
        {
            Symbol = dto.Symbol,
            CompanyName = dto.CompanyName,
            Industry = dto.Industry,
            LastDiv = dto.LastDiv,
            MarketCap = dto.MarketCap,
            Purchase = dto.Purchase,
        };
    }
}