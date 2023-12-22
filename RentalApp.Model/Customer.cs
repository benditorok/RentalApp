using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RentalApp.Model;

public class Customer : IEquatable<Customer>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "FirstName cannot be empty!")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "LastName cannot be empty!")]
    public string? LastName { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email cannot be empty!")]
    public string? Email { get; set; }

    [Phone]
    [Required(ErrorMessage = "Phone cannot be empty!")]
    public string? Phone { get; set; }

    public string? Address { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual ICollection<Rental> Rentals { get; set; } = new HashSet<Rental>();

    public Customer()
    {
    }

    public Customer(int customerId, string? firstName, string? lastName, string? email, string? phone, string? address)
    {
        CustomerId = customerId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Address = address;
    }

    public bool Equals(Customer? other)
    {
        return GetHashCode() == other?.GetHashCode();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CustomerId, FirstName, LastName, Email, Phone, Address);
    }
}
