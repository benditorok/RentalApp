using RentalApp.Model;
using RentalApp.Repository;

namespace RentalApp.Logic.Logic;

public class CustomerLogic : ICustomerLogic
{
    private IRepository<Customer>? repo;

    public CustomerLogic(IRepository<Customer> repo)
    {
        this.repo = repo;
    }

    public void Create(Customer item)
    {
        throw new NotImplementedException();
    }

    public Customer Read(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Customer item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Customer> ReadAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Customer> GetCustomersByName(string firstName, string lastName)
    {
        throw new NotImplementedException();
    }
}
