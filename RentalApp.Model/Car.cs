using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RentalApp.Model;

public class Car : IEquatable<Car>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CarId { get; set; }

    [Required(ErrorMessage = "Make cannot be empty!")]
    public string? Make { get; set; }

    [Required(ErrorMessage = "Model cannot be empty!")]
    public string? Model { get; set; }

    [Required(ErrorMessage = "Year cannot be empty!")]
    public int Year { get; set; }

    [Required(ErrorMessage = "DailyCost cannot be empty!")]
    public decimal DailyCost { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual ICollection<Rental> Rentals { get; set; }

    [NotMapped]
    public virtual ICollection<Maintenance> Maintenances { get; set; }

    public Car()
    {
        Rentals = new HashSet<Rental>();
        Maintenances = new HashSet<Maintenance>();
    }

    public Car(int carId, string? make, string? model, int year, decimal dailyCost)
    {
        CarId = carId;
        Make = make;
        Model = model;
        Year = year;
        DailyCost = dailyCost;
        Rentals = new HashSet<Rental>();
        Maintenances = new HashSet<Maintenance>();
    }

    public bool Equals(Car? other)
    {
        return GetHashCode() == other?.GetHashCode();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CarId, Make, Model, Year, DailyCost);
    }
}
