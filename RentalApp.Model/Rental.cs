﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentalApp.Model;

public class Rental : IEquatable<Rental>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RentalId { get; set; }

    [Required(ErrorMessage = "StartDate cannot be empty!")]
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal TotalCost { get; set; }

    [Required(ErrorMessage = "CustomerId cannot be null!")]
    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "CarId cannot be null!")]
    [ForeignKey(nameof(Car))]
    public int CarId { get; set; }

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

    public bool Equals(Rental? other)
    {
        return GetHashCode() == other?.GetHashCode();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(RentalId, StartDate, EndDate, TotalCost);
    }
}