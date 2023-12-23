using RentalApp.Model;
using RentalApp.Repository;

namespace RentalApp.Logic.Logic;

public class MaintenanceLogic : IMaintenanceLogic
{
    private IRepository<Maintenance> repo;

    public MaintenanceLogic(IRepository<Maintenance> repo)
    {
        this.repo = repo;
    }

    public void Create(Maintenance item)
    {
        throw new NotImplementedException();
    }

    public Maintenance Read(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Maintenance item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Maintenance> ReadAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Maintenance> GetByDate(DateTime date)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Maintenance> GetUsingKeyword(string keyword)
    {
        throw new NotImplementedException();
    }
}
