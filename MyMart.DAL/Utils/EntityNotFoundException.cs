using System;
using System.Collections.Generic;
using System.Text;

namespace MyMart.DAL.Utils
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}
