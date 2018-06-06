using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Library
{
    class UsersDatabaseRepository
    {
        private List<User> RegisteredUsers { get; set; }

        public void RegisterUser(string name, string login, string password)
        {
            var user = new User
            {
                Name = name,
                Login = login,
                HashedPassword = GetHash(password)
            };

            if (!RegisteredUsers.Any(u => u.Login == login))
            {
                RegisteredUsers.Add(user);
            }
           // WriteToDatabase();  //Сделать метод для записи в базу данных
        }

        public static string GetHash(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(
            password));
            return Convert.ToBase64String(hash);
        }

        public User LoginUser(string login, string password)
        {
            var hashedPassword = GetHash(password);
            try
            {
                var user = RegisteredUsers.Where(s => s.Login == login && s.HashedPassword == hashedPassword).Single();
                return user;
            }
            catch { return null; }

             //методы для записи в базу данных и считывания
        }
    }
}
