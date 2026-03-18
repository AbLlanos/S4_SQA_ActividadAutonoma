namespace ActividadAutonoma_as.Models
{
    public class PokemonListResult
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public List<PokemonSummary> Results { get; set; }
    }

    public class PokemonSummary
    {
        public string Name { get; set; } = "";
        public string Url { get; set; } = "";


        // La API no devuelve el ID, solo la URL: "https://pokeapi.co/api/v2/pokemon/1/"
        // Se extrae el ID quitando el '/' final, dividiendo por '/' y tomando el último valor.
        public int Id => int.Parse(Url.TrimEnd('/').Split('/').Last());

        public string SpriteUrl => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png";

    }

}
