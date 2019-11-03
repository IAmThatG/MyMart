using MyMart.Domain.Models.Request;
using MyMart.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMart.Domain.services
{
    public interface IRackService : IBaseService<RackResponse, RackRequest>
    {
    }
}
