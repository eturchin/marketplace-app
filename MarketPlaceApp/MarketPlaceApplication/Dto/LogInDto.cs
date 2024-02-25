using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Application.Dto;

public class LogInDto
{
    [Required]
    [StringLength(35)]
    public string Login { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}