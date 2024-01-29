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
        public async Task <User> LoginUser(string username)
        {
			if (string.IsNullOrWhiteSpace(username))
			{
				throw new ArgumentException("Username can not be null or empty.", nameof(username));
			}
			return await _appDbContext.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
		}
    }
}
