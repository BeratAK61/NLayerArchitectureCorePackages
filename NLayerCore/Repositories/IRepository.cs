using System.Linq.Expressions;

namespace MyCorePackages.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity, new()
{
    void Delete(TEntity entity);
    int Create(TEntity entity);
    void Update(TEntity entity);
    TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties);
    List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties);
}
