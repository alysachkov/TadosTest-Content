namespace Content.WebApi.Controllers.Content.Dto
{
    using System.Collections.Generic;

    public record GalleryDto : ContentDto
    {
        public string CoverUrl { get; init; }
        
        public List<string> ImagesUrls { get; init; }
    }
}