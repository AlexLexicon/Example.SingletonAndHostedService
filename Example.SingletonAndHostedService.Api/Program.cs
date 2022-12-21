using Example.SingletonAndHostedService.Api.Services;
using Example.SingletonAndHostedService.Api.Workers;

var builder = WebApplication.CreateBuilder(args);

//background worker
builder.Services.AddHostedService<MyHostedBackroundWorker>();

//singleton in memory store
builder.Services.AddSingleton<IMyInMemorySingletonService, MyInMemorySingletonService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
