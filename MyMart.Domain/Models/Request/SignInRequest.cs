﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyMart.Domain.Models.Request
{
    public class SignInRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
