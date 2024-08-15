using System.Security.Authentication;
using AnnounceBoard.Application.Abstractions;
using AnnounceBoard.Application.Exceptions;
using AnnounceBoard.Application.Models;
using AnnounceBoard.Domain.Dtos;
using AnnounceBoard.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace AnnounceBoard.Application.Services;

public class AuthorizationService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    ITokenService tokenService,
    IConfiguration configuration) : IAuthorizationService
{
    public async Task<TokenApiModel> Login(LoginDto loginDto)
    {
        var userByEmail = await userManager.FindByEmailAsync(loginDto.Email);

        if (userByEmail == null)
            throw new EntityNotFoundException("No user with given email was found");

        var result = await signInManager
            .PasswordSignInAsync(userByEmail.UserName, loginDto.Password, false, false);

        if (!result.Succeeded)
            throw new CredentialValidationException("Wrong password");

        return await tokenService.GenerateToken(userByEmail);
    }

    public async Task<TokenApiModel> Registration(RegistrationDto registrationDto)
    {
        var user = new User()
        {
            Email = registrationDto.Email,
            UserName = registrationDto.Username,
        };

        var result = await userManager.CreateAsync(user, registrationDto.Password);

        if (!result.Succeeded)
            throw new AuthenticationException("User already exist");

        await userManager.AddToRoleAsync(user, "User");
        await userManager.UpdateAsync(user);

        return await tokenService.GenerateToken(user);
    }

    public Task Logout()
    {
        return signInManager.SignOutAsync();
    }
}