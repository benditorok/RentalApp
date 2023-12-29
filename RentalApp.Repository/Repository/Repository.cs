using RentalApp.Repository.Context;
using System;
using System.Linq;

namespace RentalApp.Repository.Repository;

/// <summary>
/// Generic abstract repository implementing CRUD functions.
/// </summary>
public abstract class Repository<T> : IRepository<T> where T : class
{
    protected RentalAppDbContext ctx;

    public Repository(RentalAppDbContext ctx)
    {
        this.ctx = ctx;
    }

    public void Create(T item)
    {
        ctx.Set<T>().Add(item);
        ctx.SaveChanges();
    }

    public abstract T Read(int id);

    public abstract void Update(T item);

    public void Delete(int id)
    {
        ctx.Set<T>().Remove(Read(id));
        ctx.SaveChanges();
    }

    public IEnumerable<T> ReadAll()
    {
        return ctx.Set<T>().ToList();
    }
}
