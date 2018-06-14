using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace WorkshopOfBeauty
{
    public class TestIt
    {
        public static void testMain()
        {
            var user1 = UsersDatabaseRepository.FakeUsers();
            var chosenUser = user1.AnonymusUser();
            var fakeRepo = ServiceAndMastersRepository.FakeRepo();
            Service service1=fakeRepo.AllServices[0];
            Master chosenmaster1 = service1.Masters[1];
            DateTime chosendate = DateTime.Now.Date;
            List<TimeSpan> availabletime=chosenmaster1.AvailableTime(chosendate);
            TimeSpan chosentime = availabletime[5];
            Order orderdone = new Order() { Master = chosenmaster1, Service = service1, Date = chosendate + chosentime };
            //chosenUser.AddOrder(orderdone);
            chosenmaster1.MastersOrders.Add(orderdone);
            var availabletime1=chosenmaster1.AvailableTime(chosendate);
            foreach(var r in availabletime1)
            {
                Console.WriteLine($"{r}");
            }
            
        }

    }
}
