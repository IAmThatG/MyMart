using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyMart.DAL.Entities;
using MyMart.DAL.Repositories;

namespace MyMart.Domain.services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _repo;

        public ProductService(IProductRepo repo)
        {
            _repo = repo;
        }

        public async Task Create(Product data)
        {
            data.DateCreated = DateTime.Now;
            await _repo.Insert(data);
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Product> GetById()
        {
            return await _repo.GetById();
        }
    }
}