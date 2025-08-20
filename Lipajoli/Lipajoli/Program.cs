using Lipajoli.Data;
using Lipajoli.Interface;
using Lipajoli.Models;
using Lipajoli.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BiblioContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));




builder.Services.AddScoped<IGenerateurCodeLivre, GenerateurCodeLivreService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<BiblioContext>();
    var config = services.GetRequiredService<IConfiguration>();

    // Charger les données de configuration
    var categories = config.GetSection("LibraryData:Categories").Get<List<CategorieLivre>>();
    var auteurs = config.GetSection("LibraryData:Auteurs").Get<List<Auteur>>();

    if (!context.Categories.Any())
        context.Categories.AddRange(categories);

    if (!context.Auteurs.Any())
        context.Auteurs.AddRange(auteurs);

    context.SaveChanges();

    // Initialiser uniquement les livres (voir ci-dessous)
    DbInitializer.Initialize(context);
}


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
