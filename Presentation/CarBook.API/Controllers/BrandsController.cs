using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController: ControllerBase
{
    private readonly GetBrandQueryHandler _getBrandQueryHandler;
    private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
    private readonly CreateBrandCommandHandler _createBrandQueryHandler;
    private readonly UpdateBrandCommandHandler _updateBrandQueryHandler;
    private readonly RemoveBrandCommandHandler _removeBrandQueryHandler;

    public BrandsController(
        GetBrandQueryHandler getBrandQueryHandler, 
        GetBrandByIdQueryHandler getBrandByIdQueryHandler,
        CreateBrandCommandHandler createBrandQueryHandler,
        UpdateBrandCommandHandler updateBrandQueryHandler, 
        RemoveBrandCommandHandler removeBrandQueryHandler)
    {
        _getBrandQueryHandler = getBrandQueryHandler;
        _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
        _createBrandQueryHandler = createBrandQueryHandler;
        _updateBrandQueryHandler = updateBrandQueryHandler;
        _removeBrandQueryHandler = removeBrandQueryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> BrandList()
    {
        var brands = await _getBrandQueryHandler.Handle();
        return Ok(brands);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BrandById(int id)
    {
        var brand = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
        return Ok(brand);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
    {
        await _createBrandQueryHandler.Handle(command);
        return Ok("Brand created");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
    {
        await _updateBrandQueryHandler.Handle(command);
        return Ok("Brand updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveBrand(int id)
    {
        await _removeBrandQueryHandler.Handle(new RemoveBrandCommand(id));
        return Ok("Brand removed");
    }
}