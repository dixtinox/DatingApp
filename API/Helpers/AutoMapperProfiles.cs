using API.Entities;
using AutoMapper;
using API.DTOs;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberResponse>();
        CreateMap<Photo, PhotoResponse>();
    }
}