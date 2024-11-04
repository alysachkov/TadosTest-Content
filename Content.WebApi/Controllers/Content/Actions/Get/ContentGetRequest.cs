using Api.Requests.Abstractions;

namespace Content.WebApi.Controllers.Content.Actions.Get
{
    public record ContentGetRequest : IRequest<ContentGetResponse>
    {
        public long Id { get; init; }
    }
}