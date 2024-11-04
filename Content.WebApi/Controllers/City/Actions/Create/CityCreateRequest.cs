namespace Content.WebApi.Controllers.City.Actions.Create
{
    using Api.Requests.Abstractions;
    public record CityCreateRequest : IRequest<CityCreateResponse>
    {
        public string Name { get; init; }

        public long CountryId { get; init; }
    }
}