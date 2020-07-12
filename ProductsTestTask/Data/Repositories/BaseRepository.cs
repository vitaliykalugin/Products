using Microsoft.EntityFrameworkCore;
using ProductsTestTask.Data.Interfaces;
using ProductsTestTask.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsTestTask.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _entities;

        protected BaseRepository(DbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var insertedEntity = await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();

            return insertedEntity.Entity;
        }

        public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }
    }
}
