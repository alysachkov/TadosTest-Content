namespace Content.WebApi.Controllers.City.Actions.Create
{
    using Api.Requests.Abstractions;
    using System.ComponentModel.DataAnnotations;

    public record CityCreateRequest : IRequest<CityCreateResponse>
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public long CountryId { get; init; }
    }
}