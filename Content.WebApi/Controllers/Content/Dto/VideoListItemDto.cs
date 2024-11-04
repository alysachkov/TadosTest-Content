namespace Content.WebApi.Controllers.Content.Dto
{
    public record VideoListItemDto : ContentListItemDto
    {
        public string Url { get; init; }
    }
}