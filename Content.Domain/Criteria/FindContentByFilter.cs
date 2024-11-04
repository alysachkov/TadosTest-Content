namespace Content.Domain.Criteria
{
    using Enums;
    using Queries.Abstractions;
    using Pagination;

    public record FindContentByFilter(
        Pagination Pagination,
        ContentCategory? ContentCategory,
        long? UserId,
        string Search) : ICriterion;
}