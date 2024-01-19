
using Application.Dtos;
using Application.Queries.Students.GetAllStudents;
using Application.Queries.Students.GetStudentById;
using Domain.Models.Student;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace ReactApp.Server.Controllers.StudentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {

        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
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
            var query = new GetStudentByIdQuery(studentId);
            var student = await _mediator.Send(query);
            return student != null ? Ok(student) : NotFound($"No student found with ID: {studentId}");
        }
    }

    // Add a new Student
    [HttpPost]
    [Route("addStudent")]
    public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
    {
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

}
