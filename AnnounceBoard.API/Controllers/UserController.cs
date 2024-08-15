using AnnounceBoard.Application.Abstractions;
using AnnounceBoard.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AnnounceBoard.API.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(IUserService userService, IUnitOfWork unitOfWork)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await unitOfWork.Users.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        return Ok(await userService.GetUserById(id));
    }
}