using Microsoft.EntityFrameworkCore;
using WepApis92.Context;
using WepApis92.Services;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

//paso 2:Inyeccion de dependencias
builder.Services.AddTransient<IUsuariosServices, UsuarioServices>();
builder.Services.AddTransient<IAutorServices, AutorServices>();

// Configuración de CORS-Conexion para la API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            //builder.WithOrigins("http://localhost:3000")
            //       .AllowAnyHeader()
            //       .AllowAnyMethod();
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Habilitar CORS
app.UseCors("AllowReactApp");

app.MapControllers();

app.Run();
