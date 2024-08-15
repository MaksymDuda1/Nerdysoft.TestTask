using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AnnounceBoard.Domain.Entities;

public class Announcement
{
    public Guid Id { get; set; }

    [MaxLength(300)] 
    public string Title { get; set; } = null!;

    [MaxLength(1000)] 
    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }

    [MaxLength(100)]
    public string? PhotoPath { get; set; } 
    
    public Guid UserId { get; set; }
    
    [JsonIgnore]
    public User? User { get; set; }
}