using Microsoft.EntityFrameworkCore;
using SantaInesAPI.Persistence.DAO.Implementations;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Database;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MigrationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
});

/*Inyeccion de dependencias*/
builder.Services.AddTransient<IUsuarioDAO, UsuarioDAO>();
builder.Services.AddTransient<IDepartamentoDAO, DepartamentoDAO>();
builder.Services.AddTransient<IDireccionDAO, DireccionDAO>();
builder.Services.AddTransient<IEmpleadoDAO, EmpleadoDAO>();
builder.Services.AddTransient<ICitaDAO, CitaDAO>();
builder.Services.AddTransient<IDashboardDAO, DashboardDAO>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
        options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
