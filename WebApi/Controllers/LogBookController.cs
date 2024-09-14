using Domain.Model.PilotDocuments;
using Domain.UseCases.LogBooks;
using Domain.UseCases.Messaging;
using Microsoft.AspNetCore.Mvc;

using CreateLogBookDto = Domain.UseCases.LogBooks.CreateLogBook.Dto;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LogBookController : ControllerBase
{
    private readonly IServiceProvider _serviceProvider;

    public LogBookController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateLogBookDto dto,
        CancellationToken cancellationToken
    )
    {
        var created = await _serviceProvider
            .GetRequiredService<CreateLogBook>()
            .RunAsync(dto, cancellationToken);

        return Created(uri: string.Empty, new Envelope<LogBook>(created));
    }
}
