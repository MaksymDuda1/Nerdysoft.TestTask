using AnnounceBoard.Application.Abstractions;
using AnnounceBoard.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AnnounceBoard.API.Controllers;

[ApiController]
[Route("api/announcement")]
public class AnnouncementController(IAnnouncementService announcementService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAnnouncements()
    {
        return Ok(await announcementService.GetAllAnnouncements());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAnnouncementById(Guid id)
    {
        return Ok(await announcementService.GetAnnouncementById(id));
    }

    [HttpGet("user/{id:guid}")]
    public async Task<IActionResult> GetAllUserAnnouncements(Guid id)
    {
        return Ok(await announcementService.GetAllUserAnnouncements(id));
    }

    [HttpGet("similar/{id:guid}")]
    public async Task<IActionResult> GetSimilarAnnouncements(Guid id)
    {
        return Ok(await announcementService.GetSimilarAnnouncements(id));
    }

    [HttpPost]
    public async Task<IActionResult> AddAnnouncement([FromForm] AddAnnouncementDto request)
    {
        await announcementService.AddAnnouncement(request);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAnnouncement([FromForm] UpdateAnnouncementDto request)
    {
        await announcementService.UpdateAnnouncement(request);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAnnouncement(Guid id)
    {
        await announcementService.DeleteAnnouncement(id);
        return Ok();
    }
}