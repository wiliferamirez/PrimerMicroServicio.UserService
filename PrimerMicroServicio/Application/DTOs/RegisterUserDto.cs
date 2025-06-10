using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrimerMicroServicio.Application.DTOs;

public class RegisterUserDto
{
    [Required]
    [StringLength(10)]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Only numeric characters allowed")]
    public string CedulaUser { get; set; }
    [Required]
    [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "Numeric characters not allowed")]
    public string UserFirstName { get; set; }
    [Required]
    [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "Numeric characters not allowed")]
    public string UserLastName { get; set; }
    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    public string UserPasswordHash { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "Email address not valid")]
    public string UserEmail { get; set; }
}