using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalApp.Model;

public class Rental : IEquatable<Rental>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RentalId { get; set; }

    [Required(ErrorMessage = "StartDate cannot be empty!")]
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal TotalCost { get; set; } = 0m;

    [ForeignKey(nameof(Customer))]
    [Required(ErrorMessage = "CustomerId cannot be null!")]
    public int CustomerId { get; set; }

    [ForeignKey(nameof(Car))]
    [Required(ErrorMessage = "CarId cannot be null!")]
    public int CarId { get; set; }

    [NotMapped]
    public virtual Customer Customer { get; set; } = null!;

    [NotMapped]
    public virtual Car Car { get; set; } = null!;

    public Rental()
    {
    }

    public Rental(int rentalId, DateTime startDate, DateTime endDate, decimal totalCost, int customerId, int carId)
    {
        RentalId = rentalId;
        StartDate = startDate;
        EndDate = endDate;
        TotalCost = totalCost;
        CustomerId = customerId;
        CarId = carId;
    }

    public Rental(DateTime startDate, DateTime endDate, decimal totalCost, int customerId, int carId)
    {
        StartDate = startDate;
        EndDate = endDate;
        TotalCost = totalCost;
        CustomerId = customerId;
        CarId = carId;
    }

    public bool Equals(Rental? other)
    {
        return GetHashCode() == other?.GetHashCode();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(RentalId, StartDate, EndDate, TotalCost);
    }

    public override string ToString()
    {
        return $"RentalId: {RentalId}, StartDate: {StartDate}, EndDate: {EndDate}, TotalCost: {TotalCost}, CustomerId: {CustomerId}, CarId: {CarId}";
    }
}