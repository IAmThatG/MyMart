using AutoMapper;
using MyMart.DAL.Entities;
using MyMart.Domain.Models.Response;

namespace MyMart.Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
        }
    }
}