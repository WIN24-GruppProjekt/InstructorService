using Application.DTOs;

namespace Application.Interfaces;

public interface IInstructorService
{
    Task<IEnumerable<InstructorDto>> GetAllInstructorsAsync();
    Task<InstructorDto?> GetInstructorByIdAsync(Guid id);
    Task<InstructorDto> CreateInstructorAsync(InstructorDto instructorDto);
    Task<InstructorDto?> UpdateInstructorAsync(Guid id, InstructorDto instructorDto);
    Task<bool> DeleteInstructorAsync(Guid id);
}
