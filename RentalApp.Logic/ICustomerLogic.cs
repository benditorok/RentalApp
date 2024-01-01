using RentalApp.Model;

namespace RentalApp.Logic;

public interface ICustomerLogic
{
    void Create(Customer item);

    Customer Read(int id);

    void Update(Customer item);

    void Delete(int id);

    IEnumerable<Customer> ReadAll();

    IEnumerable<Customer> GetCustomersByName(string firstName, string lastName);

    Task CreateAsync(Customer item);

    Task<Customer> ReadAsync(int id);

    Task UpdateAsync(Customer item);

    Task DeleteAsync(int id);

    Task<IEnumerable<Customer>> ReadAllAsync();

    Task<IEnumerable<Customer>> GetCustomersByNameAsync(string firstName, string lastName);
}
