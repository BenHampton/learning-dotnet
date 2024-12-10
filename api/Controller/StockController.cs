using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto;
using api.Dto.stock;
using api.Helpers;
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
        
        private readonly IStockService _stockService;

        public StockController(IStockRepository stockRepository, IStockService stockService)
        {
            _stockRepository = stockRepository;
            _stockService = stockService;
        }
        
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            
            var stocks = await _stockService.FindAllAsync();
            
            return Ok(stocks);
        }
        
        //pageable & queryable
        [HttpGet("queryable")]
        public async Task<IActionResult> FindByQuery([FromQuery] QueryObject query)
        {
            // //todo deferred execution
            // var stocks = await _stockRepository.FindAllByQueryAsync(query);
            //
            // var stockDto = stocks.Select(stock => stock.ToDto());
            //
            // return Ok(stocks);

            var stocks = await _stockService.FindAllByQueryAsync(query);
            return Ok();
        }
        
        //todo route constraints
        //todo model binding
        [HttpGet("{id:int}")]
        public async Task<IActionResult> FindById([FromRoute] int Id)
        {
            
            var stock = await _stockService.FindByIdAsync(Id);
            
            return stock == null ? NotFound(Id) : Ok(stock);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestStockDto requestStockDto)
        {
            
            if (!ModelState.IsValid) //comes from base controller
            {
                return BadRequest(ModelState);
            }
            
            var stock = requestStockDto.ToStockFromDto();
            
            await _stockRepository.CreateAsync(stock);
            
            return CreatedAtAction(nameof(FindById), new { id = stock.Id }, stock);
        }
        
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] RequestStockDto requestStockDto)
        {
            
            if (!ModelState.IsValid) //comes from base controller
            {
                return BadRequest(ModelState);
            }
            
            var stock = await _stockService.FindByIdAsync(id);
            
            return stock == null ? NotFound(id) : Ok(stock);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            
            var stock = await _stockService.DeleteByIdAsync(id);
            
            return stock == null ? NotFound(id) : NoContent();
        }
    }
}