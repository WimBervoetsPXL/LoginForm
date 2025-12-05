using LoginForm.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace LoginForm.Services
{
    public class UserManager
    {
        private string _username;
        private string _passwordHash;

        public bool Register(string username, string password)
        {
            _username = username;
            _passwordHash = HashPassword(password); //TODO

            return true;
        }

        public bool TryLogin(Registration credentials)
        {
            if(!credentials.Username.Equals(_username))
            {
                return false;
            }

            string hash = HashPassword(credentials.Password);

            if (!hash.Equals(_passwordHash))
            {
                return false;
            }

            return true;
        }

        private string HashPassword(string password)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
