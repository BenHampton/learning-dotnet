using api.Data;
using api.Dto;
using api.Interface;
using api.Mapper;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class StockRepository : IStockRepository
{

    private readonly ApplicationDBContext _context;

    public StockRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<List<Stock>> FindAllAsync()
    {
        return await _context.Stock
            .Include(c => c.Comments)
            .ToListAsync();
    }

    public async Task<Stock?> FindByIdAsync(int id)
    {
        return await _context.Stock
            .Include(c => c.Comments)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Stock> CreateAsync(Stock stock)
    { 
        await _context.Stock.AddAsync(stock);
        await _context.SaveChangesAsync();
        return stock;
    }

    public async Task<Stock?> UpdateAsync(int id, Stock stock)
    {
        var existingStock = await _context.Stock.FirstOrDefaultAsync(s => s.Id == id);

        if (existingStock == null)
        {
            return null;
        }
        
        existingStock.Symbol = stock.Symbol;
        existingStock.CompanyName = stock.CompanyName;
        existingStock.Purchase = stock.Purchase;
        existingStock.LastDiv = stock.LastDiv;
        existingStock.Industry = stock.Industry;
        existingStock.MarketCap = stock.MarketCap;
        
        await _context.SaveChangesAsync();

        return existingStock;
    }

    public async Task<Stock?> DeleteByIdAsync(int id)
    {
        var stock = await _context.Stock.FirstOrDefaultAsync(s => s.Id == id);
        
        if (stock == null)
        {
            return null;
        }
            
        _context.Stock.Remove(stock);
        await _context.SaveChangesAsync();

        return stock;
    }
}