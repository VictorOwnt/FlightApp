using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Models
{
    public class Passenger
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name
        {
            get => FirstName + " " + LastName;
        }
        public string Email { get; set; }
        public int SeatNumber { get; set; }
        public ICollection<Order> Orders { get; set; }

        public string TotalOrdersCostToString()
        {
            double cost = 0;
            foreach (Order order in Orders)
            {
                cost += order.CalculateOrderCost();
            }
            return "Total Cost: " + cost.ToString() + "€";
        }

    }
}
