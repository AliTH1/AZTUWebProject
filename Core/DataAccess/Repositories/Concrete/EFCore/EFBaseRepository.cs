using Core.DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories.Concrete.EFCore
{
    public abstract class EFBaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EFBaseRepository(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, params string[] includes)
        {
            IQueryable<TEntity> query = GetQuery(includes);
            return await query.Where(filter).FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null
            , params string[] includes)
        {
            IQueryable<TEntity> query = GetQuery(includes);
            return await (filter == null
                ? query.ToListAsync()
                : query.Where(filter).ToListAsync()
                );
        }

        public async Task<List<TEntity>> GetAllPaginatedAsync(int page, int size, Expression<Func<TEntity, bool>> filter = null, params string[] includes)
        {
            IQueryable<TEntity> query = GetQuery(includes);
            return await (filter==null
                ? query.Skip((page-1) * size).Take(size).ToListAsync()
                : query.Where(filter).Skip((page - 1) * size).Take(size).ToListAsync()
                );
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await SaveAsync();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private IQueryable<TEntity> GetQuery(string[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            foreach (string include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.AnyAsync(filter);
        }

    }
}
