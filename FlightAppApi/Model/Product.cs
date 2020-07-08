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
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; } // Enum?
        //public Bitmap Image { get; set; }

        public ICollection<PassengerProduct> PassengerProducts { get; set; }
    }
}
