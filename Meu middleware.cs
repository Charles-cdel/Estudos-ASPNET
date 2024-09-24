using System;
using System.Diagnostics;
using Serilog;
using Microsoft.Extensions.Configuration;


namespace ASPaPP;

public class Meu_middleware
{
    private readonly RequestDelegate _next;

    public Meu_middleware(RequestDelegate next) 
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        await _next(httpContext);
    }
}

public class logMiddleware
{
      private readonly RequestDelegate _next;

    public logMiddleware(RequestDelegate next) 
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        var sw = Stopwatch.StartNew();

        await _next(httpContext);

        sw.Stop();

        Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        Log.Information($"a execução demorou {sw.Elapsed.TotalMilliseconds}ms({sw.Elapsed.TotalSeconds}segundos)");
        
    }
}
