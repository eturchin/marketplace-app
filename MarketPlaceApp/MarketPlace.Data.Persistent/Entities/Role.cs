using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Data.Persistent.Entities;

public class Role
{
    [Required] [Range(1, 3)] public long Id { get; set; }

    [Required] [StringLength(35)] public string Name { get; set; }

    public virtual IEnumerable<User>? Users { get; set; }
}