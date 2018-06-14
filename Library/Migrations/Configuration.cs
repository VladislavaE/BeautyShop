namespace Library.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Library.Context context)
        {
            var user1 = new User { Id = 1, Name = "Test", Discount = 0, TelNumber = "89161234567" };
            context.Users.AddOrUpdate(u => u.Login, user1);

            var master1 = new Master { Id = 1, Name = "Наталья", FirstClientTime = TimeSpan.FromHours(9), LastClientTime = TimeSpan.FromHours(18), Interval = TimeSpan.FromMinutes(70) };
            var master2 = new Master { Id = 2, Name = "Алефтина", FirstClientTime = TimeSpan.FromHours(9), LastClientTime = TimeSpan.FromHours(20), Interval = TimeSpan.FromMinutes(69) };
            var master3 = new Master { Id = 3, Name = "Диана Игоревна", FirstClientTime = TimeSpan.FromHours(10), LastClientTime = TimeSpan.FromHours(19), Interval = TimeSpan.FromMinutes(35) };
            var master4 = new Master { Id = 4, Name = "Лилия", FirstClientTime = TimeSpan.FromHours(9), LastClientTime = TimeSpan.FromHours(18), Interval = TimeSpan.FromMinutes(80) };
            var master5 = new Master { Id = 5, Name = "Евгения", FirstClientTime = TimeSpan.FromHours(12), LastClientTime = TimeSpan.FromHours(22), Interval = TimeSpan.FromMinutes(60) };
            var master6 = new Master { Id = 6, Name = "Олег", FirstClientTime = TimeSpan.FromHours(8), LastClientTime = TimeSpan.FromHours(17), Interval = TimeSpan.FromMinutes(47) };
            context.Masters.AddOrUpdate(master1, master2, master3, master4, master5, master6);
            var service1 = new Service { Id = 1, Name = "Маникюр", Masters = new List<Master>() { master1, master4, master2 }, Price = 1500 };
            var service2 = new Service { Id = 2, Name = "Макияж", Masters = new List<Master>() { master1, master3, master5, master6 }, Price = 1000 };
            context.Services.AddOrUpdate(service1, service2);


            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
