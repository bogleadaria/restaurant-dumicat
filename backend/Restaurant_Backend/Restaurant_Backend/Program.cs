using Microsoft.EntityFrameworkCore;
using Restaurant_Backend;
using Restaurant_Backend.Repository;
using Restaurant_Backend.Repository.Category;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

    //// add all repositories to do 
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();

    /// after adding repos rermove comments
// builder.Services.AddControllers();

// var connectionstring = builder.Configuration.GetConnectionString("MyDatabase");

    //// rewrite the corrrect connection string in the appsettings json
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
// {
//     options.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring));
// });



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

    ///  to remove comment when done
// app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}