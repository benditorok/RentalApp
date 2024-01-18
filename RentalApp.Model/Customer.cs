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
    [StringLength(40, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
    public string FirstName { get; set; } = String.Empty;

    [Required(ErrorMessage = "LastName cannot be empty!")]
    [StringLength(40, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
    public string LastName { get; set; } = String.Empty;

    [EmailAddress]
    [Required(ErrorMessage = "Email cannot be empty!")]
    [StringLength(320, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
    public string Email { get; set; } = String.Empty;

    [Phone]
    [Required(ErrorMessage = "Phone cannot be empty!")]
    [StringLength(15, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
    public string Phone { get; set; } = String.Empty;

    [StringLength(128, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
    public string? Address { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual ICollection<Rental>? Rentals { get; set; } = new HashSet<Rental>();

    public Customer()
    {
    }

    public Customer(int customerId, string firstName, string lastName, string email, string phone, string? address)
    {
        CustomerId = customerId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Address = address;
    }

    public Customer(string firstName, string lastName, string email, string phone, string? address)
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

    public override string ToString()
    {
        return $"CustomerId: {CustomerId}, FirstName: {FirstName}, LastName: {LastName}, Email: {Email}, Phone: {Phone}, Address: {Address}";
    }
}