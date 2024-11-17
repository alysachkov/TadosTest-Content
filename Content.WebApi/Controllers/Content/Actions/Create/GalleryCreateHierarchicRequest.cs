namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using Common.DataAnnotations;
    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [Hierarchy(ContentCategory.Gallery)]
    public record GalleryCreateHierarchicRequest : ContentCreateHierarchicRequest
    {
        [Required]
        [Url]
        public string CoverUrl { get; init; }

        [Required]
        [UrlList]
        public List<string> ImagesUrls { get; init; }
    }
}