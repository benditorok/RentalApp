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
        var car = repo.Read(item.CarId);

        if (car == null)
        {
            repo.Create(item);
        }
        else
        {
            throw new ArgumentException($"Car({item.CarId}) already exists! " +
                $"Use update or delete before creating Car({item.CarId})!");
        }
    }

    public Car Read(int id)
    {
        var car = repo.Read(id);

        if (car != null)
        {
            return car;
        }
        else
        {
            throw new ArgumentException($"Car({id}) does not exist!");
        }
    }

    public void Update(Car item)
    {
        var car = repo.Read(item.CarId);

        if (car != null)
        {
            repo.Update(item);
        }
        else
        {
            throw new ArgumentException($"Car({item.CarId}) does not exist!");
        }
    }

    public void Delete(int id)
    {
        var car = repo.Read(id);

        if (car != null)
        {
            repo.Delete(id);
        }
        else
        {
            throw new ArgumentException($"Car({id}) does not exist!");
        }
    }

    public IQueryable<Car> ReadAll()
    {
        return repo.ReadAll();
    }

    /// <summary>
    /// Get cars made in the specified year.
    /// </summary>
    /// <param name="year">Year</param>
    /// <returns></returns>
    public IEnumerable<Car> GetCarsFromYear(int year)
    {
        return repo.ReadAll()
            .Where(x => x.Year == year);
    }

    /// <summary>
    /// Get cars by the specified make.
    /// </summary>
    /// <param name="make">Make</param>
    /// <returns></returns>
    public IEnumerable<Car> GetCarsByMake(string make)
    {
        return repo.ReadAll()
            .Where(x => x.Make == make);
    }

    /// <summary>
    /// Get the most expensive cars.
    /// </summary>
    /// <param name="count">Number of cars to get.</param>
    /// <returns></returns>
    public IEnumerable<Car> GetMostExpensive(int count = 1)
    {
        return repo.ReadAll()
            .OrderByDescending(x => x.DailyCost)
            .Take(count);
    }

    /// <summary>
    /// Get the least expensive cars.
    /// </summary>
    /// <param name="count">Number of cars to get.</param>
    /// <returns></returns>
    public IEnumerable<Car> GetLeastExpensive(int count = 1)
    {
        return repo.ReadAll()
            .OrderBy(x => x.DailyCost)
            .Take(count);
    }

    /// <summary>
    /// Get cars which have no maintenance records.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Car> GetNotMaintained()
    {
        return repo.ReadAll()
                .Where(x => x.Maintenances.Count() == 0);
    }
}