using Carbook.Domain.Entities;

namespace CarBook.Application.Interfaces.CarInterfaces;

public interface ICarRepository
{
    List<Car> GetCarsListWithBrands();
}