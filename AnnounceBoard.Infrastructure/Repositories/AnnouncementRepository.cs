using AnnounceBoard.Domain.Abstractions;
using AnnounceBoard.Domain.Entities;

namespace AnnounceBoard.Infrastructure.Repositories;

public class AnnouncementRepository(AnnounceBoardDbContext context)
    : BaseRepository<Announcement>(context), IAnnouncementRepository
{
}