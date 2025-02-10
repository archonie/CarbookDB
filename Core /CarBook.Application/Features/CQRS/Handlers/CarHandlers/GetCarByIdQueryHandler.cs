using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using Carbook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarByIdQueryHandler
{
    private readonly IRepository<Car> _repository;

    public GetCarByIdQueryHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
    {
         var value = await _repository.GetByIdAsync(query.Id);
         return new GetCarByIdQueryResult
         {
             Fuel = value.Fuel,
             BigImageUrl = value.BigImageUrl,
             CoverImageUrl = value.CoverImageUrl,
             Luggage = value.Luggage,
             Transmission = value.Transmission,
             BrandID = value.BrandID,
             Model = value.Model,
             CarID = value.CarID,
             Seats = value.Seats,
             Km = value.Km,
         };
    }
}