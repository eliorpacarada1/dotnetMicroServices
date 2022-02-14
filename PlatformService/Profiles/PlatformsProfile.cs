using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            CreateMap<Platform, PlatformCreateDto>().ReverseMap();
            CreateMap<Platform, PlatformPublishedDto>().ReverseMap();
            CreateMap<Platform, PlatformReadDto>().ReverseMap();
            CreateMap<PlatformReadDto, PlatformPublishedDto>().ReverseMap();
        }
        
    }
}
