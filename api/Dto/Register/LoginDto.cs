using System.ComponentModel.DataAnnotations;

namespace api.Dto.Register;

public class LoginDto
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
}