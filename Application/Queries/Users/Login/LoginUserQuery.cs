using Application.Dtos;
using Domain.Models.Users;
using MediatR;

namespace Application.Queries.Users.Login
{
    public class LoginUserQuery : IRequest<User>
    {
        public UserDto LoginUser { get; set; }
        public LoginUserQuery(UserDto loginUser)
        {
            LoginUser = loginUser;
        }
    }
}
