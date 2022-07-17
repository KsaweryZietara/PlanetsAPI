using AutoMapper;
using PlanetsAPI.Dtos;
using PlanetsAPI.Models;

namespace PlanetsAPI.Profiles{

    public class PlanetsProfile : Profile{
        
        public PlanetsProfile(){
            CreateMap<Planet, PlanetReadDto>();
            CreateMap<PlanetCreateDto, Planet>();
            CreateMap<PlanetUpdateDto, Planet>();
            CreateMap<Planet, PlanetUpdateDto>();
        }
        
    }
}