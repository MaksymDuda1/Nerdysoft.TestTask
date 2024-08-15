using System.ComponentModel;
using AnnounceBoard.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnnounceBoard.Infrastructure;

public class AnnounceBoardDbContext(DbContextOptions options)
    : IdentityDbContext<User, Role, Guid>(options)
{
    public DbSet<Announcement> Announcements { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>();
        configurationBuilder.Properties<TimeOnly>()
            .HaveConversion<TimeOnlyConverter>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnnounceBoardDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}