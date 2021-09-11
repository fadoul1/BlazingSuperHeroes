using SuperHeroDb.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroDb.Client.Service
{
    public interface ISuperHeroService
    {
        event Action Onchange;
        List<Comic> Comics { get; set; }
        List<SuperHero> Heroes { get; set; }
        Task GetComics();
        Task<List<SuperHero>> GetSuperHeroes();
        Task<SuperHero> GetSuperHero(int id);
        Task<List<SuperHero>> CreateSuperHero(SuperHero hero);
        Task<List<SuperHero>> UpdateSuperHero(int id, SuperHero hero);
        Task<List<SuperHero>> DeleteSuperHero(int id);
    }
}
