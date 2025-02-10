using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController: ControllerBase
{
    private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
    private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
    private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
    private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
    private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

    public CategoriesController(
        RemoveCategoryCommandHandler removeCategoryCommandHandler, 
        UpdateCategoryCommandHandler updateCategoryCommandHandler, 
        CreateCategoryCommandHandler createCategoryCommandHandler, 
        GetCategoryByIdQueryHandler getCategoryByIdQueryHandler,
        GetCategoryQueryHandler getCategoryQueryHandler)
    {
        _removeCategoryCommandHandler = removeCategoryCommandHandler;
        _updateCategoryCommandHandler = updateCategoryCommandHandler;
        _createCategoryCommandHandler = createCategoryCommandHandler;
        _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
        _getCategoryQueryHandler = getCategoryQueryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        var categories = await _getCategoryQueryHandler.Handle();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var category = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
    {
        await _createCategoryCommandHandler.Handle(command);
        return Ok("Category created");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
    {
        await _updateCategoryCommandHandler.Handle(command);
        return Ok("Category updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveCategory(int id)
    {
        await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
        return Ok("Category removed");
    }
    
}