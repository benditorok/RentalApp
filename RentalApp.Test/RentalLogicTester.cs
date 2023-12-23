using NUnit.Framework;
using RentalApp.Model;

namespace RentalApp.Test;

internal class RentalLogicTester : MockRepository
{
    [SetUp]
    public override void Setup() => base.Setup();

    [Test]
    public void GetCarsByDate()
    {
        var actual = rentalLogic?
            .GetCarsByDate(new DateTime(2020, 01, 01), new DateTime(2021, 09, 01));

        var expected = new List<Car>()
        {
            new Car(1, "make1", "model1", 2015, 100),
            new Car(2, "make2", "model2", 2016, 90),
            new Car(5, "make5", "model5", 2018, 50)
        };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void GetCustomersByDate()
    {
        var actual = rentalLogic?.GetCustomersByDate(new DateTime(2023, 10, 01));

        var expected = new List<Customer>()
        {
            new Customer(4, "f4", "l4", "c4@c.com", "+00932678322", "c4addr")
        };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void GetActiveRentals()
    {
        var actual = rentalLogic?.GetActiveRentals(new DateTime(2020, 11, 10));

        var expected = new List<Rental>()
        {
            new Rental(1,  new DateTime(2020, 01, 01),  new DateTime(2021, 02, 01), 1233, 1, 1),
            new Rental(4,  new DateTime(2020, 11, 01),  new DateTime(2020, 12, 01), 554, 2, 5)
        };

        Assert.That(actual, Is.EquivalentTo(expected));
    }
}
