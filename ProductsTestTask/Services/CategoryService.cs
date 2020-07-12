using ProductsTestTask.Data.Interfaces;
using ProductsTestTask.Models;
using ProductsTestTask.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsTestTask.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
