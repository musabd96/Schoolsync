using Application.Queries.Students.GetAllStudents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

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
        //Get all Students
        [HttpGet]
        [Route("getAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var query = new GetAllStudentsQuery();
                var result = await _mediator.Send(query);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
