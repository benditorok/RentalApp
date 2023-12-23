using RentalApp.Model;

namespace RentalApp.Logic;

public interface IMaintenanceLogic
{
    void Create(Maintenance item);

    Maintenance Read(int id);

    void Update(Maintenance item);

    void Delete(int id);

    IQueryable<Maintenance> ReadAll();
}

