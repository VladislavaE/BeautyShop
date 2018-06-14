using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.Entity;

namespace Library
{
    public class UsersDatabaseRepository : IUsersRepository
    {
        private DbSet<User> RegisteredUsers { get; set; }
        Context context;

        public void RegisterUser(string name, string login, string password, string telNumber)
        {
            var user = new User
            {
                Name = name,
                Login = login,
                HashedPassword = GetHash(password),
                TelNumber=telNumber,
                Discount=0
            };

            if (!RegisteredUsers.Any(u => u.Login == login))
            {
                RegisteredUsers.Add(user);
            }
            WriteToDatabase();
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

        }
        public void AddVisitToUser(Order order, User user)
        {
            user.AddOrder(order);
            WriteToDatabase();
        }

        


        public static UsersDatabaseRepository ReadFromDatabase()
        {
            var context = new Context();
            context.Database.Log = Console.WriteLine;
            var users = context.Users;
            return new UsersDatabaseRepository() { RegisteredUsers = users, context = context };
        }

        public void WriteToDatabase()
        {
            context.SaveChanges();
        }
    }
}
