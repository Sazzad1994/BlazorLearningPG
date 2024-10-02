using CRUDProject.Client.Pages;
using CRUDProject.Components;
using CRUDProject.Shared.Repositories;
using CRUDProject.Shared.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value!),
});

builder.Services.AddControllers();
var connection = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(connection, b => b.MigrationsAssembly("CRUDProject"));
});

//connection, b => b.MigrationsAssembly("CRUDProject")

builder.Services.AddScoped<IGameService, GameService>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.MapControllers();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(CRUDProject.Client._Imports).Assembly);

app.Run();
