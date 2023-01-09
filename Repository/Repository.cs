using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using CompetitionEventsManager.Data;
using CompetitionEventsManager.Repository.IRepository;

namespace CompetitionEventsManager.Repository
{
 
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DBContext _db;
        private DbSet<TEntity> _dbSet;

        public Repository(DBContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }
        public virtual async Task CreateAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveAsync();
        }
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? filter, bool tracked = true)
        {
            IQueryable<TEntity> query = _dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            query = query.Where(filter);

            return await query.FirstOrDefaultAsync();
        }
        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }
        public async Task RemoveAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await SaveAsync();
        }
        public async Task SaveAsync()
        {
           await _db.SaveChangesAsync();
        }
        public virtual async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter == null)
            {
                throw new NotImplementedException(); // ??????????????????????????????????????????????? need fix??
            }

            return await query.AnyAsync(filter);
        }
        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }



      
    }
}