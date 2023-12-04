using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CinemaWorld.Data;
using CinemaWorld.Data.Models;
using CinemaWorld.Services.Services.Data.Contract;
using CinemaWorld.Services.Services.Data;
using CinemaWorld.Services.Services.Data.Contracts;
using static CinemaWorld.Global.Common.DataValidation;
using Microsoft.Extensions.DependencyInjection;
//using CinemaWorld.Global.Common;
using CinemaWorld.Global.Common.Repositories;
using CloudinaryDotNet;
using CinemaWorld.ViewModels.Faq;
using Microsoft.AspNetCore.Identity.UI.Services;
using CinemaWorld.Services.Messaging;
using NHibernate.Mapping.ByCode;
using CinemaWorld.Helper;
using Microsoft.Extensions.Options;
using CinemaWorld.Models;
using System.Reflection;
using CinemaWorld.Services.Services.Data.Mapping;
using CinemaWorld.Middlewares;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CinemaWorldDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));


builder.Services.AddSession(options =>
{
    options.IdleTimeout = new TimeSpan(0, 6, 0, 0);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddDefaultIdentity<CinemaWorldUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<CinemaWorldDbContext>();
//builder.Services.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>().AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("FPTContext")
//.AddEntityFrameworkStores<CinemaWorldDbContext>().AddDefaultTokenProviders();
builder.Services.AddControllersWithViews(configure =>
{
    configure.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-CSRF-TOKEN";
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
builder.Services.AddAutoMapper(typeof(ErrorViewModel).GetTypeInfo().Assembly);
AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
// Data repositories
builder.Services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IDbQueryRunner, DbQueryRunner>();
var cloudinarySettings = builder.Configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
var account = new Account(
cloudinarySettings.CloudName,
cloudinarySettings.ApiKey,
cloudinarySettings.ApiSecret);
var cloudinary = new Cloudinary(account);
builder.Services.AddSingleton(cloudinary);
//builder.Services.AddTransient<CinemaWorld.Services.Messaging.IEmailSender>(
//serviceProvider => new SendGridEmailSender(this.configuration["SendGrid:ApiKey"]));
builder.Services.AddTransient<ISettingsService, SettingsService>();
builder.Services.AddTransient<IMoviesService, MoviesService>();
builder.Services.AddTransient<IDirectorService, DirectorService>();
builder.Services.AddTransient<IGenresService, GenresService>();
builder.Services.AddTransient<ICountriesService, CountriesService>();
builder.Services.AddTransient<ICinemasService, CinemasService>();
builder.Services.AddTransient<ICloudinaryService, CloudinaryService>();
builder.Services.AddSingleton(cloudinary);
builder.Services.AddTransient<IContactsService, ContactsService>();
builder.Services.AddTransient<IAboutService, AboutService>();
builder.Services.AddTransient<IRatingsService, RatingsService>();
builder.Services.AddTransient<INewsService, NewsService>();
builder.Services.AddTransient<IHallsService, HallsService>();
builder.Services.AddTransient<ISeatsService, SeatsService>();
builder.Services.AddTransient<IMovieProjectionsService, MovieProjectionsService>();
builder.Services.AddTransient<ITicketsService, TicketsService>();
builder.Services.AddTransient<IPrivacyService, PrivacyService>();
builder.Services.AddTransient<IMovieCommentsService, MovieCommentsService>();
builder.Services.AddTransient<INewsCommentsService, NewsCommentsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Midleware for missing page
// app.UseRequestDecompression();// Middleware nay kich haot viec nen du lieu cua http responses, giup giam kich thuoc du lieu gui qua mang
// app.UseStatusCodePagesWithRedirects("/Home/HttpError?statusCode={0}");//Middleware nay xu ly cac trang thai http cu the bang chuyen den url chi dinh
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
//app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
//app.UseAdminMiddleware();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
