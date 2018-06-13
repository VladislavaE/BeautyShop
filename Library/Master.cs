using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Master
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Service> Skills { get; set; }
        public TimeSpan FirstClientTime { get; set; }
        public TimeSpan LastClientTime { get; set; }
        public virtual List<Order> MastersOrders { get; set; }
        public TimeSpan Interval { get; set; }

        public List<TimeSpan> Schedule()
        {
            var result = new List<TimeSpan>();
            var clientTime1 = FirstClientTime;
            while(clientTime1<=LastClientTime)
            {
                result.Add(clientTime1);
                clientTime1 += Interval;
            }
            
            return result;
        }

        public List<TimeSpan> AvailableTime(DateTime wantedDate)
        {
            var takenSlots = MastersOrders.FindAll(o => o.Date.Date.Equals(wantedDate.Date)).Select(s => s.Date.TimeOfDay);
            var availableTime = Schedule().FindAll(t => !takenSlots.Contains(t));
            return availableTime;
            
        }


    }
}
