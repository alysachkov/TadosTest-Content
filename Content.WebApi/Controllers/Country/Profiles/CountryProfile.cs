namespace Content.WebApi.Controllers.Country.Profiles
{
    using AutoMapper;
    using Domain.Entities;
    using global::Content.WebApi.Controllers.Country.Dto;

    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryListItemDto>();

            CreateMap<Country, CountryDto>();
        }
    }
}
