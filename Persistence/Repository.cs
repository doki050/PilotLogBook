using Domain.Model;
using Domain.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence;

public class Repository<TModel> : IRepository<TModel> where TModel : ModelBase
{
    private readonly DbSet<TModel> _dbSet;

    public Repository(AppDbContext context)
    {
        _dbSet = context.Set<TModel>();
    }

    public TModel Add(TModel model)
    {
        return _dbSet.Add(model).Entity;
    } 
}
