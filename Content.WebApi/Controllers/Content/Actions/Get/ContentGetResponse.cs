namespace Content.WebApi.Controllers.Content.Actions.Get
{
    using Api.Requests.Abstractions;
    using Dto;

    public record ContentGetResponse(ContentDto Content) : IResponse;
}