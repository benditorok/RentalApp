using Microsoft.EntityFrameworkCore;
using RentalApp.Model;
using RentalApp.Repository;

namespace RentalApp.Logic.Logic;

public class RentalLogic : IRentalLogic
{
    private IRepository<Rental> repo;

    public RentalLogic(IRepository<Rental> repo)
    {
        this.repo = repo;
    }

    public void Create(Rental item)
    {
        var rental = repo.Read(item.RentalId);

        if (rental == null)
        {
            repo.Create(item);
        }
        else
        {
            throw new ArgumentException($"Rental({item.RentalId}) already exists! " +
                $"Use update or delete before creating Rental({item.RentalId})!");
        }
    }
    public Rental Read(int id)
    {
        var rental = repo.Read(id);

        if (rental != null)
        {
            return rental;
        }
        else
        {
            throw new ArgumentException($"Rental({id}) does not exist!");
        }
    }
    public void Update(Rental item)
    {
        var rental = repo.Read(item.RentalId);

        if (rental != null)
        {
            repo.Update(item);
        }
        else
        {
            throw new ArgumentException($"Rental({item.RentalId}) does not exist!");
        }
    }

    public void Delete(int id)
    {
        var rental = repo.Read(id);

        if (rental != null)
        {
            repo.Delete(id);
        }
        else
        {
            throw new ArgumentException($"Rental({id}) does not exist!");
        }
    }

    public IEnumerable<Rental> ReadAll()
    {
        return repo.ReadAll().ToList();
    }

    /// <summary>
    /// Get cars which have been rented between the specified dates.
    /// </summary>
    /// <param name="start">Start date</param>
    /// <param name="end">End date</param>
    /// <returns></returns>
    public IEnumerable<Car> GetCarsByDate(DateTime start, DateTime end)
    {
        return repo.ReadAll()
            .Where(x => x.StartDate.Date >= start.Date && x.EndDate.Date <= end.Date)
            .OrderBy(x => x.CarId)
            .Select(x => x.Car)
            .ToList();
    }

    /// <summary>
    /// Get customers who rented cars on the specified day.
    /// </summary>
    /// <param name="date">Date</param>
    /// <returns></returns>
    public IEnumerable<Customer> GetCustomersByDate(DateTime date)
    {
        return repo.ReadAll()
                .Where(x => x.StartDate.Date == date.Date)
                .OrderBy(x => x.CustomerId)
                .Select(x => x.Customer)
                .ToList();
    }

    /// <summary>
    /// Get active rentals on a specified date.
    /// </summary>
    /// <param name="date">Date</param>
    /// <returns></returns>
    public IEnumerable<Rental> GetActiveRentals(DateTime date)
    {
        return repo.ReadAll()
                .Where(x => x.StartDate.Date <= date.Date && x.EndDate.Date >= date.Date)
                .OrderBy(x => x.RentalId)
                .ToList();
    }

    public async Task CreateAsync(Rental item)
    {
        var rental = await repo.ReadAsync(item.RentalId);

        if (rental == null)
        {
            await repo.CreateAsync(item);
        }
        else
        {
            throw new ArgumentException($"Rental({item.RentalId}) already exists! " +
                $"Use update or delete before creating Rental({item.RentalId})!");
        }
    }
    public async Task<Rental> ReadAsync(int id)
    {
        var rental = await repo.ReadAsync(id);

        if (rental != null)
        {
            return rental;
        }
        else
        {
            throw new ArgumentException($"Rental({id}) does not exist!");
        }
    }
    public async Task UpdateAsync(Rental item)
    {
        var rental = await repo.ReadAsync(item.RentalId);

        if (rental != null)
        {
            repo.Update(item);
        }
        else
        {
            throw new ArgumentException($"Rental({item.RentalId}) does not exist!");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var rental = await repo.ReadAsync(id);

        if (rental != null)
        {
            await repo.DeleteAsync(id);
        }
        else
        {
            throw new ArgumentException($"Rental({id}) does not exist!");
        }
    }

    public async Task<IEnumerable<Rental>> ReadAllAsync()
    {
        return await repo.ReadAll()
                .ToListAsync();
    }

    /// <summary>
    /// Get cars which have been rented between the specified dates.
    /// </summary>
    /// <param name="start">Start date</param>
    /// <param name="end">End date</param>
    /// <returns></returns>
    public async Task<IEnumerable<Car>> GetCarsByDateAsync(DateTime start, DateTime end)
    {
        return await repo.ReadAll()
                .Where(x => x.StartDate.Date >= start.Date && x.EndDate.Date <= end.Date)
                .OrderBy(x => x.CarId)
                .Select(x => x.Car)
                .ToListAsync();
    }

    /// <summary>
    /// Get customers who rented cars on the specified day.
    /// </summary>
    /// <param name="date">Date</param>
    /// <returns></returns>
    public async Task<IEnumerable<Customer>> GetCustomersByDateAsync(DateTime date)
    {
        return await repo.ReadAll()
                .Where(x => x.StartDate.Date == date.Date)
                .OrderBy(x => x.CustomerId)
                .Select(x => x.Customer)
                .ToListAsync();
    }

    /// <summary>
    /// Get active rentals on a specified date.
    /// </summary>
    /// <param name="date">Date</param>
    /// <returns></returns>
    public async Task<IEnumerable<Rental>> GetActiveRentalsAsync(DateTime date)
    {
        return await repo.ReadAll()
                .Where(x => x.StartDate.Date <= date.Date && x.EndDate.Date >= date.Date)
                .OrderBy(x => x.RentalId)
                .ToListAsync();
    }
}
