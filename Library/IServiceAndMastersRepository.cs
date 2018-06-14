using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface IServiceAndMastersRepository
    {
        DbSet<Service> AllServices {get; }
        DbSet<Master> AllMasters { get; }
        DbSet<Order> AllOrders { get; }
    }
}
