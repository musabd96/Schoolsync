using System.Text;

namespace ReactApp.Server.Helpers
{
	public class SecretKeyHelper
	{
		public static byte[] GetSecretKey(IConfiguration configuration)
		{
			var secretKey = configuration["JWTToken:Token"];

			if (string.IsNullOrEmpty(secretKey))
			{
				throw new InvalidOperationException("JwtSettings:SecretKey is missing or invalid in appsettings.json.");
			}

			return Encoding.ASCII.GetBytes(secretKey);
		}
	}
}
