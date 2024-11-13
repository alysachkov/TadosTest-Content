namespace Content.WebApi.Controllers.Content.Actions.GetList
{
    using Api.Requests.Abstractions;
    using Common.DataAnnotations;
    using Pagination;


    public record ContentGetListRequest : IRequest<ContentGetListResponse>
    {
        [Nullable]
        public Pagination Pagination { get; set; }

        [Nullable]
        public ContentGetListFilter Filter { get; set; }
    }
}