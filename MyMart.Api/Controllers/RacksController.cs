using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMart.Domain.Models.Request;
using MyMart.Domain.Models.Response;
using MyMart.Domain.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyMart.Api.Controllers
{
    [ApiController]
    [Route("api/racks")]
    public class RacksController : ControllerBase
    {
        private readonly ILogger<RacksController> _logger;
        private readonly IRackService _rackService;

        public RacksController(ILogger<RacksController> logger, IRackService rackService)
        {
            _logger = logger;
            _rackService = rackService;
        }

        [HttpPost]
        public async Task<IActionResult> PostRack([FromBody] RackRequest request)
        {
            ApiResponse response;
            RackResponse rackRes;
            try
            {
                rackRes = await _rackService.Create(request);
                response = new ApiResponse
                {
                    status = true,
                    message = "success",
                    result = rackRes
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occured while creating rack");
                response = new ApiResponse
                {
                    status = false,
                    message = "Something went wrong..."
                };
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            return CreatedAtAction("GetRack", new { id = rackRes.Id }, response);
        }

        [HttpGet("{id}", Name = "GetRack")]
        public async Task<IActionResult> GetRack(long id)
        {
            RackResponse productRes;
            try
            {
                productRes = await _rackService.GetById(id);
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
    }
}
