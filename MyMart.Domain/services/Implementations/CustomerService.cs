using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyMart.DAL.Entities;
using MyMart.DAL.Repositories;
using MyMart.Domain.Models.Request;
using MyMart.Domain.Models.Response;
using AutoMapper;

namespace MyMart.Domain.services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICustomerRepo _repo;
        private readonly IMapper _mapper;

        public CustomerService(UserManager<ApplicationUser> userManager,
            ICustomerRepo repo,
            IMapper mapper)
        {
            _userManager = userManager;
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<CustomerResponse> CreateAsync(CustomerRequest data)
        {
            //check if user exist
            var existingUser = await _userManager.FindByEmailAsync(data.Email);
            if (existingUser != null)
            {
                return null;
            }
            var user = new ApplicationUser
            {
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
                UserName = data.Email,
            };
            var result = await _userManager.CreateAsync(user, data.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to store user");
            }
            var customerData = _mapper.Map<CustomerRequest, Customer>(data);
            customerData.ApplicationUserId = user.Id;
            var customer = await _repo.InsertAsync(customerData);
            var customerResult = _mapper.Map<Customer, CustomerResponse>(customer);
            return customerResult;
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CustomerResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerResponse> GetByIdAsync(long id)
        {
            CustomerResponse response = null;
            var customers = await _repo.GetByIdAsync(id);
            if(customers != null) response = _mapper.Map<Customer, CustomerResponse>(customers);
            return response;
        }

        public Task<CustomerResponse> UpdateAsync(long id, CustomerRequest data)
        {
            throw new NotImplementedException();
        }
    }
}
