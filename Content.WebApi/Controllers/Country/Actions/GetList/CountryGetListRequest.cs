namespace Content.WebApi.Controllers.Country.Actions.GetList
{
    using Api.Requests.Abstractions;
    using Common.DataAnnotations;
    using Pagination;


    public record CountryGetListRequest : IRequest<CountryGetListResponse>
    {
        public Pagination Pagination { get; set; }
        public CountryGetListFilter Filter { get; set; }
    }
}