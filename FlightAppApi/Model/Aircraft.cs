using System.ComponentModel.DataAnnotations;

namespace FlightAppApi.Model
{
    public class Aircraft
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } //type

        [Required]
        public int ConstructionYear { get; set; }
    }
}
