using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public ICollection<Orderline> Orderlines { get; set; }
        public bool IsDelivered { get; set; }

        public double CalculateOrderCost()
        {
            double cost = 0;
            foreach (Orderline orderline in Orderlines)
            {
                cost += orderline.Product.Price;
            }
            return cost;
        }

        public string OrderCostToString()
        {
            double totalCost = CalculateOrderCost();
            return "Total cost:" + " €" + totalCost.ToString();
        }

        public string IsDeliveredToString()
        {
            if (IsDelivered)
            {
                return "Order Delivered";
            }
            else
            {
                return "Deliver Order";
            }
        }
        public string StatusToString()
        {
            if (IsDelivered)
            {
                return "Status: Delivered";
            }
            else
            {
                return "Status: Not delivered";
            }
        }

    }
}
