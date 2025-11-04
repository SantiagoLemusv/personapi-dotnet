using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using personapi_dotnet.Models.Entities; // <-- Asegúrate de que este namespace coincide con el de tu AppDbContext
using personapi_dotnet.Repositories;    // <-- Aquí irán tus repositorios DAO

var builder = WebApplication.CreateBuilder(args);

// Add services to the container (MVC + API)
builder.Services.AddControllersWithViews();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PersonAPI", Version = "v1" });
});

// DbContext: conexión al SQL Server Docker (ajustado para tu contenedor)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DAO / Repository Pattern (registrar interfaces e implementaciones)
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    // Swagger visible en entorno de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonAPI v1"));
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
