namespace Content.Domain.Criteria
{
    using Queries.Abstractions;
    using Pagination;

    public record FindUserByFilter(
        Pagination Pagination,
        string Search) : ICriterion;
}