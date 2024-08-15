using AnnounceBoard.Application.Abstractions;
using AnnounceBoard.Application.Exceptions;
using AnnounceBoard.Domain.Abstractions;
using AnnounceBoard.Domain.Dtos;
using AutoMapper;

namespace AnnounceBoard.Application.Services;

public class UserService(
    IUnitOfWork unitOfWork,
    IMapper mapper) : IUserService
{
    public async Task<UserDto> GetUserById(Guid userId)
    {
        var user = await unitOfWork.Users
            .GetSingleByConditionAsync(u => u.Id == userId, u => u.Announcements);

        if (user == null)
            throw new EntityNotFoundException("User not found");

        return mapper.Map<UserDto>(user);
    }
}