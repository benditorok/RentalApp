using RentalApp.Model;
using RentalApp.Repository.Context;
using System.Reflection;

namespace RentalApp.Repository.Repository;

public class CarRepository : Repository<Car>
{
    public CarRepository(RentalAppDbContext ctx) : base(ctx)
    {
    }

    public override Car Read(int id)
    {
        return ctx.Cars.FirstOrDefault(x => x.CarId == id) ?? null!;
    }

    public override void Update(Car item)
    {
        var old = Read(item.CarId);

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
