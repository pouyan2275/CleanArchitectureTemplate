using Api.Bases;
using Application.Bases;
using Application.Bases.Implements.Services;
using Domain.Bases.Interfaces.Repositories;
using Infrastructure.Bases.Data;
using Infrastructure.Bases.Data.Repositories;
using Personal.Server.Bases.Middlewares;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

var c = ";";

var b = "";

builder.Services
    .AddApplication()
    .AddPresentation();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

#if !DEBUG
app.UseMiddleware<ExceptionHandlingMiddleware>();
#endif

app.UseAuthorization();

app.MapControllers();

app.UseCors(o =>
{
    o.AllowAnyOrigin();
    o.AllowAnyMethod();
    o.AllowAnyHeader();
});

app.Run();
