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
        throw new NotImplementedException();
    }
    public Rental Read(int id)
    {
        throw new NotImplementedException();
    }
    public void Update(Rental item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Rental> ReadAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Rental> GetActiveRentals(DateTime date)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Car> GetCarsByDate(DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Customer> GetCustomersByDate(DateTime date)
    {
        throw new NotImplementedException();
    }
}
