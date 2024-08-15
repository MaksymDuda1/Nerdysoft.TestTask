using AnnounceBoard.Application.Abstractions;
using AnnounceBoard.Application.Exceptions;
using AnnounceBoard.Domain.Abstractions;
using AnnounceBoard.Domain.Dtos;
using AnnounceBoard.Domain.Entities;
using AutoMapper;

namespace AnnounceBoard.Application.Services;

public class AnnouncementService(
    IFileService fileService,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IAnnouncementService
{
    public async Task<List<AnnouncementDto>> GetAllAnnouncements()
    {
        var announcements = await unitOfWork.Announcement
            .GetAllAsync(a => a.User);

        return announcements.Select(mapper.Map<AnnouncementDto>).ToList();
    }

    public async Task<AnnouncementDto> GetAnnouncementById(Guid id)
    {
        var announcement = await unitOfWork.Announcement
            .GetSingleByConditionAsync(a => a.Id == id,a => a.User);

        if (announcement == null)
            throw new EntityNotFoundException("Announcement not found");

        return mapper.Map<AnnouncementDto>(announcement);
    }

    public async Task<List<AnnouncementDto>> GetAllUserAnnouncements(Guid id)
    {
        var announcements = await unitOfWork.Announcement
            .GetByConditionsAsync(a => a.UserId == id);

        return announcements.Select(mapper.Map<AnnouncementDto>).ToList();
    }

    public async Task<List<AnnouncementDto>> GetSimilarAnnouncements(Guid id)
    {
        var announcement = await unitOfWork.Announcement
            .GetSingleByConditionAsync(a => a.Id == id,a => a.User);

        if (announcement == null)
            throw new EntityNotFoundException("Announcement not found");
        
        var words = announcement.Title.Split(' ')
            .Concat(announcement.Description.Split(' '))
            .Select(w => w.ToLower())
            .Distinct()
            .ToList();

        var announcements = await unitOfWork.Announcement.GetAllAsync();
        var similarAnnouncements = new List<Announcement>();

        foreach (var a in announcements.Where(a => a.Id != announcement.Id))
        {
            var similarityScore = words.Count(
                w => a.Title.ToLower().Contains(w) || a.Description.ToLower().Contains(w));

            if (similarityScore > 0)
            {
                similarAnnouncements.Add(a);
                if (similarAnnouncements.Count == 3)
                {
                    break;
                }
            }
        }

        return similarAnnouncements.Select(mapper.Map<AnnouncementDto>).ToList();
    }

    public async Task AddAnnouncement(AddAnnouncementDto announcementDto)
    {
        var user = await unitOfWork.Users
            .GetSingleByConditionAsync(u => u.Id == announcementDto.UserId);

        if (user == null)
            throw new EntityNotFoundException("User not found");

        var announcement = new Announcement()
        {
            Title = announcementDto.Title,
            Description = announcementDto.Description,
            Date = DateTime.UtcNow,
            UserId = announcementDto.UserId
        };
        
        if(announcementDto.Photo != null)
            announcement.PhotoPath = await fileService.UploadImage(announcementDto.Photo);

        await unitOfWork.Announcement.InsertAsync(announcement);
        await unitOfWork.SaveAsync();
    }

    public async Task UpdateAnnouncement(UpdateAnnouncementDto announcementDto)
    {
        var announcement = await unitOfWork.Announcement
            .GetSingleByConditionAsync(a => a.Id == announcementDto.Id);

        if (announcement == null)
            throw new EntityNotFoundException("Announcement not found");

        announcement.Title = announcementDto.Title;
        announcement.Description = announcementDto.Description;
        if (announcementDto.PhotoPath != null)
            announcement.PhotoPath = announcementDto.PhotoPath;

        unitOfWork.Announcement.Update(announcement);
        await unitOfWork.SaveAsync();
    }

    public async Task DeleteAnnouncement(Guid id)
    {
        await unitOfWork.Announcement.Delete(id);
        await unitOfWork.SaveAsync();
    }
}