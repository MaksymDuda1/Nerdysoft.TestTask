namespace AnnounceBoard.Domain.Abstractions;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IAnnouncementRepository Announcement { get; }
    Task SaveAsync();
}