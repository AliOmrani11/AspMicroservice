using Catalog.Api.Entities;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IProductRepository productRepository, ILogger<CatalogController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        [HttpGet("getall",Name = "GetAllProduct")]
        [ProducesResponseType(typeof(IEnumerable<TblProduct>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }
        
        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType(typeof(TblProduct), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _productRepository.GetById(id);
            if (product==null)
            {
                _logger.LogError($"Product with id : {id} , not found");
                return NotFound();
            }
            return Ok(product);
        }
        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TblProduct>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductByCategory(string category)
        {
            var products = await _productRepository.GetByCategory(category);
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TblProduct),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateProduct(TblProduct product)
        {
            await _productRepository.Insert(product);
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut]
        [ProducesResponseType(typeof(TblProduct), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCreateProduct(TblProduct product)
        {
          return Ok(await _productRepository.Update(product));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(TblProduct), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCreateProduct(string id)
        {
            return Ok(await _productRepository.Delete(id));
        }
    }
}
