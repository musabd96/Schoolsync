using Domain.Models.Users;
using MediatR;

namespace Application.Commands.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        public Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
