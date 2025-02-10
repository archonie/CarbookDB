using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using Carbook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers;

public class GetBrandByIdQueryHandler
{
    private readonly IRepository<Brand> repository;

    public GetBrandByIdQueryHandler(IRepository<Brand> repository)
    {
        this.repository = repository;
    }

    public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
    {
        var value = await repository.GetByIdAsync(query.Id);
        return new GetBrandByIdQueryResult
        {
            Name = value.Name,
            BrandID = value.BrandID
        };
    }
}