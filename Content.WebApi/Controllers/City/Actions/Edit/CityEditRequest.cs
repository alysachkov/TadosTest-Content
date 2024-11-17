namespace Content.WebApi.Controllers.City.Actions.Edit
{
    using Api.Requests.Abstractions;
    using Common.DataAnnotations;
    using System.ComponentModel.DataAnnotations;

    public record CityEditRequest: IRequest
    {
        [Required]
        public long Id { get; init; }
        [Nullable]
        public string Name { get; init; }
        public long? CountryId { get; init; }
    }
}