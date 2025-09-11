using System.Text.Json.Serialization;
using Task2.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

builder.AddDbContext();

services.AddServices();

services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.UseStaticFiles();

app.MapGet("/", async context =>
{
    context.Response.Redirect("/index.html");
});

app.Run();

