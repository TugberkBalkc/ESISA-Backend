using ESISA.Core.Application.Extensions.DIRegitrations;
using ESISA.Core.Application.Extensions.MiddlewareRegistrations;
using ESISA.Infrastructure.Extensions.DIRegistrations;
using ESISA.Infrastructure.Persistence.Extensions.DIRegistrations;
using ESISA.WebAPI.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterApplicationDependencies(builder.Configuration);
builder.Services.RegisterInfrastructureDependencies();
builder.Services.RegisterPersistenceDependencies(builder.Configuration);
builder.Services.RegisterWebAPIDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpExceptionHandlerMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
