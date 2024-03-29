﻿using Microsoft.EntityFrameworkCore;
using RentalApp.Model;
using RentalApp.Repository.Context;
using System.Reflection;

namespace RentalApp.Repository.Repository;

public class CustomerRepository : Repository<Customer>
{
    public CustomerRepository(RentalAppDbContext ctx) : base(ctx)
    {
    }

    public override Customer Read(int id)
    {
        return ctx.Customers.FirstOrDefault(x => x.CustomerId == id) ?? null!;
    }

    public override void Update(Customer item)
    {
        var old = Read(item.CustomerId);

        foreach (PropertyInfo prop in old.GetType().GetProperties())
        {
            // Do not update navigation properties and keys
            // Removed parameter: (!prop.Name.Contains("Id") &&)
            if (prop.GetAccessors().FirstOrDefault(x => x.IsVirtual) == null)
            {
                prop.SetValue(old, prop.GetValue(item));
            }
        }

        ctx.SaveChanges();
    }

    public override async Task<Customer> ReadAsync(int id)
    {
        return await ctx.Customers.FirstOrDefaultAsync(x => x.CustomerId == id) ?? null!;
    }

    public override async Task UpdateAsync(Customer item)
    {
        var old = await ReadAsync(item.CustomerId);

        foreach (PropertyInfo prop in old.GetType().GetProperties())
        {
            // Do not update navigation properties and keys
            if (!prop.Name.Contains("id") && prop.GetAccessors().FirstOrDefault(x => x.IsVirtual) == null)
            {
                prop.SetValue(old, prop.GetValue(item));
            }
        }

        await ctx.SaveChangesAsync();
    }
}
