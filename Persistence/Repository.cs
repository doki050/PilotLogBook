using Domain.Model;
using Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class Repository<TModel> : IRepository<TModel> where TModel : ModelBase
{
    private readonly DbSet<TModel> _dbSet;
    private readonly IQueryable<TModel> _query;

    public Repository(AppDbContext context)
    {
        _dbSet = context.Set<TModel>();
        _query = _dbSet;
    }

    public TModel Add(TModel model) 
        => _dbSet.Add(model).Entity;

    public async Task<TModel> GetAsync(int id, CancellationToken cancellationToken)
        => await _query.FirstOrDefaultAsync(model => model.Id == id, cancellationToken);

    public IQueryable<TModel> QueryAll() 
        => _query;

    public Task<int> CountAsync(IQueryable<TModel> query, CancellationToken cancellationToken)
        => query.CountAsync(cancellationToken);

    [Obsolete("use the other RunAsync with the Func argument")]
    public async Task<IEnumerable<TResult>> RunAsync<TResult>(IQueryable<TResult> query, CancellationToken cancellationToken)
    => await query.ToArrayAsync(cancellationToken);

    public async Task<IEnumerable<TResult>> RunAsync<TResult>(Func<IQueryable<TModel>, IQueryable<TResult>> query, CancellationToken cancellationToken)
        => query(_dbSet.Local.AsQueryable()).ToArray().Concat(await query(_query).ToArrayAsync(cancellationToken));

    public async Task<TModel> UpdateAsync(int id, Action<TModel> update, CancellationToken cancellationToken)
    {
        // AsTracking is required to load collection navigation properties and overwrite them on save
        // instead of augmenting them, and simply adding to the collection
        var model = await _query.AsTracking().FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
        update(model);
        return model;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        TModel model = await GetAsync(id, cancellationToken);
        Delete(model);
    }

    public async void Delete(TModel model)
        => _dbSet.Remove(model);
}
