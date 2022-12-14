global using Infrastructure.Identity;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Infrastructure.Data;
using Web.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var csIdentity = builder.Configuration.GetConnectionString("AppIdentityDbContext");
var csBagStore = builder.Configuration.GetConnectionString("BagStoreContext");
builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseNpgsql(csIdentity));
builder.Services.AddDbContext<BagStoreContext>(options =>
    options.UseNpgsql(csBagStore));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();
await app.SeedDataAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
