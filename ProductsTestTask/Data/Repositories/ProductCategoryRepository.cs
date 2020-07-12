using ProductsTestTask.Models;

namespace ProductsTestTask.Data.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>
    {
        public ProductCategoryRepository(ApplicationContext context) : base(context) { }
    }
}
