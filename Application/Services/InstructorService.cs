using Application.DTOs;
using Application.Interfaces;
using Application.Models;
using Domain.Entities;

namespace Application.Services;

public class InstructorService(IInstructorRepository instructorRepository) : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository = instructorRepository;

    public async Task<IEnumerable<InstructorDto>> GetAllInstructorsAsync()
    {
        var instructors = await _instructorRepository.GetAllAsync();
        return instructors.Select(MapToDto);
    }

    public async Task<InstructorDto?> GetInstructorByIdAsync(Guid id)
    {
        var instructor = await _instructorRepository.GetByIdAsync(id);
        return instructor == null ? null : MapToDto(instructor);
    }

    public async Task<InstructorDto> CreateInstructorAsync(CreateInstructorDto createInstructorDto)
    {
        var entity = MapToEntity(createInstructorDto);
        var createdEntity = await _instructorRepository.CreateAsync(entity);
        return MapToDto(createdEntity);
    }

    public async Task<InstructorDto?> UpdateInstructorAsync(
        Guid id,
        UpdateInstructorDto updateInstructorDto
    )
    {
        var existingInstructor = await _instructorRepository.GetByIdAsync(id);
        if (existingInstructor == null)
            return null;

        // Update properties
        existingInstructor.FirstName = updateInstructorDto.FirstName;
        existingInstructor.LastName = updateInstructorDto.LastName;
        existingInstructor.Email = updateInstructorDto.Email;
        existingInstructor.Phone = updateInstructorDto.Phone;
        existingInstructor.Location = updateInstructorDto.Location;
        existingInstructor.ProfilePicture = updateInstructorDto.ProfilePicture;
        existingInstructor.IsActive = updateInstructorDto.IsActive;

        var updatedEntity = await _instructorRepository.UpdateAsync(existingInstructor);
        return MapToDto(updatedEntity);
    }

    public async Task<bool> DeleteInstructorAsync(Guid id)
    {
        return await _instructorRepository.DeleteAsync(id);
    }

    private static InstructorDto MapToDto(InstructorEntity entity)
    {
        return new InstructorDto
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            Phone = entity.Phone,
            Location = entity.Location,
            ProfilePicture = entity.ProfilePicture,
            IsActive = entity.IsActive,
            CreatedAt = entity.CreatedAt,
        };
    }

    private static InstructorEntity MapToEntity(CreateInstructorDto dto)
    {
        return new InstructorEntity
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            Location = dto.Location,
            ProfilePicture = dto.ProfilePicture,
            IsActive = dto.IsActive,
        };
    }
}
