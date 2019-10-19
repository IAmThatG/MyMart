using MyMart.DAL.Entities;
using MyMart.Domain.Models.Request;
using MyMart.Domain.Models.Response;

namespace MyMart.Domain.services
{
    public interface IProductService: IBaseService<ProductResponse, ProductRequest>
    {
        
    }
}