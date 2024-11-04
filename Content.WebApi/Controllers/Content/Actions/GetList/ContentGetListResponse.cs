namespace Content.WebApi.Controllers.Content.Actions.GetList
{
    using Api.Requests.Abstractions;
    using Dto;
    using Pagination;

    public record ContentGetListResponse(PaginatedList<ContentListItemDto> Page) : IResponse;
}