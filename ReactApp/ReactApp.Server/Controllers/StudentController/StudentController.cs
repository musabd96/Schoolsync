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
        public async Task<IActionResult> GetStudentById(Guid Id)
        {
            var query = new GetStudentByIdQuery(Id);
            var student = await _mediator.Send(query);
            return student != null ? Ok(student) : NotFound($"No student found with ID: {Id}");
        }
    }
}
