using RentalApp.Model;
using RentalApp.Repository;

namespace RentalApp.Logic.Logic;

public class CustomerLogic : ICustomerLogic
{
    private IRepository<Customer> repo;

    public CustomerLogic(IRepository<Customer> repo)
    {
        this.repo = repo;
    }

    public void Create(Customer item)
    {
        var customer = repo.Read(item.CustomerId);

        if (customer == null)
        {
            repo.Create(item);
        }
        else
        {
            throw new ArgumentException($"Customer({item.CustomerId}) already exists! " +
                $"Use update or delete before creating Customer({item.CustomerId})!");
        }
    }

    public Customer Read(int id)
    {
        var customer = repo.Read(id);

        if (customer != null)
        {
            return customer;
        }
        else
        {
            throw new ArgumentException($"Customer({id}) does not exist!");
        }
    }

    public void Update(Customer item)
    {
        var customer = repo.Read(item.CustomerId);

        if (customer != null)
        {
            repo.Update(item);
        }
        else
        {
            throw new ArgumentException($"Customer({item.CustomerId}) does not exist!");
        }
    }

    public void Delete(int id)
    {
        var customer = repo.Read(id);

        if (customer != null)
        {
            repo.Delete(id);
        }
        else
        {
            throw new ArgumentException($"Customer({id}) does not exist!");
        }
    }

    public IEnumerable<Customer> ReadAll()
    {
        return repo.ReadAll();
    }

    /// <summary>
    /// Get the customers who have the specified name.
    /// </summary>
    /// <param name="firstName">First name</param>
    /// <param name="lastName">Last name</param>
    /// <returns></returns>
    public IEnumerable<Customer> GetCustomersByName(string firstName, string lastName)
    {
        return repo.ReadAll()
            .Where(x => x.FirstName == firstName && x.LastName == lastName);
    }
}
