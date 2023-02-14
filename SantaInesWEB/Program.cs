using SantaInesWEB.Servicios.ServicioDepartamento;
using SantaInesWEB.Servicios.ServicioDireccion;
using SantaInesWEB.Servicios.ServicioEmpleado;
using SantaInesWEB.Servicios.ServicioGrafica;
using SantaInesWEB.Servicios.ServicioHistoriaMedica;
using SantaInesWEB.Servicios.ServicioUsuario;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injections
builder.Services.AddScoped<IServicioDepartamento, ServicioDepartamento>();
builder.Services.AddScoped<IServicioUsuario, ServicioUsuario>();
builder.Services.AddScoped<IServicioEmpleado, ServicioEmpleado>();
builder.Services.AddScoped<IServicioDireccion, ServicioDireccion>();
builder.Services.AddScoped<IServicioCita, ServicioCita>();
builder.Services.AddScoped<IServicioGrafica, ServicioGrafica>();
builder.Services.AddScoped<IServicioHistoriaMedica, ServicioHistoriaMedica>();

builder.Services.AddHttpClient("DevConnection", config =>
{
	config.BaseAddress = new Uri("https://localhost:7270/");
}
);

builder.Services.AddSession();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
