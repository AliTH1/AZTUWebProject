using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Entities.Account;

namespace DataAccess;



public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<AppUser>()
            .HasOne(a => a.StudentInfo)
            .WithOne(s => s.AppUser)
            .HasForeignKey<StudentInfo>(c => c.UserId);
        base.OnModelCreating(builder);

        builder.Entity<AppUser>()
            .HasOne(a => a.TeacherInfo)
            .WithOne(s => s.AppUser)
            .HasForeignKey<TeacherInfo>(c => c.UserId);
        base.OnModelCreating(builder);
    }


    //Entities
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<Panel> Panels { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Conference> Conferences { get; set; }

    //Core
    public DbSet<StudentInfo> StudentsInfo { get; set; }
    public DbSet<TeacherInfo> TeachersInfo { get; set; }
}