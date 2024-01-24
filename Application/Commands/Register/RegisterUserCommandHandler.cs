using Domain.Models.Users;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Commands.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userToCreate = new User
            {
                Id = Guid.NewGuid(),
                Username = request.NewUser.Username,
                Password = request.NewUser.Password,
            };

            if (string.IsNullOrEmpty(userToCreate.Username) || string.IsNullOrEmpty(userToCreate.Password))
            {
                throw new ArgumentException("Username or password cannot be empty.");
            }

            var createdUser = _userRepository.RegisterUser(userToCreate);

            return createdUser;
        }
    }
}
