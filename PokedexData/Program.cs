// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using PokedexApi.Models;

Console.WriteLine("Hello, World!");


// foreach pokemon slim in ./Pokemon/id/slim, populate ./Pokemon/id/full as a json array of all pokemon

// use a default serializer
// var options = new JsonSerializerOptions
// {
//     PropertyNameCaseInsensitive = true,
//     PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

// };

// var pokemonSlims = new List<PokemonSlim>();
// foreach (var file in Directory.GetFiles($"./Pokemon/id/slim/"))
// {
//     var json = File.ReadAllText(file);
//     // deserialize json to pokemonSlim
//     var pokemonSlim = JsonSerializer.Deserialize<PokemonSlim>(json, options);
//     if (pokemonSlim == null)
//     {
//         Console.WriteLine("pokemonSlim is null");
//         return;
//     }
//     // add pokemonSlim to pokemonSlims
//     pokemonSlims.Add(pokemonSlim);
//     Console.WriteLine($"added {pokemonSlim.Name} to pokemonSlims");
// }
// // and save list to ./Pokemon/all/slim/all-slim.json
// var slimJson = JsonSerializer.Serialize(pokemonSlims, options);
// File.WriteAllText("./Pokemon/all/slim/all-slim.json", slimJson);
// Console.WriteLine("all-slim.json written");