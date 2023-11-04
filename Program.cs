using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();

builder.Services.AddControllers();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseTimeMiddleware();

app.Run();
