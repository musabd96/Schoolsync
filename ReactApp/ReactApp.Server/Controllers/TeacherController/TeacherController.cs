using Application.Queries.Teachers.GetAllTeachers;
using Application.Commands.Teachers.DeleteTeacher;
using Application.Queries.Students.GetAllStudents;
using Application.Queries.Teachers.GetTeacherById;
using Domain.Models.Teacher;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Server.Controllers.TeacherController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        internal readonly IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> GetAllTeachers()
        {
            try
            {
                var query = new GetAllTeachersQuery();
                var result = await _mediator.Send(query);

                // Check if the result is a valid list of teachers
                if (result is List<Teacher> Teachers && Teachers.Any())
                {
                    // Return OkObjectResult with the list of teachers
                    return Ok(Teachers);
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

        //GetTeacherById
        [HttpGet]
        [Route("getTeacherById/{teacherId}")]
        public async Task<IActionResult> GetTeacherById(Guid teacherId)
        {
            try
            {
                var query = new GetTeacherByIdQuery(teacherId);
                var teacher = await _mediator.Send(query);
                return teacher != null ? Ok(teacher) : NotFound($"No teacher found with ID: {teacherId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetTeacherById: {ex.Message}");

                return StatusCode(500, "Internal Server Error");
            }
        }

        //Delete a teacher by id
        [HttpGet]
        [Route("deleteTeacherById/{teacherId}")]
        public async Task<IActionResult> DeleteTeacherById(Guid teacherId)
        {
            try
            {
                var query = new DeleteTeacherCommand(teacherId);
                var teacher = await _mediator.Send(query);
                return teacher != null ? Ok(teacher) : NotFound($"No teacher found with ID: {teacherId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetTeacherById: {ex.Message}");

                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
