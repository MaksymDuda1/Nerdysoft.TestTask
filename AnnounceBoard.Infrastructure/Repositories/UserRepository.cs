using AnnounceBoard.Domain.Abstractions;
using AnnounceBoard.Domain.Entities;

namespace AnnounceBoard.Infrastructure.Repositories;

public class UserRepository(AnnounceBoardDbContext context)
: BaseRepository<User>(context), IUserRepository
{
    
}