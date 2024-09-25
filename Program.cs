using Serilog;
using Microsoft.Extensions.Configuration;
using ASPaPP;


var builder = WebApplication.CreateBuilder(args);

builder.UseSerilog();

var app = builder.Build();



app.UseLogTempo();

app.MapGet("/", () => "TESTE");

app.MapGet("/teste", () =>{
    Thread.Sleep(1500);//faz com que a requisição espere ("durma") alguns segundos
    return "teste2";
});

app.Run();
