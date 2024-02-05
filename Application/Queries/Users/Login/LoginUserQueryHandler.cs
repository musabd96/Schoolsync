using Domain.Models.Users;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Queries.Users.Login
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, User>
    {
        private readonly IUserRepository _userRepository;
        public LoginUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.AuthenticationUserLogin(request.LoginUser.Username, request.LoginUser.Password);
            if (user == null)
            {
                throw new UnauthorizedAccessException("User not found or password is incorrect");
            }

            return user; // Returning the User object instead of just the username
        }
    }
}
