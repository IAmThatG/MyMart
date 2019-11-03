using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyMart.DAL.Entities;
using MyMart.DAL.Repositories;
using MyMart.Domain.Models.Request;
using MyMart.Domain.Models.Response;
using AutoMapper;
using MyMart.DAL.Utils;

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

        public async Task<ProductResponse> Create(ProductRequest request)
        {
            var product = _mapper.Map<ProductRequest, Product>(request);
            // var product = new Product
            // {
            //     Name = request.Name,
            //     Price = request.Price,
            //     Description = request.Description,
            //     DateCreated = DateTime.Now
            // };
            var createdProduct = await _repo.InsertAsync(product);
            var productRes = _mapper.Map<Product, ProductResponse>(createdProduct);
            return productRes;
        }

        public async Task DeleteAsync(long id) => await _repo.DeleteAsync(id);

        public async Task<ICollection<ProductResponse>> GetAll()
        {
            ICollection<ProductResponse> response;
            try
            {
                var products = await _repo.GetAllAsync();
                response = _mapper.Map<ICollection<Product>, ICollection<ProductResponse>>(products);
            }
            catch (Exception)
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
            ProductResponse result = null;
            var product = await _repo.GetByIdAsync(id);
            if (product != null)
            {
                result = new ProductResponse
                {
                    Id = product.Id,
                    RackId = product.RackId,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    DateCreated = product.DateCreated,
                    DateUpdated = product.DateUpdated,
                };
            }
            return result;
        }

        public async Task<ProductResponse> Update(long id, ProductRequest data)
        {
            var product = await _repo.GetByIdAsync(id);
            product.Name = data.Name ?? product.Name;
            product.Price = decimal.Compare(data.Price, 0M) > 0 ? data.Price : product.Price;
            product.RackId = data.RackId > 0 ? data.RackId : product.RackId;
            product.Description = data.Description ?? product.Description;
            var updatedProduct = await _repo.UpdateAsync(id, product);
            var productResponse = _mapper.Map<Product, ProductResponse>(updatedProduct);
            return productResponse;
        }
    }
}