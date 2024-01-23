using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Server.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        internal readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
