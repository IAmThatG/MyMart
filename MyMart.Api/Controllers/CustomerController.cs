using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMart.Domain.Models.Request;
using MyMart.Domain.Models.Response;
using MyMart.Domain.services;

namespace MyMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync(CustomerRequest request)
        {
            ApiResponse response;
            CustomerResponse customerResponse;
            try
            {
                customerResponse = await _customerService.CreateAsync(request);
                if (customerResponse == null)
                {
                    response = new ApiResponse
                    {
                        status = false,
                        message = "Customer with that email exists",
                    };
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, response);
                }
                response = new ApiResponse
                {
                    status = true,
                    message = "Success",
                    result = customerResponse
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occured while creating customer");
                response = new ApiResponse
                {
                    status = false,
                    message = "Something went wrong..."
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            return CreatedAtAction("GetCustomerAsync", new { id = customerResponse.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(long id)
        {
            ApiResponse response;
            try
            {
                var customerResponse = await _customerService.GetByIdAsync(id);
                if (customerResponse == null)
                {
                    response = new ApiResponse
                    {
                        status = false,
                        message = $"Customer with id '{id}' not found"
                    };
                    return NotFound(response);
                }
                response = new ApiResponse
                {
                    status = true,
                    message = "Success",
                    result = customerResponse
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occured while fetching customer");
                response = new ApiResponse
                {
                    status = false,
                    message = "Something went wrong..."
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            return Ok(response);
        }
    }
}