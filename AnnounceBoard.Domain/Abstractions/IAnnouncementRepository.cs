using System.Linq.Expressions;
using AnnounceBoard.Domain.Entities;

namespace AnnounceBoard.Domain.Abstractions;

public interface IAnnouncementRepository
{
    Task<List<Announcement>> GetAllAsync(
        params Expression<Func<Announcement, object>>[] includes);

    Task<List<Announcement>> GetByConditionsAsync(
        Expression<Func<Announcement, bool>> expression,
        params Expression<Func<Announcement, object>>[] includes);

    Task<Announcement?> GetSingleByConditionAsync(
        Expression<Func<Announcement, bool>> expression,
        params Expression<Func<Announcement, object>>[] includes);

    Task InsertAsync(Announcement entity);
    Task InsertRangeAsync(List<Announcement> entities);
    void Update(Announcement entity);
    Task Delete(Guid id);
    void Delete(Announcement entity);
}