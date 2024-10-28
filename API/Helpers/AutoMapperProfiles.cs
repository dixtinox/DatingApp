using API.Entities;
using AutoMapper;
using API.DTOs;
using System.IO.Compression;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberResponse>()
        .ForMember(d => d.PhotoUrl, 
        o => o.MapFrom(s => s.Photos.FirstOrDefault(p => p.IsMain)!.Url));
        CreateMap<Photo, PhotoResponse>();
    }
}