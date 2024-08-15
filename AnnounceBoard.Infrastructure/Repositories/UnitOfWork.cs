using AnnounceBoard.Domain.Abstractions;

namespace AnnounceBoard.Infrastructure.Repositories;

public class UnitOfWork(
    AnnounceBoardDbContext context,
    Lazy<IUserRepository> userRepository,
    Lazy<IAnnouncementRepository> announcementRepository) : IUnitOfWork
{
    public IUserRepository Users => userRepository.Value;

    public IAnnouncementRepository Announcement => announcementRepository.Value;

    public async Task SaveAsync() => await context.SaveChangesAsync();
}
