namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using Common.DataAnnotations;
    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [Hierarchy(ContentCategory.Gallery)]
    public record GalleryEditHierarchicRequest : ContentEditHierarchicRequest
    {
        [Url]
        public string CoverUrl { get; set; }

        [UrlList]
        public List<string> ImagesUrls { get; set; }
    }
}