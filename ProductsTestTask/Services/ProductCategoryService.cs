using ProductsTestTask.Data.Interfaces;
using ProductsTestTask.Models;
using ProductsTestTask.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsTestTask.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepository<ProductCategory> _repository;

        public ProductCategoryService(IRepository<ProductCategory> repository)
        {
            _repository = repository;
        }

        public async Task<ProductCategory> InsertAsync(Product product, Category category)
        {
            return await _repository.InsertAsync(new ProductCategory { ProductId = product.Id, CategoryId = category.Id});
        }

        public async Task InsertRangeAsync(Product product, IEnumerable<Category> categories)
        {
            var productCategories = categories.Select(category => new ProductCategory { ProductId = product.Id, CategoryId = category.Id });
            await _repository.InsertRangeAsync(productCategories);
        }
    }
}
