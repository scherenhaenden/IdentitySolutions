using System.Security.Cryptography;

namespace IdentityService.BusinessLogic.Services.Security
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
    
        bool VerifyHashedPassword(string hashedPassword, string providedPassword);
    
    }

    public class PasswordHasherOptions
    {
        public int SaltSize { get; set; } = 16;
        public int Iterations { get; set; } = 10000;
        public HashAlgorithmName HashAlgorithmName { get; set; } = HashAlgorithmName.SHA1;
    
        public int KeySize { get; set; } = 256;
    
        public int HashSize { get; set; } = 256;
    }

    public class PasswordHasher: IPasswordHasher
    {
        private readonly PasswordHasherOptions _options;

        public PasswordHasher(PasswordHasherOptions options)
        {
            _options = options;
        }
    
    
        public string HashPassword(string password)
        {
            byte[] saltBuffer;
            byte[] hashBuffer;

        
            using (var keyDerivation = new Rfc2898DeriveBytes(password, _options.SaltSize, _options.Iterations, _options.HashAlgorithmName))
            {
                saltBuffer = keyDerivation.Salt;
                hashBuffer = keyDerivation.GetBytes(_options.HashSize);
            }
    
            byte[] result = new byte[_options.HashSize + _options.SaltSize];
            Buffer.BlockCopy(hashBuffer, 0, result, 0, _options.HashSize);
            Buffer.BlockCopy(saltBuffer, 0, result, _options.HashSize, _options.SaltSize);
            return Convert.ToBase64String(result);
        }
    
        public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
            if (hashedPasswordBytes.Length != _options.HashSize + _options.SaltSize)
            {
                return false;
            }

            byte[] hashBytes = new byte[_options.HashSize];
            Buffer.BlockCopy(hashedPasswordBytes, 0, hashBytes, 0, _options.HashSize);
            byte[] saltBytes = new byte[_options.SaltSize];
            Buffer.BlockCopy(hashedPasswordBytes, _options.HashSize, saltBytes, 0, _options.SaltSize);

            byte[] providedHashBytes;
            using (var keyDerivation = new Rfc2898DeriveBytes(providedPassword, saltBytes, _options.Iterations, _options.HashAlgorithmName))
            {
                providedHashBytes = keyDerivation.GetBytes(_options.HashSize);
            }

            return hashBytes.SequenceEqual(providedHashBytes);
        }
    }
}