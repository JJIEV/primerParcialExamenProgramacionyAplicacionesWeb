using api.examenparcial1.Data;
using api.examenparcial1.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");

builder.Services.AddDbContext<PrimerParcialApp>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();



    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();





app.MapPost("/cliente/", async (Cliente cliente, PrimerParcialApp db) =>
{
    db.Cliente.Add(cliente);
    await db.SaveChangesAsync();

    return Results.Created($"/cliente/{cliente.id}", cliente);
});

app.MapGet("/cliente/{id:int}", async (int id, PrimerParcialApp db) =>
{
    return await db.Cliente.FindAsync(id) is Cliente cliente ? Results.Ok(cliente) : Results.NotFound();
});

app.MapPut("/cliente/{id}", async (int id, Cliente cliente, PrimerParcialApp db) =>
{
    var cli = await db.Cliente.FindAsync(id);

    if (cli is null) return Results.NotFound();

    cli.id = cliente.id;
    cli.idCiudad = cliente.idCiudad;
    cli.Nombres = cliente.Nombres;
    cli.Apellidos = cliente.Apellidos;
    cli.Documento = cliente.Documento;
    cli.Telefono = cliente.Telefono;
    cli.Email = cliente.Email;
    cli.FechaNacimiento = cliente.FechaNacimiento;
    cli.Ciudad = cliente.Ciudad;
    cli.Nacionalidad = cliente.Nacionalidad;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/cliente/{id}", async (int id, PrimerParcialApp db) =>
{
    if (await db.Cliente.FindAsync(id) is Cliente cli)
    {
        db.Cliente.Remove(cli);
        await db.SaveChangesAsync();
        return Results.Ok(cli);
    }

    return Results.NotFound();
});




app.MapPost("/ciudad/", async (Ciudad ciudad, PrimerParcialApp db) =>
{
    db.Ciudad.Add(ciudad);
    await db.SaveChangesAsync();

    return Results.Created($"/ciudad/{ciudad.Id}", ciudad);
});

app.MapGet("/ciudad/{Id:int}", async (int Id, PrimerParcialApp db) =>
{
    return await db.Ciudad.FindAsync(Id) is Ciudad ciudad ? Results.Ok(ciudad) : Results.NotFound();
});

app.MapPut("/ciudad/{Id}", async (int Id, Ciudad ciudad, PrimerParcialApp db) =>
{
    var ciu = await db.Ciudad.FindAsync(Id);

    if (ciu is null) return Results.NotFound();

    ciu.Id = ciudad.Id;
    ciu.ciudad = ciudad.ciudad;
    ciu.Estado = ciudad.Estado;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/ciudad/{Id}", async (int Id, PrimerParcialApp db) =>
{
    if (await db.Ciudad.FindAsync(Id) is Ciudad ciu)
    {
        db.Ciudad.Remove(ciu);
        await db.SaveChangesAsync();
        return Results.Ok(ciu);
    }

    return Results.NotFound();
});


app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}