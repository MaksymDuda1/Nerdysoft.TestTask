using System.Text.Json.Serialization;
using AnnounceBoard.Domain.Entities;

namespace AnnounceBoard.Domain.Dtos;

public class AnnouncementDto
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = null!;
    
    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }
    
    public string? PhotoPath { get; set; }
    
    [JsonIgnore]
    public User? User { get; set; }
}