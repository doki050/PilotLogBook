using AutoMapper;
using Domain.Model.PilotDocuments;
using Domain.Persistence;

namespace Domain.UseCases.LogBooks;

public class UpdateLogBook(
    IRepository<LogBook> repository,
    IUnitOfWork unitOfWork,
    IMapper mapper
)
{
    public async Task<LogBook> RunAsync(
        int id,
        CreateLogBook.Dto dto,
        CancellationToken cancellationToken
    )
    {
        var logBook = await repository
            .UpdateAsync(id, logBook => Update(dto, logBook), cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return logBook;
    }

    private LogBook Update(CreateLogBook.Dto dto, LogBook lb)
    {
        if (lb == null)
            throw new LogBookIsNotFoundException();

        var logBook = mapper.Map(dto, lb);
        return logBook;
    }
}
