using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ServiceAndMastersRepository:IServiceAndMastersRepository
    {
        Context context;
        public DbSet<Service> AllServices { get; set; }
        public DbSet<Master> AllMasters { get ; set; }
        public DbSet<Order> AllOrders { get; set; }



        public static ServiceAndMastersRepository ReadServicesFromDatabase()
        {
            var context = new Context();
            context.Database.Log = Console.WriteLine;
            var services = context.Services;
            return new ServiceAndMastersRepository() { AllServices=services,context = context };
        }

        public static ServiceAndMastersRepository ReadOrdersFromDatabase()
        {
            var context = new Context();
            context.Database.Log = Console.WriteLine;
            var orders = context.Oders;
            return new ServiceAndMastersRepository() { AllOrders=orders,context = context };
        }

        public void WriteToDatabase()
        {
            context.SaveChanges();
        }
    }
}
