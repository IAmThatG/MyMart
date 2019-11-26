using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyMart.DAL.Entities;

namespace MyMart.DAL.Repositories.Implementations
{
    public class CustomerRepo : BaseRepo, ICustomerRepo
    {
        public CustomerRepo(MyMartDbContext context) : base(context)
        {

        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetByIdAsync(long id)
        {
            var customer = await base.ctx.Customers.FindAsync(id);
            return customer;
        }

        public async Task<Customer> InsertAsync(Customer data)
        {
            await base.ctx.AddAsync(data);
            await base.ctx.SaveChangesAsync();
            return data;
        }

        public Task<Customer> UpdateAsync(long id, Customer data)
        {
            throw new NotImplementedException();
        }
    }
}
