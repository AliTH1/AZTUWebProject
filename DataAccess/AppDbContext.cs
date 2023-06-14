using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Account;

namespace DataAccess;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<Panel> Panels { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Conference> Conferences { get; set; }
}