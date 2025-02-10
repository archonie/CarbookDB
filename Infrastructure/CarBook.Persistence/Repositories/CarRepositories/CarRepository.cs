using CarBook.Application.Interfaces.CarInterfaces;
using Carbook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarRepositories;

public class CarRepository: ICarRepository
{
    private readonly CarBookContext _context;

    public CarRepository(CarBookContext context)
    {
        _context = context;
    }

    public List<Car> GetCarsListWithBrands()
    {
        var values = _context.Cars.Include(x => x.Brand).ToList();
        return values;
    }
}