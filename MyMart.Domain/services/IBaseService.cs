using System.Collections.Generic;
using System.Threading.Tasks;
using MyMart.DAL.Entities;
using MyMart.Domain.Models.Request;
using MyMart.Domain.Models.Response;

namespace MyMart.Domain.services
{
    public interface IBaseService<T, G> where T : BaseResponse where G : BaseRequest
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetById(long id);
        Task Create(G data);
    }
}