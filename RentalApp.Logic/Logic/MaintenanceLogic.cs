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
        var maintenance = repo.Read(item.MaintenanceId);

        if (maintenance == null)
        {
            repo.Create(item);
        }
        else
        {
            throw new ArgumentException($"MaintenanceRecord({item.MaintenanceId}) already exists! " +
                $"Use update or delete before creating MaintenanceRecord({item.MaintenanceId})!");
        }
    }

    public Maintenance Read(int id)
    {
        var maintenance = repo.Read(id);

        if (maintenance != null)
        {
            return maintenance;
        }
        else
        {
            throw new ArgumentException($"MaintenanceRecord({id}) does not exist!");
        }
    }

    public void Update(Maintenance item)
    {
        var maintenance = repo.Read(item.MaintenanceId);

        if (maintenance != null)
        {
            repo.Update(item);
        }
        else
        {
            throw new ArgumentException($"MaintenanceRecord({item.MaintenanceId}) does not exist!");
        }
    }

    public void Delete(int id)
    {
        var maintenance = repo.Read(id);

        if (maintenance != null)
        {
            repo.Delete(id);
        }
        else
        {
            throw new ArgumentException($"MaintenanceRecord({id}) does not exist!");
        }
    }

    public IEnumerable<Maintenance> ReadAll()
    {
        return repo.ReadAll();
    }

    /// <summary>
    /// Get maintenances done on the specified date.
    /// </summary>
    /// <param name="date">Date</param>
    /// <returns></returns>
    public IEnumerable<Maintenance> GetByDate(DateTime date)
    {
        return repo.ReadAll()
            .Where(x => x.Date.Date == date.Date);
    }

    /// <summary>
    /// Get maintenances by a keyword in their description. Case insensitive.
    /// </summary>
    /// <param name="keyword">Keyword</param>
    /// <returns></returns>
    public IEnumerable<Maintenance> GetUsingKeyword(string keyword)
    {
        return repo.ReadAll()
            .Where(x => x.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase));
    }
}
