using AnnounceBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnnounceBoard.Infrastructure.Configurations;

public class UserConfiguration
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.HasMany(user => user.Announcements)
            .WithOne(announcement => announcement.User)
            .HasForeignKey(announcement => announcement.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}