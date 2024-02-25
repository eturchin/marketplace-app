using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Data.Persistent.Entities;

public class User
{
    [Required] 
    [Range(1, long.MaxValue)] 
    public long Id { get; set; }

    [Required] 
    [StringLength(35)] 
    public string FirstName { get; set; }

    [Required] 
    [StringLength(35)] 
    public string LastName { get; set; }

    [Required] 
    [StringLength(35)] 
    public string Login { get; set; }

    [Required] 
    public byte[] PasswordHash { get; set; }

    [Required] 
    public byte[] PasswordSalt { get; set; }

    [Required] [Range(1, 3)]
    public long RoleId { get; set; }

    [Required]
    [StringLength(35)]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string Email { get; set; }

    [Required] 
    public DateTime CreationDate { get; set; }

    [Required] 
    public DateTime LastModified { get; set; }

    [Required] 
    public bool IsActive { get; set; }

    public virtual Role? Role { get; set; }
}