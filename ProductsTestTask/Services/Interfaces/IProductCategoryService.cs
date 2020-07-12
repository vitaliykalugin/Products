using ProductsTestTask.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsTestTask.Services.Interfaces
{
    public interface IProductCategoryService
    {
        Task<ProductCategory> InsertAsync(Product product, Category category);

        Task InsertRangeAsync(Product product, IEnumerable<Category> categories);
    }
}
