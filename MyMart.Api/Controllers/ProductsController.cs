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
using MyMart.DAL.Utils;

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
            ApiResponse response;
            try
            {
                var products = await _productService.GetAll();
                response = new ApiResponse
                {
                    status = true,
                    message = "success",
                    result = products
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occured while fetching products");
                response = new ApiResponse
                {
                    status = false,
                    message = "Something went wrong...",
                    result = null
                };
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(long id)
        {
            ProductResponse productRes;
            try
            {
                productRes = await _productService.GetById(id);
                if (productRes == null)
                {
                    return NotFound(new ApiResponse
                    {
                        status = false,
                        message = $"Product with id '{id}' doesn't exist",
                    });
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while fetching product");

                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new ApiResponse
                    {
                        status = false,
                        message = "Something went wrong..."
                    });
            }
            return Ok(new ApiResponse
            {
                status = true,
                message = "success",
                result = productRes
            });
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] ProductRequest product)
        {
            ApiResponse response;
            ProductResponse productRes;
            try
            {
                productRes = await _productService.Create(product);
                response = new ApiResponse
                {
                    status = true,
                    message = "success",
                    result = productRes
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occured while creating product");
                response = new ApiResponse
                {
                    status = false,
                    message = "Something went wrong..."
                };
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            return CreatedAtAction("GetProduct", new { id = productRes.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(long id, ProductRequest request)
        {
            ApiResponse response;
            ProductResponse productResponse;
            try
            {
                productResponse = await _productService.Update(id, request);
                response = new ApiResponse
                {
                    status = true,
                    message = "success",
                    result = productResponse
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occured while updating product");
                response = new ApiResponse
                {
                    status = false,
                    message = "Something went wrong..."
                };
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            ApiResponse response;
            try
            {
                await _productService.DeleteAsync(id);
                response = new ApiResponse
                {
                    status = true,
                    message = "success"
                };
            }
            catch (EntityNotFoundException e)
            {
                _logger.LogError(e, "Couldn't find product to be deleted");
                response = new ApiResponse
                {
                    status = false,
                    message = e.Message
                };
                return NotFound(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occured while updating product");
                response = new ApiResponse
                {
                    status = false,
                    message = "Something went wrong..."
                };
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            return Ok(response);
        }
    }
}