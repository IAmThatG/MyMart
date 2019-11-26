using System.Collections.Generic;
using System.Threading.Tasks;
using MyMart.DAL.Entities;
using MyMart.Domain.Models.Request;
using MyMart.Domain.Models.Response;

namespace MyMart.Domain.services
{
    public interface IBaseService<T, G> where T : BaseResponse where G : BaseRequest
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<T> CreateAsync(G data);
        Task<T> UpdateAsync(long id, G data);
        Task DeleteAsync(long id);
    }
}