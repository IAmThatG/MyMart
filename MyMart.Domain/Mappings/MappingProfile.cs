using AutoMapper;
using MyMart.DAL.Entities;
using MyMart.Domain.Models.Request;
using MyMart.Domain.Models.Response;

namespace MyMart.Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<ProductRequest, Product>().ReverseMap();
            CreateMap<RackRequest, Rack>().ReverseMap();
            CreateMap<Rack, RackResponse>().ReverseMap();
            CreateMap<CustomerRequest, Customer>().ReverseMap();
            CreateMap<Customer, CustomerResponse>().ReverseMap();
        }
    }
}