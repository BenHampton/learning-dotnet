using api.Dto;
using api.Dto.stock;
using api.Helpers;
using api.Model;

namespace api.Interface;

public interface IStockService
{
    Task<List<StockDto>> FindAllAsync();
    
    Task<List<StockDto>> FindAllByQueryAsync(QueryObject query);
    
    Task<StockDto?> FindByIdAsync(int id);
    
    //todo CreatedAtAction how to call from service?
    // Task<StockDto> CreateAsync(Stock stock);
    
    Task<StockDto?> UpdateAsync(int id, RequestStockDto requestStockDto);
    
    Task<StockDto?> DeleteByIdAsync(int id);
}