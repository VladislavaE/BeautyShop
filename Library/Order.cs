using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Order
    {
        public Service Service { get; set; }
        public Master Master { get; set; }
        public DateTime Date { get; set; }

    }
}
