namespace Content.WebApi.Controllers.City.Profiles
{
    using AutoMapper;
    using Domain.Entities;
    using global::Content.WebApi.Controllers.City.Dto;

    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityListItemDto>();

            CreateMap<City, CityDto>();
        }
    }
}
