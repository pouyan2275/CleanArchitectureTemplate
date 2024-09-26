using Api.Bases;
using Application.Bases;
using Infrastructure.Bases.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddPresentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCors(o =>
{
    o.AllowAnyOrigin();
});

app.Run();
