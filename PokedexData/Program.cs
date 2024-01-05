// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");

// Call pokemon api
var client = new HttpClient();

var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
};

for (int id = 1; id <= 1010; id++)
{
    var response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
    var content = await response.Content.ReadAsStringAsync();

    var pokemon = JsonSerializer.Deserialize<Pokemon>(content, options);
    if (pokemon == null)
    {
        Console.WriteLine($"Pokemon with id {id} is null");
        continue;
    }

    // save pokemon data to json file. file name is pokemon number and name

    // check if file exists
    if (File.Exists($"{pokemon.Id}_{pokemon.Name}.json"))
    {
        Console.WriteLine($"File {pokemon.Id}_{pokemon.Name}.json already exists");
        continue;
    }

    await File.WriteAllTextAsync($"{pokemon.Id}_{pokemon.Name}.json", content);
    Console.WriteLine($"Pokemon {pokemon.Name} was saved to file {pokemon.Id}_{pokemon.Name}.json");
}


// Print pokemon name

class Pokemon
{
    public string Name { get; set; }
    public int Id { get; set; }
}
