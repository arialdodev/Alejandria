using Alejandria.DataAccess;
using Alejandria.DataAccess.Repositories;
using Alejandria.Interfaces;
using Alejandria.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AlejandriaDbContext>(opts =>
{
    opts.UseSqlServer(
      builder.Configuration["ConnectionStrings:DbConnection"]);
});

builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<IAutorServices, AutorServices>();

builder.Services.AddScoped<ILibroRepository, LibroRepository>();
builder.Services.AddScoped<IServicesLibro, LibroServices>();

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
    pattern: "{controller=Autor}/{action=Listar}/{id?}");

app.Run();
