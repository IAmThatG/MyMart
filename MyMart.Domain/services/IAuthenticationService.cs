using MyMart.Domain.Models.Request;
using MyMart.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMart.Domain.services
{
    public interface IAuthenticationService
    {
        Task<SignInResponse> SignIn(SignInRequest request);
    }
}
