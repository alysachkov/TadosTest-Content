namespace Content.Domain.Criteria
{
    using Queries.Abstractions;
    using Pagination;

    public record FindCountryByFilter(
        Pagination Pagination,
        string Search) : ICriterion;
}