using Domain.Model;

namespace Domain.Persistence;

public interface IRepository<TModel> where TModel : IModel
{
    TModel Add(TModel model);
}
