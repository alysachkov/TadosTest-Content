namespace Content.Domain.Criteria
{
    using Queries.Abstractions;
    using Pagination;

    public record FindCityByFilter(
        Pagination Pagination,
        long? CountryId,
        string Search) : ICriterion;
}