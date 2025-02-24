using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using Carbook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers;

public class GetContactQueryHandler
{
    private readonly IRepository<Contact> _repository;

    public GetContactQueryHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetContactQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetContactQueryResult
        {
            ContactID = x.ContactID,
            Email = x.Email,
            Message = x.Message,
            SendDate = x.SendDate,
            Subject = x.Subject,
            Name = x.Name
        }).ToList();
    }
}