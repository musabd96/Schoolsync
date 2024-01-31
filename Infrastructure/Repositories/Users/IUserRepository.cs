using Domain.Models.Users;

namespace Infrastructure.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> RegisterUser(User userToCreate);
        Task<User> AuthenticationUserLogin(string username, string password);
    }
}
