using RentalApp.Model;

namespace RentalApp.Logic;

public interface ICarLogic
{
    void Create(Car item);

    Car Read(int id);

    void Update(Car item);

    void Delete(int id);

    IQueryable<Car> ReadAll();
}

