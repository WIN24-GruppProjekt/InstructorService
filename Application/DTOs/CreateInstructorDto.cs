using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class CreateInstructorDto
{
    [StringLength(50, ErrorMessage = "First name must be less than 50 characters")]
    [Required(ErrorMessage = "First name is required")]
    [MinLength(2, ErrorMessage = "First name must be at least 2 characters")]
    public string FirstName { get; set; } = null!;

    [StringLength(50, ErrorMessage = "Last name must be less than 50 characters")]
    [Required(ErrorMessage = "Last name is required")]
    [MinLength(2, ErrorMessage = "Last name must be at least 2 characters")]
    public string LastName { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Invalid email address")]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = null!;

    [Phone(ErrorMessage = "Invalid phone number")]
    [Required(ErrorMessage = "Phone is required")]
    public string Phone { get; set; } = null!;

    [Required(ErrorMessage = "Location is required")]
    [StringLength(100, ErrorMessage = "Location must be less than 100 characters")]
    public string Location { get; set; } = null!;

    public string? ProfilePicture { get; set; }

    public bool IsActive { get; set; } = true;
}
