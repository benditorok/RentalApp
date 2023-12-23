using Moq;
using RentalApp.Logic;
using RentalApp.Logic.Logic;
using RentalApp.Model;
using RentalApp.Repository;

namespace RentalApp.Test;

public class MockRepository
{
    protected ICarLogic? carLogic;
    private Mock<IRepository<Car>>? carRepo;

    protected ICustomerLogic? customerLogic;
    private Mock<IRepository<Customer>>? customerRepo;

    protected IMaintenanceLogic? maintenanceLogic;
    private Mock<IRepository<Maintenance>>? maintenanceRepo;

    protected IRentalLogic? rentalLogic;
    private Mock<IRepository<Rental>>? rentalRepo;

    private static List<Car> cars = new()
    {
        new Car(1, "make1", "model1", 2015, 100),
        new Car(2, "make2", "model2", 2016, 90),
        new Car(3, "make1", "model3", 2017, 70),
        new Car(4, "make4", "model4", 2018, 60),
        new Car(5, "make5", "model5", 2018, 50)
    };

    private static List<Customer> customers = new()
    {
        new Customer(1, "f1", "l1", "c1@c.com", "+00121233134", "c1addr"),
        new Customer(2, "f2", "l2", "c2@c.com", "+00123547633", "c2addr"),
        new Customer(3, "f3", "l3", "c3@c.com", "+00843454543", "c3addr"),
        new Customer(4, "f4", "l4", "c4@c.com", "+00932678322", "c4addr"),
        new Customer(5, "f5", "l5", "c5@c.com", "+00993436872", "c5addr")
    };

    private static List<Maintenance> maintenances = new()
    {
        new Maintenance(1, new DateTime(2020, 01, 01), "Battery change", 5400, 1),
        new Maintenance(2, new DateTime(2022, 02, 01), "Oil change", 1234, 1),
        new Maintenance(3, new DateTime(2021, 07, 01), "Tire change", 3310, 3),
        new Maintenance(4, new DateTime(2020, 10, 01), "Oil change", 213, 5),
        new Maintenance(5, new DateTime(2022, 06, 01), "Battery change", 6674, 5)
    };

    private static List<Rental> rentals = new()
    {
        new Rental(1,  new DateTime(2020, 01, 01),  new DateTime(2020, 02, 01), 1233, 1, 1),
        new Rental(2,  new DateTime(2021, 07, 01),  new DateTime(2021, 09, 01), 1254, 1, 2),
        new Rental(3,  new DateTime(2022, 06, 01),  new DateTime(2023, 01, 01), 123, 3, 4),
        new Rental(4,  new DateTime(2020, 11, 01),  new DateTime(2020, 12, 01), 554, 2, 5),
        new Rental(5,  new DateTime(2023, 10, 01),  new DateTime(2023, 11, 01), 2100, 4, 3)
    };

    public virtual void Setup()
    {
        carRepo = new();
        customerRepo = new();
        maintenanceRepo = new();
        rentalRepo = new();

        // Navigation properties
        cars.ForEach(x => x.Maintenances = maintenances.FindAll(y => y.CarId == x.CarId) ?? null!);
        maintenances.ForEach(x => x.Car = cars.Find(y => y.CarId == x.CarId) ?? null!);

        rentals.ForEach(x => x.Customer = customers.Find(y => y.CustomerId == x.CustomerId) ?? null!);
        rentals.ForEach(x => x.Car = cars.Find(y => y.CarId == x.CarId) ?? null!);

        customers.ForEach(x => x.Rentals = rentals.FindAll(y => y.CustomerId == x.CustomerId) ?? null!);
        cars.ForEach(x => x.Rentals = rentals.FindAll(y => y.CarId == x.CarId) ?? null!);


        // Mock repositories
        carRepo.Setup(x => x.ReadAll())
            .Returns(cars.AsQueryable());

        customerRepo.Setup(x => x.ReadAll())
            .Returns(customers.AsQueryable());

        maintenanceRepo.Setup(x => x.ReadAll())
            .Returns(maintenances.AsQueryable());

        rentalRepo.Setup(x => x.ReadAll())
            .Returns(rentals.AsQueryable());

        // Logic setup
        carLogic = new CarLogic(carRepo.Object);
        customerLogic = new CustomerLogic(customerRepo.Object);
        maintenanceLogic = new MaintenanceLogic(maintenanceRepo.Object);
        rentalLogic = new RentalLogic(rentalRepo.Object);
    }
}
