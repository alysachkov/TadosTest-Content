using Api.Requests.Abstractions;

namespace Content.WebApi.Controllers.User.Actions.Get
{
    public record UserGetRequest : IRequest<UserGetResponse>
    {
        public long Id { get; set; }
    }
}