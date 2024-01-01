using RentalApp.Model;

namespace RentalApp.Logic;

public interface IRentalLogic
{
    void Create(Rental item);

    Rental Read(int id);

    void Update(Rental item);

    void Delete(int id);

    IEnumerable<Rental> ReadAll();

    IEnumerable<Car> GetCarsByDate(DateTime start, DateTime end);

    IEnumerable<Customer> GetCustomersByDate(DateTime date);

    IEnumerable<Rental> GetActiveRentals(DateTime date);

    Task CreateAsync(Rental item);

    Task<Rental> ReadAsync(int id);

    Task UpdateAsync(Rental item);

    Task DeleteAsync(int id);

    Task<IEnumerable<Rental>> ReadAllAsync();

    Task<IEnumerable<Car>> GetCarsByDateAsync(DateTime start, DateTime end);

    Task<IEnumerable<Customer>> GetCustomersByDateAsync(DateTime date);

    Task<IEnumerable<Rental>> GetActiveRentalsAsync(DateTime date);
}
