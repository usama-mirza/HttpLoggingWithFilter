using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.RequestPropertiesAndHeaders |
    HttpLoggingFields.ResponsePropertiesAndHeaders |
    HttpLoggingFields.ResponseStatusCode |
    HttpLoggingFields.RequestQuery |
    HttpLoggingFields.RequestBody;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWhen(
    context => !context.Request.Path.StartsWithSegments("/Sensitive"), //SensitiveController.cs
    builder => builder.UseHttpLogging());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
