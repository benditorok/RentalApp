using RentalApp.Model;

namespace RentalApp.Logic;

public interface IMaintenanceLogic
{
    void Create(Maintenance item);

    Maintenance Read(int id);

    void Update(Maintenance item);

    void Delete(int id);

    IEnumerable<Maintenance> ReadAll();

    IEnumerable<Maintenance> GetByDate(DateTime date);

    IEnumerable<Maintenance> GetUsingKeyword(string keyword);

    Task CreateAsync(Maintenance item);

    Task<Maintenance> ReadAsync(int id);

    Task UpdateAsync(Maintenance item);

    Task DeleteAsync(int id);

    Task<IEnumerable<Maintenance>> ReadAllAsync();

    Task<IEnumerable<Maintenance>> GetByDateAsync(DateTime date);

    Task<IEnumerable<Maintenance>> GetUsingKeywordAsync(string keyword);
}

