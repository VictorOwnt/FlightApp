using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public class Category
    {
        [Required]
        public int CategoryId { get; private set; }
        [Required]
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; }

    }
}
