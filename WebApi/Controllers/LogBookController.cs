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
    private readonly IServiceProvider _services;

    public LogBookController(IServiceProvider serviceProvider)
    {
        _services = serviceProvider;
    }

    [HttpGet("{id}")]
    [ProducesResponseType<Envelope<LogBook>>(StatusCodes.Status200OK)]

    public async Task<IActionResult> Get(
        int id,
        CancellationToken cancellationToken
    )
    {
        var result = await _services
            .GetRequiredService<GetLogBook>()
            .RunAsync(id, cancellationToken);

        return Ok(new Envelope<LogBook>(result));
    }

    [HttpGet]
    [ProducesResponseType<PagedEnvelope<LogBook>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        [FromQuery] PageRequestQueryParam pageRequestParam,
        CancellationToken cancellationToken
    )
    {
        pageRequestParam.ThrowIfInvalid(pageRequestParam);

        var result = await _services
            .GetRequiredService<GetLogBooks>()
            .RunAsync(
                pageRequestParam.ToDomainObject(),
                cancellationToken
            );

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType<Envelope<LogBook>>(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post(
        [FromBody] CreateLogBook.Dto dto,
        CancellationToken cancellationToken
    )
    {
        var created = await _services
            .GetRequiredService<CreateLogBook>()
            .RunAsync(dto, cancellationToken);

        return Created(uri: (string)null, new Envelope<LogBook>(created));
    }

    [HttpPut("{id}")]
    [ProducesResponseType<Envelope<LogBook>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Put(
        int id,
        [FromBody] CreateLogBook.Dto dto,
        CancellationToken cancellationToken
    )
    {
        var result = await _services
            .GetRequiredService<UpdateLogBook>()
            .RunAsync(id, dto, cancellationToken);

        return Ok(new Envelope<LogBook>(result));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(
    [FromRoute] int id,
    CancellationToken cancellationToken
    )
    {
        await _services
            .GetRequiredService<DeleteLogBook>()
            .RunAsync(id, cancellationToken);

        return Ok();
    }
}
