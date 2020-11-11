using Pretriage.Context;
using Pretriage.Entitis.Model;
using System.Linq;
using System.Text;

namespace Pretriage.AccessData.Repositories
{
    public class UserRepository : IUserRepository
    {
        private PretriageContext _context;
        public UserRepository(PretriageContext context)
        {
            _context = context;
        }

        public void Add(string login, string password)
        {
            var model = new User
            {
                Login = login.ToLower(),
                HashPassword = PasswordToHashMD5(password).ToString()
            };
            _context.User.Add(model);
        }
        public bool ValidateUser(string login, string password)
        {
            string tmpHashPassword = PasswordToHashMD5(password);

            bool RetVal = _context.User.Any(x => x.Login.ToLower() == login.ToLower() && x.HashPassword == tmpHashPassword);
            return RetVal;
        }
        public void Delete(User userR)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == userR.Id);
        }

        private static string PasswordToHashMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
