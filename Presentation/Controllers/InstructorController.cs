using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstructorController(IInstructorService instructorService) : ControllerBase
{
    private readonly IInstructorService _instructorService = instructorService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InstructorDto>>> GetAllInstructors()
    {
        var instructors = await _instructorService.GetAllInstructorsAsync();
        return Ok(instructors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<InstructorDto>> GetInstructor(Guid id)
    {
        var instructor = await _instructorService.GetInstructorByIdAsync(id);
        if (instructor == null)
        {
            return NotFound($"Instructor with ID {id} not found");
        }
        return Ok(instructor);
    }

    [HttpPost]
    public async Task<ActionResult<InstructorDto>> CreateInstructor(
        [FromBody] CreateInstructorDto createInstructorDto
    )
    {
        // VALIDATION - This is the core of Issue #9
        if (!ModelState.IsValid)
        {
            var errors = ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return BadRequest(
                new
                {
                    Message = "Validation failed. Please check your input data.",
                    Errors = errors,
                }
            );
        }

        try
        {
            var createdInstructor = await _instructorService.CreateInstructorAsync(
                createInstructorDto
            );
            return CreatedAtAction(
                nameof(GetInstructor),
                new { id = createdInstructor.Id },
                createdInstructor
            );
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = "Failed to create instructor", Error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<InstructorDto>> UpdateInstructor(
        Guid id,
        [FromBody] UpdateInstructorDto updateInstructorDto
    )
    {
        // VALIDATION - This is the core of Issue #9
        if (!ModelState.IsValid)
        {
            var errors = ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return BadRequest(
                new
                {
                    Message = "Validation failed. Please check your input data.",
                    Errors = errors,
                }
            );
        }

        try
        {
            var updatedInstructor = await _instructorService.UpdateInstructorAsync(
                id,
                updateInstructorDto
            );
            if (updatedInstructor == null)
            {
                return NotFound($"Instructor with ID {id} not found");
            }
            return Ok(updatedInstructor);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = "Failed to update instructor", Error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteInstructor(Guid id)
    {
        var result = await _instructorService.DeleteInstructorAsync(id);
        if (!result)
        {
            return NotFound($"Instructor with ID {id} not found");
        }
        return NoContent();
    }
}
