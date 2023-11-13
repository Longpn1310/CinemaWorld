using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CinemaWorld.Data;
using CinemaWorld.Data.Models;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.Services.Services.Data;
using CinemaWorld.Services.Services.Data.Contracts;
using CinemaWorld.Global.Common.Repositories;
using static CinemaWorld.Global.Common.DataValidation;
using CinemaWorld.Data.Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CinemaWorldDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));

builder.Services.AddDefaultIdentity<CinemaWorldUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<CinemaWorldDbContext>();
builder.Services.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>().AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("FPTContext")
    .AddEntityFrameworkStores<CinemaWorldDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

// Cau hinh de dam bao su dong y cua nguoi dung can kiem tra
builder.Services.Configure<CookiePolicyOptions>(
    options =>
    {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
        // Cho phep yeu cau toi tu cac trang khac
    });

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddMvc();
// Data repositories
builder.Services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IDbQueryRunner, DbQueryRunner>();

builder.Services.AddTransient<IMoviesService, MoviesService>();
builder.Services.AddTransient<IGenresService, GenresService>();
builder.Services.AddTransient<ICloudinaryService, CloudinaryService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Midleware for missing page
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
