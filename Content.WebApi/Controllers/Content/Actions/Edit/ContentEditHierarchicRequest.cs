namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using Api.Requests.Hierarchic.Abstractions;
    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;
    using System.ComponentModel.DataAnnotations;

    public abstract record ContentEditHierarchicRequest : IHierarchicRequest
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [HierarchyDiscriminator]
        public ContentCategory Category { get; init; }

        public string Name { get; set; }
    }
}