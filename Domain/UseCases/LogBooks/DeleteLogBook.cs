using Domain.Model.PilotDocuments;
using Domain.Persistence;

namespace Domain.UseCases.LogBooks;

public class DeleteLogBook(
    IRepository<LogBook> repository,
    IUnitOfWork unitOfWork
)
{
    public async Task RunAsync(int id, CancellationToken cancellationToken)
    {
        var logBook = await repository
            .GetAsync(id, cancellationToken);

        await repository
            .DeleteAsync(logBook.Id, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
