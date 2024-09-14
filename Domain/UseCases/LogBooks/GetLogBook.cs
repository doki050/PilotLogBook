using Domain.Model.PilotDocuments;
using Domain.Persistence;

namespace Domain.UseCases.LogBooks;

public class GetLogBook(IRepository<LogBook> repository)
{
    private readonly IRepository<LogBook> _repository = repository;

    public Task<LogBook> RunAsync(int id, CancellationToken cancellationToken)
    {
        return _repository.GetAsync(id, cancellationToken);
    }
}
