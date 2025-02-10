using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Carbook.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BannersController: ControllerBase
{
    private readonly CreateBannerCommandHandler _createBannerCommandHandler;
    private readonly GetBannerQueryHandler _getBannerQueryHandler;
    private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
    private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
    private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;

    public BannersController(
        CreateBannerCommandHandler createBannerCommandHandler,
        GetBannerQueryHandler getBannerQueryHandler, 
        UpdateBannerCommandHandler updateBannerCommandHandler, 
        RemoveBannerCommandHandler removeBannerCommandHandler, 
        GetBannerByIdQueryHandler getBannerByIdQueryHandler)
    {
        _createBannerCommandHandler = createBannerCommandHandler;
        _getBannerQueryHandler = getBannerQueryHandler;
        _updateBannerCommandHandler = updateBannerCommandHandler;
        _removeBannerCommandHandler = removeBannerCommandHandler;
        _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> BannerList()
    {
        var values = await _getBannerQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBanner(int id)
    {
        var value = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
    {
        await _createBannerCommandHandler.Handle(command);
        return Ok("Banner created");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveBanner(int id)
    {
        await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
        return Ok("Banner removed");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
    {
        await _updateBannerCommandHandler.Handle(command);
        return Ok("Banner updated");
    }
}