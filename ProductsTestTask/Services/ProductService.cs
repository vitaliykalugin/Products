using ProductsTestTask.Data.Interfaces;
using ProductsTestTask.Models;
using ProductsTestTask.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsTestTask.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product> InsertAsync(Product entity)
        {
            return await _repository.InsertAsync(entity);
        }
    }
}
