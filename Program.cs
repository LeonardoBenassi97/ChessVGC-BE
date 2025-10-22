using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ChessVGC.BE.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSignalR();

// Register Stockfish service (wrapper for Stockfish.NET)
builder.Services.AddSingleton<ChessEngineService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();
app.UseEndpoints(endpoints =>
{
 endpoints.MapControllers();
 endpoints.MapHub<ChessHub>("/chessHub");
});

app.Run();