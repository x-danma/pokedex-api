// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");

// Call pokemon api
var client = new HttpClient();

var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
};

Console.WriteLine("Getting pokemon list");
// foreach file in ./pokemon/id/{id}.json take the id, name, types, one default and shiny sprite, and save to a new json file in ./pokemon/id/slim/{id}.json
foreach (var file in Directory.EnumerateFiles("./pokemon/id"))
{

    var content = await File.ReadAllTextAsync(file);
    var pokemon = JsonSerializer.Deserialize<Pokemon>(content, options);
    if (pokemon == null)
    {
        Console.WriteLine($"Pokemon with id {new FileInfo(file).Name} is null");
        continue;
    }

    var slimPokemon = new SlimPokemon
    {
        Id = pokemon.Id,
        Name = pokemon.Name,
        Types = pokemon.Types.Select(t => t.Type.Name).ToList(),
        Sprites = new SlimSprites
        {
            Default = pokemon.Sprites.Default,
            Shiny = pokemon.Sprites.Shiny,
        },
    };

    await File.WriteAllTextAsync($"./pokemon/id/slim/{pokemon.Id}.json", JsonSerializer.Serialize(slimPokemon, options));
    Console.WriteLine($"Pokemon {pokemon.Name} was saved to file ./pokemon/id/slim/{pokemon.Id}.json");
}



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