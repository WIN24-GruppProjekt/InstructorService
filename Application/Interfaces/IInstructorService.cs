using Application.DTOs;

namespace Application.Interfaces;

public interface IInstructorService
{
    Task<IEnumerable<InstructorDto>> GetAllInstructorsAsync();
    Task<InstructorDto?> GetInstructorByIdAsync(Guid id);
    Task<InstructorDto> CreateInstructorAsync(CreateInstructorDto createInstructorDto);
    Task<InstructorDto?> UpdateInstructorAsync(Guid id, UpdateInstructorDto updateInstructorDto);
    Task<bool> DeleteInstructorAsync(Guid id);
}
