using Moq;
using RentalApp.Logic;
using RentalApp.Logic.Logic;
using RentalApp.Model;
using RentalApp.Repository;

namespace RentalApp.Test;

public class MockRepository
{
    protected ICarLogic? carLogic;
    protected Mock<IRepository<Car>>? carRepo;

    private List<Car> car = new()
        {
            new Car(1, "make1", "model1", 2015, 100),
            new Car(2, "make2", "model2", 2016, 90),
            new Car(3, "make3", "model3", 2017, 70),
            new Car(4, "make4", "model4", 2018, 60),
            new Car(5, "make5", "model5", 2018, 50),
        };

    public virtual void Setup()
    {
        carRepo = new Mock<IRepository<Car>>();

        // Navigation properties


        // Mock repositories
        carRepo.Setup(x => x.ReadAll())
            .Returns(car.AsQueryable());

        // Logic setup
        carLogic = new CarLogic(carRepo.Object);
    }
}
