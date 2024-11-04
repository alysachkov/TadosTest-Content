namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;
    using System.Collections.Generic;

    [Hierarchy(ContentCategory.Gallery)]
    public record GalleryEditHierarchicRequest : ContentEditHierarchicRequest
    {
        public string CoverUrl { get; set; }

        public List<string> ImagesUrls { get; set; }
    }
}