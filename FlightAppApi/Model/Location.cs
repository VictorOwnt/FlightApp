using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace FlightAppApi.Model
{
    public class Location
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude {get; set;}
    }
}
