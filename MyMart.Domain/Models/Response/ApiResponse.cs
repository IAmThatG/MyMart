using System;
using System.Collections.Generic;
using System.Text;

namespace MyMart.Domain.Models.Response
{
    public class ApiResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public object result { get; set; }
    }
}
