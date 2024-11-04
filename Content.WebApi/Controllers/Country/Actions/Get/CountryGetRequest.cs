using Api.Requests.Abstractions;

namespace Content.WebApi.Controllers.Country.Actions.Get
{
    public record CountryGetRequest : IRequest<CountryGetResponse>
    {
        public long Id { get; set; }
    }
}