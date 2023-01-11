using SantaInesWEB.Servicios.ServicioDireccion;
using SantaInesWEB.Servicios.ServicioEmpleado;
using SantaInesWEB.Servicios.ServicioUsuario;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injections
builder.Services.AddScoped<IServicioDireccion, ServicioDireccion>();
builder.Services.AddScoped<IServicioUsuario, ServicioUsuario>();
builder.Services.AddScoped<IServicioEmpleado, ServicioEmpleado>();

builder.Services.AddHttpClient("DevConnection", config =>
{
	config.BaseAddress = new Uri("https://localhost:7270/");
}
);


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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
