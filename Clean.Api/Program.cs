using Api.Bases;
using Application.Bases;
using Personal.Server.Bases.Middlewares;


var builder = WebApplication.CreateBuilder(args);

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
