using Domain.Models.Users;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<User> RegisterUser(User userToCreate)
        {
            throw new NotImplementedException();
        }
    }
}
