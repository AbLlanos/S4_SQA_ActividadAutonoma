

namespace ActividadAutonoma_as.Models
{

    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int BaseExperience { get; set; }
        public PokemonSprites Sprites { get; set; }
        public List<PokemonTypeSlot> Types { get; set; }
        public List<PokemonStat> Stats { get; set; }
        public List<PokemonAbilitySlot> Abilities { get; set; }
        public List<PokemonMoveSlot> Moves { get; set; }
    }

    public class PokemonSprites
    {
        // Sprites frontales
        public string FrontDefault { get; set; }
        public string FrontShiny { get; set; }

        // Sprites traseros
        public string BackDefault { get; set; }
        public string BackShiny { get; set; }
    }


    public class PokemonTypeSlot
    {
        public PokemonTypeName Type { get; set; }
    }
    public class PokemonTypeName
    {
        public string Name { get; set; }
    }

    public class PokemonStat
    {
        public int BaseStat { get; set; }
        public PokemonStatName Stat { get; set; }
    }
    public class PokemonStatName
    {
        public string Name { get; set; }
    }

    public class PokemonAbilitySlot
    {
        public PokemonAbilityName Ability { get; set; }
        public bool IsHidden { get; set; }
    }
    public class PokemonAbilityName
    {
        public string Name { get; set; }
    }

    public class PokemonMoveSlot
    {
        public PokemonMoveName Move { get; set; }
    }
    public class PokemonMoveName
    {
        public string Name { get; set; }
    }


    // La PokeAPI devuelve los datos en estructuras anidadas, no como valores directos.
    // los tipos no llegan como ["grass", "poison"] sino como objetos:
    // types: [ { type: { name: "grass" } }, { type: { name: "poison" } } ]
    // Por eso se crean clases intermedias (PokemonTypeSlot, PokemonTypeName, etc.)
    // que reflejan exactamente esa estructura del JSON.
    // Esto permite acceder a los datos en la vista usando la notación a.b.Propiedad:
    // t.Type.Name, s.Stat.Name, a.Ability.Name, m.Move.Name

}
