using AnnounceBoard.Domain.Dtos;

namespace AnnounceBoard.Application.Abstractions;

public interface IUserService
{
    Task<UserDto> GetUserById(Guid userId);
}