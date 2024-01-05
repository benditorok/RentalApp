using RentalApp.Model;

namespace RentalApp.Logic;

public interface ICarLogic
{
    void Create(Car item);

    Car Read(int id);

    void Update(Car item);

    void Delete(int id);

    IEnumerable<Car> ReadAll();

    IEnumerable<Car> GetCarsFromYear(int year);

    IEnumerable<Car> GetCarsByMake(string make);

    IEnumerable<Car> GetMostExpensive(int count = 1);

    IEnumerable<Car> GetLeastExpensive(int count = 1);

    IEnumerable<Car> GetNotMaintained();

    Task CreateAsync(Car item);

    Task<Car> ReadAsync(int id);

    Task UpdateAsync(Car item);

    Task DeleteAsync(int id);

    Task<IEnumerable<Car>> ReadAllAsync();

    Task<IEnumerable<Car>> GetCarsFromYearAsync(int year);

    Task<IEnumerable<Car>> GetCarsByMakeAsync(string make);

    Task<IEnumerable<Car>> GetMostExpensiveAsync(int count = 1);

    Task<IEnumerable<Car>> GetLeastExpensiveAsync(int count = 1);

    Task<IEnumerable<Car>> GetNotMaintainedAsync();
}

