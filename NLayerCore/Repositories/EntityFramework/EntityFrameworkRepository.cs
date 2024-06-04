using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCorePackages.Repositories.EntityFramework;

public class EntityFrameworkRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    private readonly DbContext _context;

    public EntityFrameworkRepository(DbContext context)
    {
        _context = context;
    }

    public int Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity.Id;
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        _context.SaveChanges();
    }
    public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        query = query.Where(filter);
        if (includeProperties.Any())
        {
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
        }
        return query.FirstOrDefault();
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (includeProperties.Any())
        {
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
        }

        return query.ToList();
    }

    public void Update(TEntity entity)
    {
        //_context.Entry(entity).State = EntityState.Modified;
        //_context.SaveChanges();

        var updatedEntity = _context.Entry(entity);
        updatedEntity.State = EntityState.Modified;
        _context.SaveChanges();
    }
}
