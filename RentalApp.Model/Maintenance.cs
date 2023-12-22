using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalApp.Model;

public class Maintenance : IEquatable<Maintenance>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaintenanceId { get; set; }

    [Required(ErrorMessage = "Date cannot be empty!")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Description cannot be empty!")]
    public string? Description { get; set; }

    public decimal Cost { get; set; }

    [ForeignKey(nameof(Car))]
    [Required(ErrorMessage = "CarId cannot be empty!")]
    public int CarId { get; set; }

    [NotMapped]
    public virtual Car Car { get; set; } = null!;

    public Maintenance()
    {
    }

    public Maintenance(int maintenanceId, DateTime date, string? description, decimal cost, int carId)
    {
        MaintenanceId = maintenanceId;
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
}
