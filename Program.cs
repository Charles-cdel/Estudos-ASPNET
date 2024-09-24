using Serilog;
using Microsoft.Extensions.Configuration;
using ASPaPP;


var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseMiddleware<logMiddleware>();

app.MapGet("/", () => "TESTE");

app.MapGet("/teste", () =>{
    Thread.Sleep(1500);//faz com que a requisição espere ("durma") alguns segundos
    return "teste2";
});

app.Run();
