using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var Pokemons = new Dictionary<int, Pokemon>
{
    {1, new Pokemon(1, "Bulbizarre", new Uri("https://www.pokepedia.fr/images/thumb/e/ef/Bulbizarre-RFVF.png/250px-Bulbizarre-RFVF.png"), "Plante")},
    {2, new Pokemon(2, "Herbizarre", new Uri("https://www.pokepedia.fr/images/thumb/4/44/Herbizarre-RFVF.png/250px-Herbizarre-RFVF.png"), "Plante")},
    {3, new Pokemon(3, "Florizarre", new Uri("https://www.pokepedia.fr/images/thumb/4/42/Florizarre-RFVF.png/250px-Florizarre-RFVF.png"), "Plante")},
};

app.MapGet("/api/pokemons", () =>
{
    var pokemons = Pokemons.Values
        .Select(x => x)
        .ToArray();

    return TypedResults.Ok(pokemons);
})
.WithName("pokemons")
.WithOpenApi();

app.MapGet("/api/pokemons/{id}", Results<NotFound, Ok<Pokemon>>([FromRoute] int id) =>
    {
        if (Pokemons.TryGetValue(id, out var pokemon))
        {
            return TypedResults.Ok(pokemon);
        }

        return TypedResults.NotFound();
    })
    .WithName("pokemon")
    .WithOpenApi();

app.MapFallbackToFile("/index.html");

app.Run();

public record Pokemon(int Id, string Name, Uri Image, string Type);