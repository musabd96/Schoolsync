using Application.Commands.Register;
using Application.Dtos;
using Application.Dtos.DtoValidation;
using Application.Queries.Users.Login;
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

        [HttpPost]
        [Route("userToRegister")]
        public async Task<IActionResult> Register([FromBody] UserDto userToRegister)
        {
            try
            {
                var createdUser = await _mediator.Send(new RegisterUserCommand(userToRegister));

                return CreatedAtAction(nameof(Register), createdUser);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

		[HttpPost("login")]
		[ProducesResponseType(typeof(TokenDto), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Errors), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> Login([FromBody] UserDto userToLogin)
		{
            try
            {
                string token = await _mediator.Send(new LoginUserQuery(userToLogin));

                return Ok(token);
            }
            catch (ArgumentException ex)
            {
				return BadRequest(ex.Message);
			}
		}
	}
}
