using System.Collections.Generic;
using System.Threading.Tasks;
using MyMart.DAL.Entities;

namespace MyMart.Domain.services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetById();
        Task Create(T data);
    }
}