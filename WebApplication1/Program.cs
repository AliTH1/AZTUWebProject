using Business.Services.Abstract;
using Business.Services.Concrete;
using DataAccess;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Entities.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddIdentity<AppUser, IdentityRole<int>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();



builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(Business.Utilities.Profiles.PanelProfile)));

builder.Services.AddScoped<IPanelRepository, PanelRepository>();
builder.Services.AddScoped<IPanelService, PanelService>();

builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<INewsService, NewsService>();

builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();

builder.Services.AddScoped<IConferenceRepository, ConferenceRepository>();
builder.Services.AddScoped<IConferenceService, ConferenceService>();

builder.Services.AddScoped<ISliderRepository, SliderRepository>();
builder.Services.AddScoped<ISliderService, SliderService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(opt =>
{
    opt.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );

    opt.MapDefaultControllerRoute();
});

app.Run();
