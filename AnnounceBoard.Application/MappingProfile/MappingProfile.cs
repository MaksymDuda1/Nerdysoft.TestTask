using AnnounceBoard.Domain.Dtos;
using AnnounceBoard.Domain.Entities;
using AutoMapper;

namespace AnnounceBoard.Application.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Announcement, AnnouncementDto>().ReverseMap()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt =>
                opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt =>
                opt.MapFrom(src => src.Description));
        
        CreateMap<UserDto, User>().ReverseMap();
    }
}