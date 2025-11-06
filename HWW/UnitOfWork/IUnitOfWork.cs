using System;
using System.Threading.Tasks;
using HWW.Models;
using HWW.Repositories;

namespace HWW.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IRepository<ProductCategory> ProductCategories { get; }
        Task<int> CompleteAsync();
    }
}
