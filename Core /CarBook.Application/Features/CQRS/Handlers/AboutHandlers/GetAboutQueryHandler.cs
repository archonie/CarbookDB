using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using Carbook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers;

public class GetAboutQueryHandler
{
    private readonly IRepository<About> _repository;

    public GetAboutQueryHandler(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAboutQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetAboutQueryResult
        {
            Title = x.Title,
            ImageUrl = x.ImageUrl,
            AboutID = x.AboutID,
            Description = x.Description,
        }).ToList();
    }
}