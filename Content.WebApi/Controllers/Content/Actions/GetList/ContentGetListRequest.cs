namespace Content.WebApi.Controllers.Content.Actions.GetList
{
    using Api.Requests.Abstractions;
    using Pagination;


    public record ContentGetListRequest : IRequest<ContentGetListResponse>
    {
        // Если объект Pagination не указан, то отдаётся весь список
        public Pagination Pagination { get; set; }

        public ContentGetListFilter Filter { get; set; }
    }
}