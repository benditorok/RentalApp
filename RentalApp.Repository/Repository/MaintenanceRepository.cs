﻿using Microsoft.EntityFrameworkCore;
using RentalApp.Model;
using RentalApp.Repository.Context;
using System.Reflection;

namespace RentalApp.Repository.Repository;

public class MaintenanceRepository : Repository<Maintenance>
{
    public MaintenanceRepository(RentalAppDbContext ctx) : base(ctx)
    {
    }

    public override Maintenance Read(int id)
    {
        return ctx.Maintenances.FirstOrDefault(x => x.MaintenanceId == id) ?? null!;
    }

    public override void Update(Maintenance item)
    {
        var old = Read(item.MaintenanceId);

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

    public override async Task<Maintenance> ReadAsync(int id)
    {
        return await ctx.Maintenances.FirstOrDefaultAsync(x => x.MaintenanceId == id) ?? null!;
    }

    public override async Task UpdateAsync(Maintenance item)
    {
        var old = await ReadAsync(item.MaintenanceId);

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
