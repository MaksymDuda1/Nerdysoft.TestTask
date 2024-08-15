using AnnounceBoard.Application.Models;
using AnnounceBoard.Domain.Dtos;

namespace AnnounceBoard.Application.Abstractions;

public interface IAuthorizationService
{
    Task<TokenApiModel> Login(LoginDto loginDto);
    Task<TokenApiModel> Registration(RegistrationDto registrationDto);
    Task Logout();
}