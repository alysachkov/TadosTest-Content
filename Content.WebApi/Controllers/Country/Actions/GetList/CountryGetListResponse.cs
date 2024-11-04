namespace Content.WebApi.Controllers.Country.Actions.GetList
{
    using Api.Requests.Abstractions;
    using Dto;
    using Pagination;


    public record CountryGetListResponse(PaginatedList<CountryListItemDto> Page) : IResponse;
}