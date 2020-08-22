using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public class Product
    {
        [Required]
        public int ProductId { get; private set; }
        [Required]
        public string Name { get; set; }

        public string ImagePath { get; set; }
        [Required]
        public double BasePrice { get; set; }

        [Required]
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

        public Product()
        {
            DiscountPercentage = 0;
        }
    }
}
