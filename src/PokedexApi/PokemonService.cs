

class PokemonService
{
    public PokemonService()
    {
    }

    public async Task<string> GetPokemonFull(int id)
    {
        // get file from ../data/full/pokemon{id}.json
        var file = $"../../PokedexData/Pokemon/id/full/{id}.json";
        var json = await File.ReadAllTextAsync(file);
        if (json == null)
        {
            return "pokemon not found";
        }
        return json;
    }

    internal object GetAllPokemonSlim()
    {
        var files = Directory.GetFiles($"../../PokedexData/Pokemon/id/slim/");
        var pokemonJsons = new List<string>();
        foreach (var file in files)
        {
            var json = File.ReadAllText(file);
            pokemonJsons.Add(json);
        }
        return pokemonJsons;
    }

    internal async Task<string> GetPokemonSlim(int id)
    {
        var file = $"../../PokedexData/Pokemon/id/slim/{id}.json";
        var json = await File.ReadAllTextAsync(file);
        if (json == null)
        {
            return "pokemon not found";
        }
        return json;
    }
}