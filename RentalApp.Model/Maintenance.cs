using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalApp.Model;

public class Maintenance : IEquatable<Maintenance>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaintenanceId { get; set; }

    [Required(ErrorMessage = "Date cannot be empty!")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Description cannot be empty!")]
    [StringLength(256, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
    public string Description { get; set; } = String.Empty;

    public decimal Cost { get; set; } = 0m;

    [ForeignKey(nameof(Car))]
    [Required(ErrorMessage = "CarId cannot be empty!")]
    public int CarId { get; set; }

    [NotMapped]
    public virtual Car Car { get; set; } = null!;

    public Maintenance()
    {
    }

    public Maintenance(int maintenanceId, DateTime date, string description, decimal cost, int carId)
    {
        MaintenanceId = maintenanceId;
        Date = date;
        Description = description;
        Cost = cost;
        CarId = carId;
    }

    public Maintenance(DateTime date, string description, decimal cost, int carId)
    {
        Date = date;
        Description = description;
        Cost = cost;
        CarId = carId;
    }

    public bool Equals(Maintenance? other)
    {
        return GetHashCode() == other?.GetHashCode();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(MaintenanceId, Date, Description, CarId);
    }

    public override string ToString()
    {
        return $"MaintenanceId: {MaintenanceId}, Date: {Date}, Description: {Description}, Cost: {Cost}, CarId:{Car}";
    }
}
