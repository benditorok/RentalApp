using RentalApp.Model;

namespace RentalApp.Logic;

public interface IRentalLogic
{
    void Create(Rental item);

    Rental Read(int id);

    void Update(Rental item);

    void Delete(int id);

    IQueryable<Rental> ReadAll();

    IEnumerable<Car> GetCarsByDate(DateTime start, DateTime end);

    IEnumerable<Customer> GetCustomersByDate(DateTime date);

    IEnumerable<Rental> GetActiveRentals(DateTime date);
}
