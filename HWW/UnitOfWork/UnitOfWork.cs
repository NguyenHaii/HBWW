using System.Threading.Tasks;
using HWW.Data;
using HWW.Models;
using HWW.Repositories;

namespace HWW.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IRepository<Product> Products { get; }
        public IRepository<Category> Categories { get; }
        public IRepository<ProductCategory> ProductCategories { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Products = new Repository<Product>(context);
            Categories = new Repository<Category>(context);
            ProductCategories = new Repository<ProductCategory>(context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
