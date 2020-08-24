using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Models
{
    public class Passenger : Person
    {
        public int SeatNumber { get; set; }
        public ICollection<Order> Orders { get; set; }

        public string TotalOrdersCostToString()
        {
            double cost = 0;
            foreach (Order order in Orders)
            {
                cost += order.OrderCost;
            }
            return "Total Cost: " + cost.ToString() + "€";
        }

        public override string ToString()
        {
            return Email;// $"{SeatNumber}. {Name}";
        }
    }
}
