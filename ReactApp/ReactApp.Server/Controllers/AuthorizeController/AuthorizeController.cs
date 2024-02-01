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








    }
}
