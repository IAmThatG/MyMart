using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMart.DAL.Entities;

namespace MyMart.DAL.Repositories.Implementations
{
    public class ProductRepo : BaseRepo, IProductRepo
    {
        public ProductRepo(MyMartDbContext ctx) : base(ctx)
        {
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return await base.ctx.Products.ToListAsync();
        }

        public async Task<Product> GetById(long id)
        {
            return await base.ctx.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task Insert(Product data)
        {
            await base.ctx.AddAsync(data);
            await base.ctx.SaveChangesAsync();
        }
    }
}