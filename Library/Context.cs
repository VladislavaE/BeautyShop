using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Context:DbContext
    {
        public DbSet<Master> Masters { get; set; }
        public DbSet<Order> Oders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public Context():base("beautydb")
        {

        } 
    }
}
