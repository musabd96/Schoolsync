using Application.Dtos;
using Domain.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReactApp.Server.Controllers.AuthorizeController
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthorizeController : Controller
    {
        public static User user = new User();

        private readonly IConfiguration _configuration;

        public AuthorizeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost("Login")]

        public ActionResult<User> LogIn(UserDto request)
        {
            if (user.Username != request.Username)
            {
                return BadRequest("User Not Found");
            }

            if(!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return BadRequest("Wrong Password");
            }

            string token = CreateToken(user);

            return Ok(token);
            
        }

        private string CreateToken(User user)
        {


            var secretKey = _configuration["AppSettings:SecretKey"];
            if (secretKey != null)
            {
                throw new InvalidOperationException("Secretkey must not ben null");
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
