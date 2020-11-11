using PretriageWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PretriageWeb.Services
{
    public class UserService
    {
        private PretriageDB _context;

        public UserService(PretriageDB context)
        {
            _context = context;
        }

        public void AddUser(string login, string password)
        {
            var model = new UserModel
            {
                Login = login.ToLower(),
                HashPassword = MD5.Create(password).ToString()
            };
            _context.User.Add(model);
        }
        public bool ValidateUser(string login, string password)
        {
            string tmpHashPassword = CreateMD5(password);

            bool RetVal = _context.User.Any(x => x.Login.ToLower() == login.ToLower() && x.HashPassword == tmpHashPassword);
            return RetVal;
        }
        public void RemoveUser(UserModel userR)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == userR.Id);
        }

        public static string CreateMD5(string input)
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
