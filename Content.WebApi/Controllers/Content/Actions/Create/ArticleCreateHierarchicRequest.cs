namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;
    using System.ComponentModel.DataAnnotations;

    [Hierarchy(ContentCategory.Article)]
    public record ArticleCreateHierarchicRequest : ContentCreateHierarchicRequest
    {
        [Required]
        public string Text { get; init; }
    }
}