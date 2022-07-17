using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PlanetsAPI.Data;
using PlanetsAPI.Dtos;
using PlanetsAPI.Models;

namespace PlanetsAPI.Controllers{

    [Route("api/planets")]
    [ApiController]
    public class PlanetsController : ControllerBase{
        private readonly IPlanetsRepository _repository;

        private readonly IMapper _mapper;

        public PlanetsController(IPlanetsRepository repository, IMapper mapper){
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/planets/
        [HttpGet]
        public ActionResult<IEnumerable<PlanetReadDto>> GetAllPlanets(){
            var planetsItems = _repository.GetAllPlanets();

            return Ok(_mapper.Map<IEnumerable<PlanetReadDto>>(planetsItems));
        }

        //GET api/planets/{id}
        [HttpGet("{id}", Name="GetPlanetById")]
        public ActionResult<PlanetReadDto> GetPlanetById(int id){
            var planetItem = _repository.GetPlanetById(id);

            if(planetItem != null){
                return Ok(_mapper.Map<PlanetReadDto>(planetItem));
            }

            return NotFound();
        }

        //POST api/planets/
        [HttpPost]
        public ActionResult CreatePlanet(PlanetCreateDto planetCreateDto){
            var planetModel = _mapper.Map<Planet>(planetCreateDto);
            
            _repository.CreatePlanet(planetModel);
            _repository.SaveChanges();

            return NoContent();
        }

        //PUT api/planets/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePlanet(int id, PlanetUpdateDto planetUpdateDto){
            var planetFromRepo = _repository.GetPlanetById(id);

            if(planetFromRepo == null){
                return NotFound();
            }

            _mapper.Map(planetUpdateDto, planetFromRepo);
            _repository.UpdatePlanet(planetFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/planets/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdatePlanet(int id, JsonPatchDocument<PlanetUpdateDto> patchDocument){
            var planetModelFromRepo = _repository.GetPlanetById(id);

            if(planetModelFromRepo == null){
                return NotFound();
            }

            var planetToPatch = _mapper.Map<PlanetUpdateDto>(planetModelFromRepo);
            patchDocument.ApplyTo(planetToPatch, ModelState);

            if(!TryValidateModel(planetToPatch)){
                return ValidationProblem(ModelState);
            }

            _mapper.Map(planetToPatch, planetModelFromRepo);
            _repository.UpdatePlanet(planetModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/planets/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePlanet(int id){
            var planetModelFromRepo = _repository.GetPlanetById(id);

            if(planetModelFromRepo == null){
                return NotFound();
            }

            _repository.DeletePlanet(planetModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}