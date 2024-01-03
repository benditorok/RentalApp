using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalApp.Model;

public class Rental : IEquatable<Rental>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Range(1, int.MaxValue, ErrorMessage = "Id for {0} must be between {1} and {2}.")]
    public int RentalId { get; set; }

    [Required(ErrorMessage = "StartDate cannot be empty!")]
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal TotalCost { get; set; } = 0m;

    [Required(ErrorMessage = "CustomerId cannot be null!")]
    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "CarId cannot be null!")]
    [ForeignKey(nameof(Car))]
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