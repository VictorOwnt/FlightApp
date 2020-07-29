using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Models
{
    public class Order
    {
        public ICollection<Orderline> Orderlines { get; set; }
    }
}
