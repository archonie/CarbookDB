using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController: ControllerBase
{
    private readonly IMediator _mediator;

    public ServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> ServiceList()
    {
        var values = await _mediator.Send(new GetServiceQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetServiceById(int id)
    {
        var value = await _mediator.Send(new GetServiceByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateService(CreateServiceCommand command)
    {
        await _mediator.Send(command);
        return Ok("Service created");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
    {
        await _mediator.Send(command);
        return Ok("Service updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveService(int id)
    {
        await _mediator.Send(new RemoveServiceCommand(id));
        return Ok("Service deleted");
    }
}