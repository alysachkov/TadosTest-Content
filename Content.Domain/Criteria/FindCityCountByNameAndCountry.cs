namespace Content.Domain.Criteria
{
    using Entities;
    using Queries.Abstractions;

    public record FindCityCountByNameAndCountry(string Name, Country Country) : ICriterion;
}