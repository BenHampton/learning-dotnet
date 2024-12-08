using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto;
using api.Dto.stock;
using api.Interface;
using api.Mapper;
using api.Model;
using api.Repository;
using api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controller
{
    [Route("api/stocks")]
    [ApiController]
    public class StockController: ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            //todo deferred execution
            var stocks = await _stockRepository.FindAllAsync();
         
            var stockDto = stocks.Select(stock => stock.ToDto());
            
            return Ok(stocks);
        }
        
        //todo model binding
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById([FromRoute] int Id)
        {
            //todo deferred execution
            var stock = await _stockRepository.FindByIdAsync(Id);

            if (stock == null)
            {
                return NotFound(Id);
            }
            
            return Ok(stock.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestStockDto requestStockDto)
        {
            var stock = requestStockDto.ToStockFromDto();
            
            await _stockRepository.CreateAsync(stock);
            
            return CreatedAtAction(nameof(FindById), new { id = stock.Id }, stock);
        }
        
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] RequestStockDto requestStockDto)
        {
            var stock = await _stockRepository.UpdateAsync(id, requestStockDto.ToStockFromDto());

            if (stock == null)
            {
                return NotFound(id);
            }
            
            return Ok(stock.ToDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var stock = await _stockRepository.DeleteByIdAsync(id);
            
            if (stock == null)
            {
                return NotFound(id);
            }
            
            return NoContent();
        }

        
        // //todo read about defered execution
        // [HttpGet]
        // public async Task<IActionResult> GetAll() 
        // {
        //     var user = await _stockService.TestServiceMethod(1);
        //
        //     return Ok(user);
        // }
    }
}