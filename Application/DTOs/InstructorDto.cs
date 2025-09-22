namespace Application.DTOs;

/// <summary>
/// Response DTO for returning instructor data
/// </summary>
public class InstructorDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string InstructorName => $"{FirstName} {LastName}";
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string? ProfilePicture { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}
