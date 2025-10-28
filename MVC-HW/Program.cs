using APP.Domain;
using APP.Models;
using APP.Services;
using CORE.APP.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



var connectionString = builder.Configuration.GetConnectionString(nameof(Db));
builder.Services.AddDbContext<DbContext, Db>(options => options.UseSqlite(connectionString));

builder.Services.AddScoped<IService<FootballerRequest, FootballerResponse>, FootballerService>();
builder.Services.AddScoped<CategoryObsoleteService>(); // Obsolete concrete service registration (Scoped per request)
builder.Services.AddScoped<IService<CategoryRequest, CategoryResponse>, CategoryService>();
builder.Services.AddScoped<IService<ClubRequest, ClubResponse>, ClubService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
