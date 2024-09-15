using Domain.Model.PilotDocuments;
using Domain.UseCases.LogBooks;
using Domain.UseCases.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Security.Claims;
using WebApi.RequestDtos;

namespace WebApi.Controllers;

[Authorize]
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
        var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var result = await _services
            .GetRequiredService<GetLogBooks>()
            .RunAsync(
                pageRequestParam.ToDomainObject(),
                userName,
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
        var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var created = await _services
            .GetRequiredService<CreateLogBook>()
            .RunAsync(dto, userName, cancellationToken);

        return Created(uri: null as string, new Envelope<LogBook>(created));
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
