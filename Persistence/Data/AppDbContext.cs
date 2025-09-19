using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<InstructorEntity> Instructors { get; set; } = null!;
}
