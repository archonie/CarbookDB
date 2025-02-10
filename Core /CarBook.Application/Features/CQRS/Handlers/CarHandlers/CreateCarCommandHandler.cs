using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using Carbook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class CreateCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public CreateCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCarCommand command)
    {
        await _repository.CreateAsync(new Car
        {
            Model = command.Model,
            Fuel = command.Fuel,
            Transmission = command.Transmission,
            BigImageUrl = command.BigImageUrl,  
            CoverImageUrl = command.CoverImageUrl,
            Luggage = command.Luggage,
            BrandID = command.BrandID,
            Km = command.Km,
            Seats = command.Seats,
        });
    }
}