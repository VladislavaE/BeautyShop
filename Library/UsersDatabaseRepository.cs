using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Library
{
    public class UsersDatabaseRepository:IUsersRepository
    {
        private List<User> RegisteredUsers { get; set; } //Db<Set>
        public static UsersDatabaseRepository testRepo()
        {
            var registeredUsers = new List<User>()
            {
                 new User()
           {
                Id = 1,
                Name = "Lena",
                Login = "Lena",
                HashedPassword = "123",
                TelNumber = "1234567890",
                UpcomingEvents = new List<Order>
            {
                new Order()
                {
                    Service=new Service
                    {
                        Name="Маникюр",
                        Price=1000
                    },
                    Date=new DateTime(2018,06,17),
                    Master=null,
                    Price=1000
                }
            }
           }
            };
            Console.WriteLine($"{registeredUsers.Count}");
            return new UsersDatabaseRepository() { RegisteredUsers = registeredUsers };

        }

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
   
        }
        public void AddVisitToUser(Order order, User user)
        {
            user.AddOrder(order);
            //WriteToDatabase();
        }

        public void RemoveVisitFromUser(Order order, User user)
        {
            user.CancelOrder(order);
            //WriteToDatabase();
        }

        public static UsersDatabaseRepository FakeUsers()
        {
            return new UsersDatabaseRepository();
        }

        public User AnonymusUser()
        {
            var User = new User()
            {

            };
            //RegisteredUsers.Add(User);
            return User;
            //WriteToDatabase
        }
        //методы для записи в базу данных и считывания
    }
}
