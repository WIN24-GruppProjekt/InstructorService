using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class InstructorRepository(AppDbContext context) : IInstructorRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<InstructorEntity>> GetAllAsync()
    {
        return await _context.Instructors.ToListAsync();
    }

    public async Task<InstructorEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Instructors.FindAsync(id);
    }

    public async Task<InstructorEntity> CreateAsync(InstructorEntity instructor)
    {
        _context.Instructors.Add(instructor);
        await _context.SaveChangesAsync();
        return instructor;
    }

    public async Task<InstructorEntity> UpdateAsync(InstructorEntity instructor)
    {
        _context.Instructors.Update(instructor);
        await _context.SaveChangesAsync();
        return instructor;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var instructor = await _context.Instructors.FindAsync(id);
        if (instructor == null)
            return false;

        _context.Instructors.Remove(instructor);
        await _context.SaveChangesAsync();
        return true;
    }
}
