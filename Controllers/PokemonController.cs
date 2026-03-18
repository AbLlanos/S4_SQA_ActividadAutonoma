using ActividadAutonoma_as.Models;
using ActividadAutonoma_as.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActividadAutonoma_as.Controllers
{
    public class PokemonController : Controller
    {

        // Llamar a pokemon Services
        private readonly PokemonService _pokemonsService;


        // Constructor
        public PokemonController(PokemonService pokemonsService)
        {
            _pokemonsService = pokemonsService;
        }



        // GET: Pokemon
        public async Task<ActionResult> Index(int limit = 20, int offset = 0)
        {
            var result = await _pokemonsService.GetPokemonsAsync(limit, offset);

            var viewModel = new PokemonIndexViewModel
            {
                Pokemons = result.Results,
                Offset = offset,
                Limit = limit,
                Total = result.Count
            };

            return View(viewModel);
        }

        // GET: Pokemon/Details/pikachu
        public async Task<ActionResult> Details(string id)
        {
            var pokemon = await _pokemonsService.GetPokemonAsync(id);
            return View(pokemon);
        }


        // GET: PokemonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PokemonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PokemonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PokemonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PokemonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PokemonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
