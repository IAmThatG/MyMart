using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMart.DAL.Entities;
using MyMart.DAL.Utils;

namespace MyMart.DAL.Repositories.Implementations
{
    public class ProductRepo : BaseRepo, IProductRepo
    {
        public ProductRepo(MyMartDbContext ctx) : base(ctx)
        {
        }

        public async Task DeleteAsync(long id)
        {
            var product = await ctx.Products.FindAsync(id);
            if (product == null)
                throw new EntityNotFoundException($"Product with id {id} doesn't exist");
            ctx.Products.Remove(product);
            await ctx.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await base.ctx.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(long id)
        {
            return await base.ctx.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> InsertAsync(Product data)
        {
            await ctx.AddAsync(data);
            await ctx.SaveChangesAsync();
            return data;
        }

        public async Task<Product> UpdateAsync(long id, Product data)
        {
            try
            {
                var product = await ctx.FindAsync<Product>(id);
                if (product == null)
                {
                    throw new EntityNotFoundException($"Product with id - {id} does not exist");
                }
                ctx.Update(data);
                await ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return data;
        }


    }
}