using Domain.Model;

namespace Domain.Persistence;

public interface IRepository<TModel> where TModel : IModel
{
    TModel Add(TModel model);

    Task<TModel> GetAsync(int id, CancellationToken cancellationToken);

    IQueryable<TModel> QueryAll();

    Task<int> CountAsync(IQueryable<TModel> query, CancellationToken cancellationToken);


    [Obsolete("use the other RunAsync with the Func argument")]
    Task<IEnumerable<TResult>> RunAsync<TResult>(IQueryable<TResult> query, CancellationToken cancellationToken);

    Task<IEnumerable<TResult>> RunAsync<TResult>(Func<IQueryable<TModel>, IQueryable<TResult>> query, CancellationToken cancellationToken);
}
