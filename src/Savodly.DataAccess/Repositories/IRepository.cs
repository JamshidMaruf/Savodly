using System.Linq.Expressions;

namespace Savodly.DataAccess.Repositories;
public interface IRepository<TEntity>
{
    void Insert(TEntity entity);
    Task InsertRangeAsync(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate, string[] include = null);
    IQueryable<TEntity> SelectAllAsQueryable();  
}