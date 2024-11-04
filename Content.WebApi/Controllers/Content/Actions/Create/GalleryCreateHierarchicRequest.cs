namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [Hierarchy(ContentCategory.Gallery)]
    public record GalleryCreateHierarchicRequest : ContentCreateHierarchicRequest
    {
        [Required]
        public string CoverUrl { get; init; }

        [Required]
        public List<string> ImagesUrls { get; init; }
    }
}