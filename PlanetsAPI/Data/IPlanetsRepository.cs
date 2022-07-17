using PlanetsAPI.Models;
using System.Collections.Generic;

namespace PlanetsAPI.Data{

    public interface IPlanetsRepository{
        bool SaveChanges();

        IEnumerable<Planet> GetAllPlanets();

        Planet GetPlanetById(int id);

        void CreatePlanet(Planet planet);

        void UpdatePlanet(Planet planet);

        void DeletePlanet(Planet planet);
    }
}