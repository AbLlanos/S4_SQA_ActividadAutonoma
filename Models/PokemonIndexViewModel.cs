namespace ActividadAutonoma_as.Models
{
    public class PokemonIndexViewModel
    {
        // La lista de pokémon que se muestra en pantalla
        public List<PokemonSummary> Pokemons { get; set; }

        // En qué posición empieza la página actual
        public int Offset { get; set; }

        // Cuántos pokémon se muestran por página
        public int Limit { get; set; }

        // Total de pokémon que existen en la API (1350)
        // Se usa para saber si hay página siguiente o no
        public int Total { get; set; }
    }

}
