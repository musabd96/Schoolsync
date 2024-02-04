using Application.Queries.Courses.GetAllCourses;
using Domain.Models.Course;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Server.Controllers.CourseController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get all Course
        [HttpGet]
        [Route("getAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            try
            {
                var query = new GetAllCourseQuery();
                var result = await _mediator.Send(query);

                // Check if the result is a valid list of courses
                if (result is List<Course> courses && courses.Any())
                {
                    // Return OkObjectResult with the list of courses
                    return Ok(courses);
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
        // Get Course By Id
        [HttpGet]
        [Route("getCourseById/{courseId}")]
        public async Task<IActionResult> GetCourseById(Guid courseId)
        {
            try
            {
                var query = new GetCourseByIdQuery(courseId);
                var course = await _mediator.Send(query);
                return course != null ? Ok(course) : NotFound($"No course found with ID: {courseId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetTeacherById: {ex.Message}");

                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
