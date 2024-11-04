namespace Content.WebApi.Controllers.User.Profiles
{
    using AutoMapper;
    using Domain.Entities;
    using global::Content.WebApi.Controllers.User.Dto;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserListItemDto>()
                .ForMember(
                    x => x.CityFullName,
                    x => x.MapFrom(y => $"{y.City.Country.Name}, {y.City.Name}"));

            CreateMap<User, UserDto>();
        }
    }
}
