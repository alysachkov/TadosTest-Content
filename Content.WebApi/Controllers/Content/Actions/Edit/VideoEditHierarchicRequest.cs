namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;
    using System.ComponentModel.DataAnnotations;

    [Hierarchy(ContentCategory.Video)]
    public record VideoEditHierarchicRequest : ContentEditHierarchicRequest
    {
        [Url]
        public string Url { get; set; }
    }
}