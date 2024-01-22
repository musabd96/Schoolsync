using Application.Queries.Students.GetAllStudents;
using Application.Queries.Students.GetStudentById;
using Domain.Models.Student;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace ReactApp.Server.Controllers.StudentController
{
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
	}
}
