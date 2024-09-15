using AutoMapper;
using Domain.Model.PilotDocuments;
using Domain.Persistence;
using Domain.Services;

namespace Domain.UseCases.LogBooks;

public partial class CreateLogBook(
    IRepository<LogBook> repository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    UserService userService
)
{
    public async Task<LogBook> RunAsync(Dto dto, string userName, CancellationToken cancellationToken)
    {
        var userId = await userService.GetUserIdByUserNameAsync(userName);

        var logBook = mapper.Map<LogBook>(dto);
        logBook.UserId = userId;

        var model = repository.Add(logBook);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return model;
    }
}
