using EsportsBay.API.Data;
using EsportsBay.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext _context) : base(_context)
        {
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.User.SingleOrDefault(x => x.Name == username);

            if (user == null)
                return null;
            if (!VerifyPasswordHash(password, user.PassswordHash, user.PasswrodSalt))
                return null;

            return user;
        }

        public  void Create(User user, string password)
        {
            if (true)
            {

            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or has a white space ", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or has a white space ", "password");

            if (storedHash.Length != 64) throw new ArgumentException("Invalid length", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of passwordsalt", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i <computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return false;
        }
    }
}
