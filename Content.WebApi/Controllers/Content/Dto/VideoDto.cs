namespace Content.WebApi.Controllers.Content.Dto
{
    public record VideoDto : ContentDto
    {
        public string Url { get; init; }
    }
}