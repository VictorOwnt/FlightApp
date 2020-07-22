using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public class Passenger : Person
    {
        [Required]
        public int SeatNumber { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Passenger()
        {
            Orders = new List<Order>();
        }

        public IEnumerable<Product> GetOrderedProducts()
        {
            List<Product> products = new List<Product>();
            foreach (Order order in Orders)
            {
                foreach (Orderline orderline in order.Orderlines)
                {
                    products.Add(orderline.Product);
                }
            }
            return products;
        }
    }
}
