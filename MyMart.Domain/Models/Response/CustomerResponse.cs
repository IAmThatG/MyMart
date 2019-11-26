using System;
using System.Collections.Generic;
using System.Text;

namespace MyMart.Domain.Models.Response
{
    public class CustomerResponse : BaseResponse
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long ApplicationUserId { get; set; }
    }
}
