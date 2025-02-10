using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using Carbook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers;

public class UpdateContactCommandHandler
{
    private readonly IRepository<Contact> _repository;

    public UpdateContactCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateContactCommand command)
    {
        var value = await _repository.GetByIdAsync(command.ContactID);
        value.Email = command.Email;
        value.Message = command.Message;
        value.SendDate = command.SendDate;
        value.Name = command.Name;
        value.Subject = command.Subject;
        await _repository.UpdateAsync(value);
    }
}