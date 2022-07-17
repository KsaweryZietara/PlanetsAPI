using System;
using System.Collections.Generic;
using System.Linq;
using PlanetsAPI.Models;

namespace PlanetsAPI.Data{

    public class SqlPlanetsRepository : IPlanetsRepository{
        private readonly PlanetsContext _context;
        
        public SqlPlanetsRepository(PlanetsContext context){
            _context = context;
        }

        public void CreatePlanet(Planet planet){
            if(planet == null){
                throw new ArgumentNullException(nameof(planet));
            }

            _context.Planets.Add(planet);
        }

        public void DeletePlanet(Planet planet){
            if(planet == null){
                throw new ArgumentNullException(nameof(planet));
            }

            _context.Planets.Remove(planet);
        }

        public IEnumerable<Planet> GetAllPlanets(){
            return _context.Planets.ToList();
        }

        public Planet GetPlanetById(int id){
            return _context.Planets.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges(){
            return _context.SaveChanges() >= 0;
        }

        public void UpdatePlanet(Planet planet){
            //In this type of database nothing
        }
    }
}