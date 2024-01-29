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
                if (string.IsNullOrEmpty(userToRegister.Username) || string.IsNullOrEmpty(userToRegister.PasswordHash))
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
        public User AuthenticationUserLogin(string username, string password)
        {
            try
            {
               var User = _appDbContext.Users.First(u =>  u.Username == username);

                if (User == null)
                {
                    throw new Exception("User not found");
                }

                // Verify the password by comparing the hashed input password with the stored hashed password
                if(!VerifyPasswordHash(password, User.PasswordHash))
                {
                    throw new Exception("Wrong password");
                }

                return User;
            }
            catch (ArgumentException ex) 
            { 
                throw new ArgumentException(ex.Message);
            }
		}

		private bool VerifyPasswordHash(string password, string storedHash)
		{
			// Use BCrypt to verify the password hash
			return BCrypt.Net.BCrypt.Verify(password, storedHash);
		}
	}
}
