using Domain.Models.Users;

namespace Infrastructure.Repositories.Authorization
{
	public interface IAuthRepository
	{
		User AuthenticateUser(string username, string password);
		string GenerateJwtToken(User user);
	}
}
