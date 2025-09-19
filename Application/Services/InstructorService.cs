using Application.DTOs;
using Application.Interfaces;
using Application.Models;
using Domain.Entities;

namespace Application.Services;

public class InstructorService(IInstructorRepository instructorRepository)
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

    public async Task<InstructorDto> CreateInstructorAsync(InstructorDto instructorDto)
    {
        var entity = MapToEntity(instructorDto);
        var createdEntity = await _instructorRepository.CreateAsync(entity);
        return MapToDto(createdEntity);
    }

    public async Task<InstructorDto?> UpdateInstructorAsync(Guid id, InstructorDto instructorDto)
    {
        var existingInstructor = await _instructorRepository.GetByIdAsync(id);
        if (existingInstructor == null)
            return null;

        // Update properties
        existingInstructor.FirstName = instructorDto.FirstName;
        existingInstructor.LastName = instructorDto.LastName;
        existingInstructor.Email = instructorDto.Email;
        existingInstructor.Phone = instructorDto.Phone;
        existingInstructor.Location = instructorDto.Location;
        existingInstructor.ProfilePicture = instructorDto.ProfilePicture;
        existingInstructor.IsActive = instructorDto.IsActive;

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

    private static InstructorEntity MapToEntity(InstructorDto dto)
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
