using MyMart.DAL.Entities;
using System;

namespace MyMart.Domain.Models.Response
{
    public class ProductResponse : BaseResponse
    {
        public long RackId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}