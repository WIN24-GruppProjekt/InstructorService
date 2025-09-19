using Domain.Entities;

namespace Application.Interfaces;

public interface IInstructorRepository
{
    Task<IEnumerable<InstructorEntity>> GetAllAsync();
    Task<InstructorEntity?> GetByIdAsync(Guid id);
    Task<InstructorEntity> CreateAsync(InstructorEntity instructor);
    Task<InstructorEntity> UpdateAsync(InstructorEntity instructor);
    Task<bool> DeleteAsync(Guid id);
}
