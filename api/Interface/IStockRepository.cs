using api.Dto;
using api.Model;

namespace api.Interface;

public interface IStockRepository
{
    Task<List<Stock>> FindAllAsync();
    
    Task<Stock?> FindByIdAsync(int id);
    
    Task<Stock> CreateAsync(Stock stock);
    
    Task<Stock?> UpdateAsync(int id, Stock stock);
    
    Task<Stock?> DeleteByIdAsync(int id);
}