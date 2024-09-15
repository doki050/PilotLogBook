using Domain.Model.PilotDocuments;
using Domain.Persistence;
using Domain.Services;
using Domain.UseCases.Messaging;

namespace Domain.UseCases.LogBooks;

public class GetLogBooks(
    IRepository<LogBook> repository,
    UserService userService
)
{
    public async Task<PagedEnvelope<LogBook>> RunAsync(
        PageRequest pagination,
        string userName,
        CancellationToken cancellationToken
    )
    {
        var userId = await userService.GetUserIdByUserNameAsync(userName);

        var query = repository.QueryAll();

        var totalCount = await repository.CountAsync(query, cancellationToken);
        var totalPages = (int)Math.Ceiling(totalCount / (double)pagination.Limit);

        var logBooks = await repository.RunAsync(query => query
            .Where(logbooks => logbooks.UserId == userId), cancellationToken);

        return new PagedEnvelope<LogBook>(logBooks, pagination, totalPages);
    }
}
