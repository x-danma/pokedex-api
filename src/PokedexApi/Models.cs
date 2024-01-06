using System.Text.Json.Serialization;

namespace PokedexApi.Models;
class Pokemon
{
    public string Name { get; set; }
    public int Id { get; set; }
    public List<TypeInfo> Types { get; set; }
    public Sprites Sprites { get; set; }
}
class Sprites
{
    [JsonPropertyName("front_default")]
    public string Default { get; set; }
    [JsonPropertyName("front_shiny")]
    public string Shiny { get; set; }
}

class TypeInfo
{
    public int Slot { get; set; }
    public Type Type { get; set; }
}

class Type
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class SlimPokemon
{
    public string Name { get; set; }
    public int Id { get; set; }
    public List<string> Types { get; set; }
    public SlimSprites Sprites { get; set; }
}
public class SlimSprites
{
    public string Default { get; set; }
    public string Shiny { get; set; }
}