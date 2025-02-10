using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController: ControllerBase
{
    private readonly GetCarQueryHandler _getCarQueryHandler;
    private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
    private readonly CreateCarCommandHandler _createCarQueryHandler;
    private readonly UpdateCarCommandHandler _updateCarQueryHandler;
    private readonly RemoveCarCommandHandler _removeCarQueryHandler;

    public CarsController(
        GetCarQueryHandler getCarQueryHandler,
        GetCarByIdQueryHandler getCarByIdQueryHandler, 
        CreateCarCommandHandler createCarQueryHandler, 
        UpdateCarCommandHandler updateCarQueryHandler,
        RemoveCarCommandHandler removeCarQueryHandler)
    {
        _getCarQueryHandler = getCarQueryHandler;
        _getCarByIdQueryHandler = getCarByIdQueryHandler;
        _createCarQueryHandler = createCarQueryHandler;
        _updateCarQueryHandler = updateCarQueryHandler;
        _removeCarQueryHandler = removeCarQueryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> CarList()
    {
        var cars = await _getCarQueryHandler.Handle();
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCarById(int id)
    {
        var car = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
        return Ok(car);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarCommand command)
    {
        await _createCarQueryHandler.Handle(command);
        return Ok("Car created");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveCar(int id)
    {
        await _removeCarQueryHandler.Handle(new RemoveCarCommand(id));
        return Ok("Car removed");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
    {
        await _updateCarQueryHandler.Handle(command);
        return Ok("Car updated");
    }
}