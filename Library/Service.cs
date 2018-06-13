using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Master> Masters { get; set; }
        public double Price { get; set; }
    }
}
