using Application.Queries.Classrooms.GetAllClassrooms;
using Domain.Models.Classrooms;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Server.Controllers.ClassroomController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : Controller
    {
        internal readonly IMediator _mediator;

        public ClassroomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllClassrooms")]

        public async Task<IActionResult> GetAllClassrooms()
        {
            try
            {
                var query = new GetAllClassroomQuery();
                var result = await _mediator.Send(query);

                if (!(result is not List<Classroom> classroom || classroom.Count == 0))
                {
                    return Ok(classroom);
                }
                else { return Ok(); }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
