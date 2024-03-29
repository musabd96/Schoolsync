﻿using Application.Commands.Register;
using Application.Dtos;
using Application.Dtos.DtoValidation;
using Application.Queries.Users.Login;
using Domain.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace ReactApp.Server.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        internal readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public UserController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("userToRegister")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserDto userToRegister)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


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
        [AllowAnonymous]
        [ProducesResponseType(typeof(TokenDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Errors), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] UserDto userToLogin)
        {
            try
            {
                var userToAuthenticate = new UserDto
                {
                    Username = userToLogin.Username,
                    Password = userToLogin.Password
                };

                var user = await _mediator.Send(new LoginUserQuery(userToAuthenticate));
                var token = CreateToken(user);

                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        private string CreateToken(User user)
        {


            var secretKey = _configuration["AppSettings:SecretKey"];
            if (secretKey == null)
            {
                throw new InvalidOperationException("Secretkey must not be null");
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));


            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                issuer: _configuration["AppSettings:Issuer"],
                audience: _configuration["AppSettings:Audience"],
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }



    }
}
