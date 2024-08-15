using Microsoft.AspNetCore.Http;

namespace AnnounceBoard.Domain.Dtos;

public class AddAnnouncementDto
{
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public IFormFile? Photo { get; set; }
    
    public Guid UserId { get; set; }
}