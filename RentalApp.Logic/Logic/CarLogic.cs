using RentalApp.Model;
using RentalApp.Repository;

namespace RentalApp.Logic.Logic;

public class CarLogic : ICarLogic
{
    private IRepository<Car> repo;

    public CarLogic(IRepository<Car> repo)
    {
        this.repo = repo;
    }

    public void Create(Car item)
    {
        throw new NotImplementedException();
    }

    public Car Read(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Car item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Car> ReadAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Car> GetCarsByMake(string make)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Car> GetCarsFromYear(int year)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Car> GetMostExpensive(int count)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Car> GetNotMaintained()
    {
        throw new NotImplementedException();
    }
}