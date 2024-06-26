using Microsoft.EntityFrameworkCore;
using Backend.Data;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
.AddJsonOptions(Options =>
{
    Options.JsonSerializerOptions.PropertyNamingPolicy = null;
    Options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    Options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* ------------ AÑADIR INTERFACES --------------- */

builder.Services.AddDbContext<BackendDbContext>(options =>
options.UseMySql(
    builder.Configuration.GetConnectionString("MySqlConnection"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.MapControllers();
app.Run();