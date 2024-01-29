using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Server.Controllers.CourseController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        internal readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
