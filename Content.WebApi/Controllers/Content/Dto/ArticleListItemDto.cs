namespace Content.WebApi.Controllers.Content.Dto
{
    public record ArticleListItemDto : ContentListItemDto
    {
        public string Text { get; init; }
    }
}