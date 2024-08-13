using DotNetEnv;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PubgAPI.Interfaces;
using PubgAPI.Rest;

var builder = WebApplication.CreateBuilder(args);

// Carregar variáveis do arquivo .env
Env.Load();

// Configurar o acesso às variáveis de ambiente
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IPlayerService, PlayerRest>();
builder.Services.AddHttpClient<IMatchService, MatchRest>(); 

builder.Services.AddHttpClient<PlayerRest>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();