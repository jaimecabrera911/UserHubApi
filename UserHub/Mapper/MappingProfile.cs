using AutoMapper;
using UserHub.Dto;
using UserHub.Entities;

namespace UserHub.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, FindUserDto>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name ?? ""));
        CreateMap<CreateUserDto, User>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => new Role()));

        CreateMap<RoleDto, Role>();

        CreateMap<Role, RoleDto>();
    }
}