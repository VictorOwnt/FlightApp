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

        public Product()
        {
            DiscountPercentage = 0;
        }
    }
}
