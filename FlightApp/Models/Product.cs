using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Models
{
    public class Product
    {

        public Product(string v)
        {
            this.Name = v;
        }

        public string Name { get; set; }

    }
}
