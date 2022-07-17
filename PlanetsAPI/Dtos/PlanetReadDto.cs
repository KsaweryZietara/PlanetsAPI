namespace PlanetsAPI.Dtos{

    public class PlanetReadDto{
        public string Name { get; set; }
        public int Diameter  { get; set; }
        public int DistanceFromEarth { get; set; }
        public int MeanTemperature { get; set; }
        public string Description { get; set; }
    }
}