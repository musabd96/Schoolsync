using MediatR;

namespace Application.Queries.Users.Login
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        public LoginUserQueryHandler() { }

        public Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
