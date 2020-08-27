using System.ComponentModel.DataAnnotations;

namespace FlightAppApi.Model
{
    public class Airport
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Location Location { get; set; }
    }
}
