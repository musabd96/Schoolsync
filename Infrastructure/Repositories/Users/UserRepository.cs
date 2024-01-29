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

        public async Task<User> RegisterUser(User userToRegister)
        {
            try
            {
                if (string.IsNullOrEmpty(userToRegister.Username) || string.IsNullOrEmpty(userToRegister.Password))
                {
                    throw new ArgumentException("Username or password cannot be empty.");
                }

                _appDbContext.Users.Add(userToRegister);
                _appDbContext.SaveChanges();
                return await Task.FromResult(userToRegister);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
