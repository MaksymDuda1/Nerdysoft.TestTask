using Microsoft.AspNetCore.Identity;

namespace AnnounceBoard.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiration { get; set; }
    
    public List<Announcement>? Announcements { get; set; } = new List<Announcement>();
}