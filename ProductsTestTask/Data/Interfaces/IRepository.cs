using ProductsTestTask.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsTestTask.Data.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> InsertAsync(T entity);

        Task InsertRangeAsync(IEnumerable<T> entities);
    }
}
