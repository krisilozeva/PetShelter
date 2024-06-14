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
using EntityFrameworkCore.UseRowNumberForPaging;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AutoBind(typeof(PetService).Assembly);
//builder.Services.AutoBind(typeof(PetsService)Assembly);
builder.Services.AutoBind(typeof(PetRepository).Assembly);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PetShelterDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"],
        r => r.UseRowNumberForPaging());
});

builder.Services.AddAutoMapper(m => m.AddProfile(new AutoMapperConfiguration()));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
   .AddCookie();

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

