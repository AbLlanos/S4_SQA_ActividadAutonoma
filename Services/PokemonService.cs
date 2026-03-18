using ActividadAutonoma_as.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ActividadAutonoma_as.Services
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient;

        // La PokeAPI devuelve JSON en snake_case (Todas las palabras en minúsculas separadas por guión bajo)
        // pero los modelos C# usan PascalCase (Cada palabra empieza con mayúscula, sin separadores)
        // Sin esta configuración, Newtonsoft NO conecta los nombres y todo queda en 0 o null.
        // SnakeCaseNamingStrategy traduce automáticamente snake_case A PascalCase al deserializar.
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokemonListResult> GetPokemonsAsync(int limit = 20, int offset = 0)
        {
            var response = await _httpClient.GetStringAsync(
                $"https://pokeapi.co/api/v2/pokemon?limit={limit}&offset={offset}");
            return JsonConvert.DeserializeObject<PokemonListResult>(response, _settings)
                   ?? new PokemonListResult();
        }

        public async Task<Pokemon> GetPokemonAsync(string name)
        {
            var response = await _httpClient.GetStringAsync(
                $"https://pokeapi.co/api/v2/pokemon/{name}");
            return JsonConvert.DeserializeObject<Pokemon>(response, _settings)
                   ?? new Pokemon();
        }
    }
}
