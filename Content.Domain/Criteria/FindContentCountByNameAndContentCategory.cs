namespace Content.Domain.Criteria
{
    using Enums;
    using Queries.Abstractions;

    public record FindContentCountByNameAndContentCategory(string Name, ContentCategory ContentCategory) : ICriterion;
}