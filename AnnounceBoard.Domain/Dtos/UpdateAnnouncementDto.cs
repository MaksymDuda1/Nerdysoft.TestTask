namespace AnnounceBoard.Domain.Dtos;

public class UpdateAnnouncementDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public string? PhotoPath { get; set; }
}