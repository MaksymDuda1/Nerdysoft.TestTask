namespace AnnounceBoard.Domain.Dtos;

public class UserDto
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public List<AnnouncementDto>? Announcements { get; set; }
}