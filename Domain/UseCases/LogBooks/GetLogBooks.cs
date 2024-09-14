using Domain.Model.PilotDocuments;
using Domain.Persistence;
using Domain.UseCases.Messaging;

namespace Domain.UseCases.LogBooks;

public class GetLogBooks(IRepository<LogBook> repository)
{
    public async Task<PagedEnvelope<LogBook>> RunAsync(
        PageRequest pagination,
        CancellationToken cancellationToken
    )
    {
        var query = repository
            .QueryAll();

        var totalCount = await repository.CountAsync(query, cancellationToken);
        var totalPages = (int)Math.Ceiling(totalCount / (double)pagination.Limit);

        var logBooks = await repository.RunAsync(query => query, cancellationToken);

        return new (logBooks, pagination, totalPages);
    }
}
