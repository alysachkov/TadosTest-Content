using Api.Requests.Abstractions;

namespace Content.WebApi.Controllers.Country.Actions.Create
{
    public record CountryCreateRequest : IRequest<CountryCreateResponse>
    {
        public string Name { get; set; }
    }
}