using System.Linq.Expressions;

namespace CompetitionEventsManager.Repository.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // CRUD    
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, bool tracked = true);
        Task CreateAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);
        Task RemoveAsync(TEntity entity);
        Task SaveAsync();
        Task UpdateAsync(TEntity entity);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> filter);
    }
}