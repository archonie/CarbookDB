using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using Carbook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers;

public class UpdateBrandCommandHandler
{
    private readonly IRepository<Brand> _repository;

    public UpdateBrandCommandHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateBrandCommand command)
    {
        var value = await _repository.GetByIdAsync(command.BrandID);
        value.Name = command.Name;
        await _repository.UpdateAsync(value);
    }
}