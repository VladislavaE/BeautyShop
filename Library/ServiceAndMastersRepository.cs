using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ServiceAndMastersRepository
    {
        public List<Service> AllServices { get; set; }
        public List<Master> AllMasters { get; set; }
        public List<Order> AllOrders { get; set; }
        
       
        public static ServiceAndMastersRepository FakeRepo()
        {
            ServiceAndMastersRepository fakeRepo = new ServiceAndMastersRepository();
            fakeRepo.AllMasters = new List<Master>() { new Master() { Id = 0, Name="345", MastersOrders=new List<Order>() { new Order() { } }, FirstClientTime=TimeSpan.FromHours(9), LastClientTime=TimeSpan.FromHours(18), Interval=TimeSpan.FromMinutes(25) }, new Master() { Id = 1, MastersOrders = new List<Order>() { }, FirstClientTime = TimeSpan.FromHours(9), LastClientTime = TimeSpan.FromHours(18), Interval = TimeSpan.FromMinutes(25) }, new Master() { Id = 2, Name="123", MastersOrders = new List<Order>() { }, FirstClientTime = TimeSpan.FromHours(10), LastClientTime = TimeSpan.FromHours(18), Interval = TimeSpan.FromMinutes(27) } };
            fakeRepo.AllServices = new List<Service>() { new Service() { Name = "Маникбр", Id = 0, Masters = new List<Master>() { fakeRepo.AllMasters[0], fakeRepo.AllMasters[2] } } };
            fakeRepo.AllOrders = new List<Order>() { };
            return fakeRepo;
        }
    }
}
