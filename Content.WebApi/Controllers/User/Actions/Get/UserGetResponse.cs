namespace Content.WebApi.Controllers.User.Actions.Get
{
    using Api.Requests.Abstractions;
    using Dto;

    public record UserGetResponse(UserDto User) : IResponse;
}