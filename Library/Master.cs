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
        public int FirstClientTime { get; set; }
        public int LastClientTime { get; set; }
        public int Interval { get; set; }


    }
}
