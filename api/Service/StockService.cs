using api.Dto;
using api.Dto.stock;
using api.Helpers;
using api.Interface;
using api.Mapper;

namespace api.Service;

public class StockService: IStockService
{
    private readonly IStockRepository _stockRepository;

    public StockService(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }
    
    public async Task<List<StockDto>> FindAllAsync()
    {
        //todo deferred execution
        var stocks = await _stockRepository.FindAllAsync();
         
        //todo do i need ToList
        var stockDtos = stocks.Select(stock => stock.ToDto()).ToList();
            
        return stockDtos;
    }
    
    public async Task<List<StockDto>> FindAllByQueryAsync(QueryObject query)
    {
        //todo deferred execution
        var stocks = await _stockRepository.FindAllByQueryAsync(query);
         
        var stockDtos = stocks.Select(stock => stock.ToDto()).ToList();
            
        return stockDtos;
    }
    
    public async Task<StockDto?> FindByIdAsync(int Id)
    {
        //todo deferred execution
        var stock = await _stockRepository.FindByIdAsync(Id);
            
        return stock?.ToDto();
    }

    public async Task<StockDto?> UpdateAsync(int id, RequestStockDto requestStockDto)
    {
            
        var stock = await _stockRepository.UpdateAsync(id, requestStockDto.ToStockFromDto());
            
        return stock == null ? null : stock.ToDto();
    }


    public async Task<StockDto?> DeleteByIdAsync(int id)
    {
        var stock = await _stockRepository.DeleteByIdAsync(id);
     
        return stock?.ToDto();
    }
}