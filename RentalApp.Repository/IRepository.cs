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

    IEnumerable<T> ReadAll();
}
