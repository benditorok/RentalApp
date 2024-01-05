using Microsoft.EntityFrameworkCore;
using RentalApp.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

    /// <summary>
    /// Exposes the DbSet of this type.
    /// </summary>
    /// <returns></returns>
    public IQueryable<T> ReadAll()
    {
        return ctx.Set<T>().AsQueryable();
    }

    public async Task CreateAsync(T item)
    {
        await ctx.Set<T>().AddAsync(item);
        await ctx.SaveChangesAsync();
    }

    public abstract Task<T> ReadAsync(int id);

    public abstract Task UpdateAsync(T item);

    public async Task DeleteAsync(int id)
    {
        var item = await ReadAsync(id);
        ctx.Set<T>().Remove(item);
        await ctx.SaveChangesAsync();
    }
}
