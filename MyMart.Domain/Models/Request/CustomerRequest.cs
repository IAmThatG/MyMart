using System;
using System.Collections.Generic;
using System.Text;

namespace MyMart.Domain.Models.Request
{
    public class CustomerRequest : BaseRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
