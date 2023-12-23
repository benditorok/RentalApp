﻿using NUnit.Framework;
using RentalApp.Model;

namespace RentalApp.Test;

internal class CustomerLogicTester : MockRepository
{
    [SetUp]
    public override void Setup() => base.Setup();

    [Test]
    public void GetCustomerByName()
    {
        var actual = customerLogic?.GetCustomersByName("f4", "l4");

        var expected = new List<Customer>()
        {
            new Customer(4, "f4", "l4", "c4@c.com", "+00932678322", "c4addr")
        };

        Assert.That(actual, Is.EquivalentTo(expected));
    }
}
