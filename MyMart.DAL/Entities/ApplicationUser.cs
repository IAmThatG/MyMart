using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMart.DAL.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Customer Customer { get; set; }
    }
}
