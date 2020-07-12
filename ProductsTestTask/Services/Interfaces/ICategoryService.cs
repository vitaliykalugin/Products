using ProductsTestTask.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsTestTask.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
