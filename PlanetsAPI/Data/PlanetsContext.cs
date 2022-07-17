using PlanetsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PlanetsAPI.Data{

    public class PlanetsContext : DbContext{
        public DbSet<Planet> Planets {get; set;}

        public PlanetsContext(DbContextOptions<PlanetsContext> options) : base(options){
        }
    }
}