using System.ComponentModel.DataAnnotations;

namespace FlightAppApi.Model
{
    public class Airline
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; } // extra info about airline you are flying with

        [Required]
        public string ImageString { get; set; }
    }
}
