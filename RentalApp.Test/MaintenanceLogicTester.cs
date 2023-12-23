using NUnit.Framework;
using RentalApp.Model;

namespace RentalApp.Test;

internal class MaintenanceLogicTester : MockRepository
{
    [SetUp]
    public override void Setup() => base.Setup();

    [Test]
    public void GetByDate()
    {
        var actual = maintenanceLogic?.GetByDate(new DateTime(2021, 07, 01));

        var expected = new List<Maintenance>()
        {
            new Maintenance(3, new DateTime(2021, 07, 01), "Tire change", 3310, 3)
        };

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetUsingKeyword()
    {
        var actual = maintenanceLogic?.GetUsingKeyword("oil");

        var expected = new List<Maintenance>()
        {
            new Maintenance(2, new DateTime(2022, 02, 01), "Oil change", 1234, 1),
            new Maintenance(4, new DateTime(2020, 10, 01), "Oil change", 213, 5)
        };

        Assert.That(actual, Is.EqualTo(expected));
    }
}
