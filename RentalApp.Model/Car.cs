using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RentalApp.Model;

public class Car : IEquatable<Car>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CarId { get; set; }

    [Required(ErrorMessage = "Make cannot be empty!")]
    [StringLength(40, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
    public string Make { get; set; } = String.Empty;

    [Required(ErrorMessage = "Model cannot be empty!")]
    [StringLength(40, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
    public string Model { get; set; } = String.Empty;

    [Required(ErrorMessage = "Year cannot be empty!")]
    [Range(1990, int.MaxValue, ErrorMessage = "Year for {0} must be at least {1}.")]
    public int Year { get; set; }

    [Required(ErrorMessage = "DailyCost cannot be empty!")]
    [Range(typeof(decimal), "10.0", "999.99", ErrorMessage = "DailyCost for {0} must be between {1} and {2}.")]
    public decimal DailyCost { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual ICollection<Rental> Rentals { get; set; } = new HashSet<Rental>();

    [NotMapped]
    public virtual ICollection<Maintenance> Maintenances { get; set; } = new HashSet<Maintenance>();

    public Car()
    {
    }

    public Car(int carId, string make, string model, int year, decimal dailyCost)
    {
        CarId = carId;
        Make = make;
        Model = model;
        Year = year;
        DailyCost = dailyCost;
    }

    public Car(string make, string model, int year, decimal dailyCost)
    {
        Make = make;
        Model = model;
        Year = year;
        DailyCost = dailyCost;
    }

    public bool Equals(Car? other)
    {
        return GetHashCode() == other?.GetHashCode();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CarId, Make, Model, Year, DailyCost);
    }

    public override string ToString()
    {
        return $"CarId: {CarId}, Make: {Make}, Model: {Model}, Year: {Year}, DailyCost: {DailyCost}";
    }
}
