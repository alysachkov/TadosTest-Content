namespace Content.WebApi.Controllers.City.Actions.GetList
{
    using Api.Requests.Abstractions;
    using Dto;
    using Pagination;


    public record CityGetListResponse(PaginatedList<CityListItemDto> Page) : IResponse;
}