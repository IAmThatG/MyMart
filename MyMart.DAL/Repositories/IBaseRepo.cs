using System.Collections.Generic;
using System.Threading.Tasks;
using MyMart.DAL.Entities;

namespace MyMart.DAL.Repositories
{
    public interface IBaseRepo<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<T> InsertAsync(T data);

        Task<T> UpdateAsync(long id, T data);
        Task DeleteAsync(long id);
    }
}