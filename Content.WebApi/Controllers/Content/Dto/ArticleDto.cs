namespace Content.WebApi.Controllers.Content.Dto
{
    public record ArticleDto : ContentDto
    {
        public string Text { get; init; }
    }
}