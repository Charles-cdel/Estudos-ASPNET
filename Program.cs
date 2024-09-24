using Serilog;
using Microsoft.Extensions.Configuration;
using ASPaPP;


var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseMiddleware<logMiddleware>();

app.MapGet("/", () => "TESTE");

app.Run();
