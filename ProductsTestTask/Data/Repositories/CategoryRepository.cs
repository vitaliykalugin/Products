using ProductsTestTask.Models;

namespace ProductsTestTask.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(ApplicationContext context) : base(context) { }
    }
}
