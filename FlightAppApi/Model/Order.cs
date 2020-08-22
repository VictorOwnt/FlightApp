using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public class Order
    {
        [Required]
        public int OrderId { get; private set; }
        [Required]
        public ICollection<Orderline> Orderlines { get; set; }
        [Required]
        public int PassengerId { get; set; }
        [Required]
        public bool IsDelivered { get; set; }

        public double OrderCost { get; set; }
        public void SetOrderCost()
        {
            double cost = 0;
            foreach (Orderline orderline in Orderlines)
            {
                cost += orderline.Product.Price;
            }
            OrderCost = cost;
        }
        public Order()
        {
        }
        public Order(int passengerId)
        {
            Orderlines = new List<Orderline>();
            PassengerId = passengerId;
            IsDelivered = false;
        }


    }
}
