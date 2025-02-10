using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using Carbook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class UpdateCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public UpdateCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCarCommand command)
    {
        var value = await _repository.GetByIdAsync(command.CarID);
        value.BrandID = command.BrandID;
        value.Model = command.Model;
        value.CarID = command.CarID;
        value.Km = command.Km;
        value.Fuel = command.Fuel;
        value.Luggage = command.Luggage;
        value.Seats = command.Seats;
        value.BigImageUrl = command.BigImageUrl;
        value.CoverImageUrl = command.CoverImageUrl;
        value.Transmission = command.Transmission;
        await _repository.UpdateAsync(value);  
    }
}