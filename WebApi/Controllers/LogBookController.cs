using Domain.Model.PilotDocuments;
using Domain.UseCases.LogBooks;
using Domain.UseCases.Messaging;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class LogBookController : ControllerBase
{
    private readonly IServiceProvider _serviceProvider;

    public LogBookController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [HttpPost]
    [ProducesResponseType<Envelope<LogBook>>(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(
        [FromBody] CreateLogBook.Dto dto,
        CancellationToken cancellationToken
    )
    {
        var created = await _serviceProvider
            .GetRequiredService<CreateLogBook>()
            .RunAsync(dto, cancellationToken);

        return Created(uri: (string)null, new Envelope<LogBook>(created));
    }
}
