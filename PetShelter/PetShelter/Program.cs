using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PetShelter;
using PetShelter.Data;
using PetShelter.Data.Repos;
using PetShelter.Shared.Security.Contracts;
using PetShelter.Shared.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using PetShelter.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PetShelterDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

builder.Services.AutoBind(typeof(PetService).Assembly);
builder.Services.AutoBind(typeof(PetRepository).Assembly);
builder.Services.AddAutoMapper(m => m.AddProfile(new AutoMapperConfiguration()));

IJwtSettings settings = builder.Configuration.GetSection(typeof(JwtSettings).Name).Get<JwtSettings>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddSingleton(settings);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PetShelterDbContext>();
    // Automatically update database
    context.Database.Migrate();
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