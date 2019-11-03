using System;

namespace MyMart.Domain.Models.Response
{
    public abstract class BaseResponse
    {
        public long Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}