using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RentalApp.Model;

public class Customer : IEquatable<Customer>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "FirstName cannot be empty!")]
    public string FirstName { get; set; } = String.Empty;

    [Required(ErrorMessage = "LastName cannot be empty!")]
    public string LastName { get; set; } = String.Empty;

    [EmailAddress]
    [Required(ErrorMessage = "Email cannot be empty!")]
    public string Email { get; set; } = String.Empty;

    [Phone]
    [Required(ErrorMessage = "Phone cannot be empty!")]
    public string Phone { get; set; } = String.Empty;

    public string Address { get; set; } = String.Empty;

    [NotMapped]
    [JsonIgnore]
    public virtual ICollection<Rental> Rentals { get; set; } = new HashSet<Rental>();

    private Customer()
    {
    }

    public Customer(int customerId, string firstName, string lastName, string email, string phone, string address)
    {
        CustomerId = customerId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Address = address;
    }

    public Customer(string firstName, string lastName, string email, string phone, string address)
    {
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
