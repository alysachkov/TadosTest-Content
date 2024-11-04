using Api.Requests.Abstractions;

namespace Content.WebApi.Controllers.User.Actions.Create
{
    public record UserCreateRequest : IRequest<UserCreateResponse>
    {
        public string Email { get; set; }

        public long CityId { get; set; }
    }
}