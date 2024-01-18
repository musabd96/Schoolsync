using Application.Queries.Students.GetStudentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Server.Controllers.StudentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        internal readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("getStudentById/{studentId}")]
        public async Task<IActionResult> GetStudentById(Guid studentId)
        {
            var query = new GetStudentByIdQuery(studentId);
            var student = await _mediator.Send(query);
            return student != null ? Ok(student) : NotFound($"No student found with ID: {studentId}");
        }
    }
}
