using System;
using System.Collections.Generic;
using System.Text;

namespace MyMart.Domain.Configurations
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
    }
}
