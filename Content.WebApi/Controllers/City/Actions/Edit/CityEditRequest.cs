namespace Content.WebApi.Controllers.City.Actions.Edit
{
    using Api.Requests.Abstractions;
    using System.ComponentModel.DataAnnotations;

    public record CityEditRequest: IRequest
    {
        [Required]
        public long Id { get; init; }

        public string Name { get; init; }

        public long CountryId { get; init; }
    }
}