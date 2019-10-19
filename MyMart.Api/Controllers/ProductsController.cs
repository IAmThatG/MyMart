using System.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMart.DAL.Entities;
using MyMart.Domain.services;
using MyMart.Domain.Models.Response;
using MyMart.Domain.Models.Request;

namespace MyMart.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            ICollection<ProductResponse> products;
            try
            {
                products = await _productService.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occured while fetching products");
                return StatusCode(500);
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(long id)
        {
            ProductResponse product;
            try
            {
                product = await _productService.GetById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while fetching product");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] ProductRequest product)
        {
            try
            {
                await _productService.Create(product);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occured while creating product");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            return Created("", product);
        }
    }
}