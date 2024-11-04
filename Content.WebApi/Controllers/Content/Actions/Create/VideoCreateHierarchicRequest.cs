namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;
    using System.ComponentModel.DataAnnotations;

    [Hierarchy(ContentCategory.Video)]
    public record VideoCreateHierarchicRequest : ContentCreateHierarchicRequest
    {
        [Required]
        public string Url { get; init; }
    }
}