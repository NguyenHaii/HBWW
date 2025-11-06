using System.Threading.Tasks;
using HWW.Models;
using HWW.UnitOfWork;

namespace HWW.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddProductWithCategory(string productName, decimal price, string categoryName)
        {
            var product = new Product { ProductName = productName, Price = price };
            var category = new Category { CategoryName = categoryName };

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.CompleteAsync();

            await _unitOfWork.ProductCategories.AddAsync(new ProductCategory
            {
                ProductId = product.Id,
                CategoryId = category.Id
            });

            await _unitOfWork.CompleteAsync();
        }
    }
}
