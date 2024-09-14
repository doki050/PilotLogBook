using AutoMapper;
using Domain.Model.PilotDocuments;
using Domain.Persistence;

namespace Domain.UseCases.LogBooks;

public partial class CreateLogBook(
    IRepository<LogBook> repository,
    IUnitOfWork unitOfWork,
    IMapper mapper
)
{
    public async Task<LogBook> RunAsync(Dto dto, CancellationToken cancellationToken)
    {
        var logBook = mapper.Map<LogBook>(dto);

        var model = repository.Add(logBook);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return model;
    }
}
