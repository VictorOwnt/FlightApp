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
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }

        public string ImagePath { get; set; }
        [Required]
        public double BasePrice { get; set; }

        [Required]
        public double DiscountPercentage { get; set; }

        public double Price { get; set; }
        public Product()
        {
            DiscountPercentage = 0;
        }
        public void SetPrice()
        {
            if (DiscountPercentage == 0)
            {
                Price = BasePrice;
            }
            else if (DiscountPercentage == 100)
            {
                Price = 0;
            }
            else
            {
                Price = BasePrice * ((100 - DiscountPercentage) / 100);
            }
        }
    }
}
