namespace Content.WebApi.Controllers.User.Actions.GetList
{
    using Api.Requests.Abstractions;
    using Dto;
    using Pagination;

    public record UserGetListResponse(PaginatedList<UserListItemDto> Page) : IResponse;
}