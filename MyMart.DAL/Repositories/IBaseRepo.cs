using System.Collections.Generic;
using System.Threading.Tasks;
using MyMart.DAL.Entities;

namespace MyMart.DAL.Repositories
{
    public interface IBaseRepo<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetById();
        Task Insert(T data);
    }
}