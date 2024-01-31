using Domain.Models.Users;

namespace Infrastructure.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> RegisterUser(User userToCreate);
        User AuthenticationUserLogin(string username, string password);
		void AuthenticationUserLogin(string v);
	}
}
