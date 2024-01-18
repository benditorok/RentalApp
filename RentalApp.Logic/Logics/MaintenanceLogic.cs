using Microsoft.EntityFrameworkCore;
using RentalApp.Model;
using RentalApp.Repository;
using RentalApp.Logic.Utilities;

namespace RentalApp.Logic.Logics;

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
            item.Date = item.Date.SpecifyKindUTC();

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
            item.Date = item.Date.SpecifyKindUTC();

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
        return repo.ReadAll().ToList();
    }

    /// <summary>
    /// Get maintenances done on the specified date.
    /// </summary>
    /// <param name="date">Date</param>
    /// <returns></returns>
    public IEnumerable<Maintenance> GetByDate(DateTime date)
    {
        return repo.ReadAll()
            .Where(x => x.Date.Date == date.Date)
            .ToList();
    }

    /// <summary>
    /// Get maintenances by a keyword in their description. Case insensitive.
    /// </summary>
    /// <param name="keyword">Keyword</param>
    /// <returns></returns>
    public IEnumerable<Maintenance> GetUsingKeyword(string keyword)
    {
        return repo.ReadAll()
            .Where(x => x.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public async Task CreateAsync(Maintenance item)
    {
        var maintenance = await repo.ReadAsync(item.MaintenanceId);

        if (maintenance == null)
        {
            item.Date = item.Date.SpecifyKindUTC();

            await repo.CreateAsync(item);
        }
        else
        {
            throw new ArgumentException($"MaintenanceRecord({item.MaintenanceId}) already exists! " +
                $"Use update or delete before creating MaintenanceRecord({item.MaintenanceId})!");
        }
    }

    public async Task<Maintenance> ReadAsync(int id)
    {
        var maintenance = await repo.ReadAsync(id);

        if (maintenance != null)
        {
            return maintenance;
        }
        else
        {
            throw new ArgumentException($"MaintenanceRecord({id}) does not exist!");
        }
    }

    public async Task UpdateAsync(Maintenance item)
    {
        var maintenance = await repo.ReadAsync(item.MaintenanceId);

        if (maintenance != null)
        {
            item.Date = item.Date.SpecifyKindUTC();

            await repo.UpdateAsync(item);
        }
        else
        {
            throw new ArgumentException($"MaintenanceRecord({item.MaintenanceId}) does not exist!");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var maintenance = await repo.ReadAsync(id);

        if (maintenance != null)
        {
            await repo.DeleteAsync(id);
        }
        else
        {
            throw new ArgumentException($"MaintenanceRecord({id}) does not exist!");
        }
    }

    public async Task<IEnumerable<Maintenance>> ReadAllAsync()
    {
        return await repo.ReadAll()
            .ToListAsync();
    }

    /// <summary>
    /// Get maintenances done on the specified date.
    /// </summary>
    /// <param name="date">Date</param>
    /// <returns></returns>
    public async Task<IEnumerable<Maintenance>> GetByDateAsync(DateTime date)
    {
        return await repo.ReadAll()
            .Where(x => x.Date.Date == date.Date)
            .ToListAsync();
    }

    /// <summary>
    /// Get maintenances by a keyword in their description. Case insensitive.
    /// </summary>
    /// <param name="keyword">Keyword</param>
    /// <returns></returns>
    public async Task<IEnumerable<Maintenance>> GetUsingKeywordAsync(string keyword)
    {
        return await repo.ReadAll()
            .Where(x => x.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }
}
