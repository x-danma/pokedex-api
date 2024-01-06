var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<PokemonService>();

var app = builder.Build();

app.MapGet("/pokemon/{id}", (int id, PokemonService pokemonService) => pokemonService.GetPokemonFull(id));
app.MapGet("/pokemon/{id}/slim", (int id, PokemonService pokemonService) => pokemonService.GetPokemonSlim(id));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = string.Empty; // Set the root route to Swagger
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    });
}

// test from vs code
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
