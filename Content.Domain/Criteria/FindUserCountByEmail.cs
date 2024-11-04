namespace Content.Domain.Criteria
{
    using Queries.Abstractions;

    public record FindUserCountByEmail(string Email) : ICriterion;
}