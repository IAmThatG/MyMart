namespace MyMart.DAL.Repositories.Implementations
{
    public abstract class BaseRepo
    {
        protected readonly MyMartDbContext ctx;

        public BaseRepo(MyMartDbContext context)
        {
            ctx = context;
        }
    }
}