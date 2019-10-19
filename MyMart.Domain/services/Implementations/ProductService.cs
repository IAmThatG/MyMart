using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyMart.DAL.Entities;
using MyMart.DAL.Repositories;
using MyMart.Domain.Models.Request;
using MyMart.Domain.Models.Response;
using AutoMapper;

namespace MyMart.Domain.services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task Create(ProductRequest request)
        {
            var product = _mapper.Map<ProductRequest, Product>(request);
            // var product = new Product
            // {
            //     Name = request.Name,
            //     Price = request.Price,
            //     Description = request.Description,
            //     DateCreated = DateTime.Now
            // };
            await _repo.Insert(product);
        }

        public async Task<ICollection<ProductResponse>> GetAll()
        {
            ICollection<ProductResponse> response;
            try
            {
                var products = await _repo.GetAll();
                response = _mapper.Map<ICollection<Product>, ICollection<ProductResponse>>(products);
            }
            catch (Exception e)
            {
                throw;
            }
            // var response = new List<ProductResponse>();
            // foreach (var item in products)
            // {
            //     response.Add(new ProductResponse
            //     {
            //         id = item.Id,
            //         RackId = item.RackId,
            //         Name = item.Name,
            //         Description = item.Description,
            //         Price = item.Price,
            //         DateCreated = item.DateCreated,
            //         DateUpdated = item.DateUpdated
            //     });
            // }
            return response;
        }

        public async Task<ProductResponse> GetById(long id)
        {
            var product = await _repo.GetById(id);
            return new ProductResponse
            {
                id = product.Id,
                RackId = product.RackId,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                DateCreated = product.DateCreated,
                DateUpdated = product.DateUpdated,
            };
        }
    }
}