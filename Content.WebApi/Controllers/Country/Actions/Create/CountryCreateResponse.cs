using Api.Requests.Abstractions;

namespace Content.WebApi.Controllers.Country.Actions.Create
{
    public record CountryCreateResponse(long Id) : IResponse;
}