using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backupPokemon.Model;

namespace backupPokemon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PokemonModelsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PokemonModelsController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<PokemonModel>> Get()
        {
            return _context.pokemon.ToList();
        }
        [Route("{id}")]
        [HttpGet]
        public ActionResult<PokemonModel> Get(int id)
        {
            var pokemons = _context.pokemon.FirstOrDefault(a => a.id == id);
            return Ok(pokemons);
        }
        [HttpPost]
        public ActionResult<PokemonModel> post(PokemonModel pokemons)
        {
            _context.pokemon.Add(pokemons);
            _context.SaveChanges();
            return Ok(pokemons);
        }

        [Route("{id}")]
        [HttpPut]
        public ActionResult<PokemonModel> put(PokemonModel pokemons)
        {
            var inputPokemon = _context.pokemon.FirstOrDefault(a => a.id == pokemons.id);
            inputPokemon.name = pokemons.name;
            inputPokemon.type = pokemons.type;
            inputPokemon.gender = pokemons.gender;
            inputPokemon.weight = pokemons.weight;
            inputPokemon.height = pokemons.height;
            _context.SaveChanges();
            return Ok(pokemons);
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult<PokemonModel> delete(int id)
        {
            var dltPokemon = _context.pokemon.FirstOrDefault(a => a.id == id);

            _context.Remove(dltPokemon);
            _context.SaveChanges();
            return Ok(dltPokemon);

        }
    }
}
