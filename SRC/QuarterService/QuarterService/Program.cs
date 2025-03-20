using CommonShared.Midleares;
using CommonShared.Registration;
using QuarterService.DataPersistance.AppContext;
using QuarterService.DataPersistance.Repository;
using QuarterService.Domain.Interfaces;
using QuarterService.Infrastructure.Interfaces;
using QuarterService.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseContext(builder.Configuration);
builder.Services.AddMediatRServices();

builder.Services.AddScoped<IFuturesDifferenceRepository, FuturesDifferenceRepository>();
builder.Services.AddScoped<IBinanceClient, BinanceClient>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
