using Application.Commands.Students.AddStudent;
using Application.Commands.Students.DeleteStudent;
using Application.Commands.Students.UpdateStudent;
using Application.Dtos;
using Application.Queries.Students.GetAllStudents;
using Application.Queries.Students.GetStudentById;
using Application.Validators.Students;
using Domain.Models.Student;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace ReactApp.Server.Controllers.StudentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {

        private readonly IMediator _mediator;
        private readonly StudentValidator _studentValidator;

        public StudentController(IMediator mediator, StudentValidator studentValidator)
        {
            _mediator = mediator;
            _studentValidator = studentValidator;
        }

        //Get all Student
        [HttpGet]
        [Route("getAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var query = new GetAllStudentsQuery();
                var result = await _mediator.Send(query);

                // Check if the result is a valid list of students
                if (result is List<Student> students && students.Any())
                {
                    // Return OkObjectResult with the list of students
                    return Ok(students);
                }
                else
                {
                    // Return OkResult with an empty result or handle accordingly
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Get Student By Id
        [HttpGet]
        [Route("getStudentById/{studentId}")]
        public async Task<IActionResult> GetStudentById(Guid studentId)
        {
            try
            {
                var query = new GetStudentByIdQuery(studentId);
                var student = await _mediator.Send(query);
                return student != null ? Ok(student) : NotFound($"No student found with ID: {studentId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetTeacherById: {ex.Message}");

                return StatusCode(500, "Internal Server Error");
            }
        }

        // Add a new Student
        [HttpPost]
        [Route("addStudent")]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
        {
            // Validate input using the validator
            var validationResult = await _studentValidator.ValidateAsync(studentDto);

            if (!validationResult.IsValid)
            {
                // Validation failed, return bad request with validation errors
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
            }
            try
            {
                var command = new AddStudentCommand(studentDto);
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = await _mediator.Send(new DeleteStudentCommand(id));
            if (student != null)
            {
                return NoContent();
            }
            return NotFound();
        }

        // Update Student
        [HttpPut]
        [Route("updateStudent")]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentDto updatedStudent, Guid updateStudent)
        {
            var validationResult = await _studentValidator.ValidateAsync(updatedStudent);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
            }
            try
            {
                var command = new UpdateStudentCommand(updatedStudent, updateStudent);
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
