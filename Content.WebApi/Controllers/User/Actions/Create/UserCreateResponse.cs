using Api.Requests.Abstractions;

namespace Content.WebApi.Controllers.User.Actions.Create
{
    public record UserCreateResponse(long Id) : IResponse;
}