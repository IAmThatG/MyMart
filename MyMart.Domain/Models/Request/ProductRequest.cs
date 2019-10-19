using System;

namespace MyMart.Domain.Models.Request
{
    public class ProductRequest : BaseRequest
    {
        public long RackId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
    }
}