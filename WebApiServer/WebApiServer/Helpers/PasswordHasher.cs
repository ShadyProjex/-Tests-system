using System.Security.Cryptography;

namespace WebApiServer.Helpers
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            // Generate a random salt
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Generate the hash using PBKDF2
            byte[] hash = new Rfc2898DeriveBytes(password, salt, 10000).GetBytes(32);

            // Combine the salt and hash into a single string
            byte[] hashBytes = new byte[48];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 32);
            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Extract the salt and hash from the hashed password
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            byte[] hash = new byte[32];
            Array.Copy(hashBytes, 16, hash, 0, 32);

            // Hash the password with the same salt and compare the hashes
            byte[] newHash = new Rfc2898DeriveBytes(password, salt, 10000).GetBytes(32);
            for (int i = 0; i < 32; i++)
            {
                if (hash[i] != newHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
