namespace Content.WebApi.Controllers.City.Actions.GetList
{
    using Api.Requests.Abstractions;
    using Pagination;


    public record CityGetListRequest : IRequest<CityGetListResponse>
    {
        public Pagination Pagination { get; set; }
        
        public CityGetListFilter Filter { get; set; }
    }
}