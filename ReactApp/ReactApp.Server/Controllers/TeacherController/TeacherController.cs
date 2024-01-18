using Application.Queries.Students.GetStudentById;
using Application.Queries.Teachers.GetTeacherById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Server.Controllers.TeacherController
{
    public class TeacherController : Controller
    {
        internal readonly IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetTeacherById/{teacherId}")]
        public async Task<IActionResult> GetTeacherById(Guid teacherId)
        {
            {
                var query = new GetTeacherByIdQuery(teacherId);
                var teacher = await _mediator.Send(query);
                return teacher != null ? Ok(teacher) : NotFound($"No teacher found with ID: {teacherId}");
            }
        }
    }
}
