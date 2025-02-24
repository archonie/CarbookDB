using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeatureController: ControllerBase
{
     private readonly IMediator _mediator;

     public FeatureController(IMediator mediator)
     {
          _mediator = mediator;
     }

     [HttpGet]
     public async Task<IActionResult> FeatureList()
     {
          var values = await _mediator.Send(new GetFeatureQuery());
          return Ok(values);
     }

     [HttpGet("{id}")]
     public async Task<IActionResult> GetFeatureById(int id)
     {
          var value = await _mediator.Send(new GetFeatureByIdQuery(id));
          return Ok(value);
     }

     [HttpPost]
     public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
     {
          await _mediator.Send(command);
          return Ok("Feature created");
     }

     [HttpPut]
     public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
     {
          await _mediator.Send(command);
          return Ok("Feature updated");
     }

     [HttpDelete("{id}")]
     public async Task<IActionResult> RemoveFeature(int id)
     {
          await _mediator.Send(new RemoveFeatureCommand(id));
          return Ok("Feature deleted");
     }
}