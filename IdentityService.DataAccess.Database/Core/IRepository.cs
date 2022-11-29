using IdentityService.DataAccess.Database.Core.BaseDomain;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Core;

public interface IRepository<TEntity> where TEntity : BaseEntity, IBaseEntity
{
    public IQueryable<TEntity> GetAll();
    TEntity Get(Guid id);
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    TEntity Add(TEntity entity);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
}

public class Repository<TEntity> :IRepository<TEntity> where TEntity : BaseEntity, IBaseEntity
{
    private readonly DbContext _context;
    public DbSet<TEntity> Entity { get; }
    public Repository(DbContext context)
    {
        _context = context;
        Entity = _context.Set<TEntity>();
    }
    private IRepository<TEntity> _repositoryImplementation;
    public IQueryable<TEntity> GetAll()
    {
        return _repositoryImplementation.GetAll();
    }

    public TEntity Get(Guid id)
    {
        return _repositoryImplementation.Get(id);
    }

    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _repositoryImplementation.GetByIdAsync(id, cancellationToken);
    }

    public TEntity Add(TEntity entity)
    {
        return _repositoryImplementation.Add(entity);
    }

    public Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return _repositoryImplementation.AddAsync(entity, cancellationToken);
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return _repositoryImplementation.UpdateAsync(entity, cancellationToken);
    }

    public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return _repositoryImplementation.RemoveAsync(entity, cancellationToken);
    }
}