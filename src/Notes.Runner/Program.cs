using Microsoft.EntityFrameworkCore;

using Notes.Api.RouteGroupBuilderExtension;
using Notes.Database;
using Notes.Database.Extensions;
using Notes.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder
    .Configuration
    .GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<NotesContext>(options => options.UseNpgsql(connectionString).EnableSensitiveDataLogging());
builder.Services.AdditionalConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.ApplyMigrate();

app.MapServices();


app.Run();