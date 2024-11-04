namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using Api.Requests.Hierarchic.Abstractions;
    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;
    using System.ComponentModel.DataAnnotations;

    public abstract record ContentCreateHierarchicRequest : IHierarchicRequest<ContentCreateHierarchicResponse>
    {
        [Required]
        [HierarchyDiscriminator]
        public ContentCategory Category { get; init; }

        [Required]
        public string Name { get; init; }

        [Required]
        public long UserId { get; init; }
    }
}