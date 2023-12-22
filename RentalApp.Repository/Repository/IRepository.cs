using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalApp.Repository.Repository;

/// <summary>
/// Interface for genereic CRUD functions.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T : class
{
    void Create(T item);

    T Read(int id);

    void Update(T item);

    void Delete(int id);

    IQueryable<T> ReadAll();
}
