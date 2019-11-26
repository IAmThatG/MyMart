
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMart.Domain.Models.Response
{
    public class SignInResponse
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
