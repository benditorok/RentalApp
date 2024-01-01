using NUnit.Framework;
using RentalApp.Model;

namespace RentalApp.Test;

internal class CustomerLogicTester : MockRepository
{
    [Test]
    public void GetCustomerByName()
    {
        var actual = customerLogic.GetCustomersByName("f4", "l4");

        var expected = new List<Customer>()
        {
            new Customer(4, "f4", "l4", "c4@c.com", "+00932678322", "c4addr")
        };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public async Task GetCustomerByNameAsync()
    {
        var actual = await customerLogic.GetCustomersByNameAsync("f4", "l4");

        var expected = new List<Customer>()
        {
            new Customer(4, "f4", "l4", "c4@c.com", "+00932678322", "c4addr")
        };

        Assert.That(actual, Is.EquivalentTo(expected));
    }
}
