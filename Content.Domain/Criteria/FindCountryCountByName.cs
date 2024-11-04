namespace Content.Domain.Criteria
{
    using Queries.Abstractions;

    public record FindCountryCountByName(string Name) : ICriterion;
}