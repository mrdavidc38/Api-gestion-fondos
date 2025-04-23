using System.Text.Json.Serialization;
using Dependencias;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:5000");
// Add services to the container.

builder.Services.AddControllers();
    //.AddJsonOptions(options =>
    //{
    //   options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; ;
    //    //options.JsonSerializerOptions.WriteIndented = true; // opcional
    //});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => {
    options.AddPolicy("nuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.InyectarDependencias(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("nuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
