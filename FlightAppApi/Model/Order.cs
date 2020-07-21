using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public class Order
    {
        public int Id { get; private set; }
        public ICollection<Orderline> Orderlines { get; set; }

        public Order()
        {
            Orderlines = new List<Orderline>();
        }
    }
}
