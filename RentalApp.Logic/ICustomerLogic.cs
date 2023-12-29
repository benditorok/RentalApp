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
}
