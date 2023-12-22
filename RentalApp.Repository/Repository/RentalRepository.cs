﻿using RentalApp.Model;
using RentalApp.Repository.Context;
using System.Reflection;

namespace RentalApp.Repository.Repository;

public class RentalRepository : Repository<Rental>
{
    public RentalRepository(RentalAppDbContext ctx) : base(ctx)
    {
    }

    public override Rental Read(int id)
    {
        return ctx.Rentals.FirstOrDefault(x => x.RentalId == id) ?? null!;
    }

    public override void Update(Rental item)
    {
        var old = Read(item.RentalId);

        foreach (PropertyInfo prop in old.GetType().GetProperties())
        {
            // Do not update navigation properties and keys
            if (!prop.Name.Contains("id") && prop.GetAccessors().FirstOrDefault(x => x.IsVirtual) == null)
            {
                prop.SetValue(old, prop.GetValue(item));
            }
        }

        ctx.SaveChanges();
    }
}
