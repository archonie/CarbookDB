using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using Carbook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarWithBrandQueryHandler
{
    private readonly ICarRepository _repository;

    public GetCarWithBrandQueryHandler(ICarRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCarWithBrandQueryResult>> Handle()
    {
        var values = _repository.GetCarsListWithBrands();
        return values.Select(x => new GetCarWithBrandQueryResult
        {
            BrandName = x.Brand.Name,
            Fuel = x.Fuel,
            Km = x.Km,
            Luggage = x.Luggage,
            Model = x.Model,
            Seats = x.Seats,
            Transmission = x.Transmission,
            BigImageUrl = x.BigImageUrl,
            CoverImageUrl = x.CoverImageUrl,
            BrandID = x.BrandID,
            CarID = x.CarID,
        }).ToList();
    }
}