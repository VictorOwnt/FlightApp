using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Models
{
    public class Product
    {
        public int ProductId { get; private set; }

        private string _name;
        public string Name
        {
            get => _name.First().ToString().ToUpper() + _name.Substring(1);
            set => _name = value;
        }
        public string ImagePath { get; set; }

        public double BasePrice { get; set; }

        public int DiscountPercentage { get; set; }

        public double Price
        {
            get
            {
                if (DiscountPercentage == 0)
                {
                    return BasePrice;
                }
                else
                {
                    return BasePrice * DiscountPercentage;
                }
            }
        }

        public string PriceToString()
        {
            return "€" + Price.ToString();
        }

    }
}
