using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Models
{
    public class Product
    {
        private string _name;
        public string Name
        {
            get => _name.First().ToString().ToUpper() + _name.Substring(1);
            set => _name = value;
        }
        public string ImagePath { get; set; }
        public double Price { get; set; }

        public string PriceToString(double price)
        {
            return "€" + price.ToString();
        }

    }
}
