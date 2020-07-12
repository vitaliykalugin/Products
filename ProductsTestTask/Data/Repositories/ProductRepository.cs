using Microsoft.EntityFrameworkCore;
using ProductsTestTask.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsTestTask.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(ApplicationContext context) : base(context) { }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _entities.Include(p => p.Categories).ThenInclude(pc => pc.Category).ToListAsync();
        }
    }
}
