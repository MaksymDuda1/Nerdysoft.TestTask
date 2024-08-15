using AnnounceBoard.Domain.Dtos;

namespace AnnounceBoard.Application.Abstractions;

public interface IAnnouncementService
{
    Task<List<AnnouncementDto>> GetAllAnnouncements();
    Task<AnnouncementDto> GetAnnouncementById(Guid id);
    Task<List<AnnouncementDto>> GetAllUserAnnouncements(Guid id);
    Task<List<AnnouncementDto>> GetSimilarAnnouncements(Guid id);
    Task AddAnnouncement(AddAnnouncementDto announcementDto);
    Task UpdateAnnouncement(UpdateAnnouncementDto announcementDto);
    Task DeleteAnnouncement(Guid id);
}