using System.Linq.Expressions;

namespace RentalApp.Repository;

/// <summary>
/// Interface for genereic CRUD functions.
/// </summary>
/// <typeparam name="T">Model class</typeparam>
public interface IRepository<T> where T : class
{
    void Create(T item);

    T Read(int id);

    void Update(T item);

    void Delete(int id);

    IQueryable<T> ReadAll();

    Task CreateAsync(T item);

    Task<T> ReadAsync(int id);

    Task UpdateAsync(T item);

    Task DeleteAsync(int id);
}
