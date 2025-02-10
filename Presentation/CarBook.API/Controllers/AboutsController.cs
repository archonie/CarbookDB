using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutsController: ControllerBase
{
    private readonly CreateAboutCommandHandler _createAboutCommandHandler;
    private readonly GetAboutQueryHandler _getAboutQueryHandler;
    private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
    private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
    private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;

    public AboutsController(
        CreateAboutCommandHandler createAboutCommandHandler, 
        GetAboutQueryHandler getAboutQueryHandler,
        GetAboutByIdQueryHandler getAboutByIdQueryHandler,
        UpdateAboutCommandHandler updateAboutCommandHandler,
        RemoveAboutCommandHandler removeAboutCommandHandler)
    {
        _createAboutCommandHandler = createAboutCommandHandler;
        _getAboutQueryHandler = getAboutQueryHandler;
        _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
        _updateAboutCommandHandler = updateAboutCommandHandler;
        _removeAboutCommandHandler = removeAboutCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> AboutList()
    {
        var values = await _getAboutQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAbout(int id)
    {
        var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
    {
        await _createAboutCommandHandler.Handle(command);
        return Ok("About created"); 
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveAbout(int id)
    {
        await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
        return Ok("About removed");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
    {
        await _updateAboutCommandHandler.Handle(command);
        return Ok("About updated");
    }
}