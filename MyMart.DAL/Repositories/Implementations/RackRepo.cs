using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyMart.DAL.Entities;

namespace MyMart.DAL.Repositories.Implementations
{
    public class RackRepo : BaseRepo, IRackRepo
    {
        public RackRepo(MyMartDbContext context) : base(context)
        {

        }
        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Rack>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Rack> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Rack> InsertAsync(Rack data)
        {
            await ctx.AddAsync(data);
            await ctx.SaveChangesAsync();
            return data;
        }

        public Task<Rack> UpdateAsync(long id, Rack data)
        {
            throw new NotImplementedException();
        }
    }
}
