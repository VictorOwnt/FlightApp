using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public class Orderline
    {
        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; set; }

        public Orderline()
        {

        }
        public Orderline(Product product)
        {
            ProductId = product.ProductId;
            Product = product;
        }
    }
}
