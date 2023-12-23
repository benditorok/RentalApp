using NUnit.Framework;
using RentalApp.Model;

namespace RentalApp.Test;

internal class CarLogicTester : MockRepository
{
    [SetUp]
    public override void Setup() => base.Setup();

    [Test]
    public void GetCarsFromYear()
    {
        var actual = carLogic?.GetCarsFromYear(2018);

        var expected = new List<Car>()
        {
            new Car(4, "make4", "model4", 2018, 60),
            new Car(5, "make5", "model5", 2018, 50)
        };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void GetCarsByMake()
    {
        var actual = carLogic?.GetCarsByMake("make1");

        var expected = new List<Car>()
        {
            new Car(1, "make1", "model1", 2015, 100),
            new Car(3, "make1", "model3", 2017, 70)
        };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void GetMostExpensive()
    {
        var actual = carLogic?.GetMostExpensive(2);

        var expected = new List<Car>()
        {
            new Car(1, "make1", "model1", 2015, 100),
            new Car(2, "make2", "model2", 2016, 90)
        };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void GetLeastExpensive()
    {
        var actual = carLogic?.GetLeastExpensive();

        var expected = new List<Car>()
        {
            new Car(5, "make5", "model5", 2018, 50)
        };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void GetNotMaintained()
    {
        var actual = carLogic?.GetNotMaintained();

        var expected = new List<Car>()
        {
            new Car(2, "make2", "model2", 2016, 90),
            new Car(4, "make4", "model4", 2018, 60)
        };

        Assert.That(actual, Is.EquivalentTo(expected));
    }
}
