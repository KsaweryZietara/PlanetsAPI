using System.ComponentModel.DataAnnotations;

namespace PlanetsAPI.Models{

    public class Planet{
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public int Diameter  { get; set; }

        [Required]
        public int DistanceFromEarth { get; set; }

        [Required]
        public int MeanTemperature { get; set; }

        [Required]
        public string Description { get; set; }
    }
}